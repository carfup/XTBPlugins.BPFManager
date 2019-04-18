using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using EntityReference = Microsoft.Xrm.Sdk.EntityReference;

namespace Carfup.XTBPlugins.BPFManager
{
    public partial class BPFManager : PluginControlBase, IMessageBusHost, IGitHubPlugin, IStatusBarMessenger, IHelpPlugin, IPayPalPlugin
    {
        #region varibables
        private List<Entity> bpfList = null;
        private List<Entity> recordToMigrateList = null;
        private List<Entity> stageList = null;
        private List<Entity> userList = null;
        private List<Entity> entityViews = null;
        private List<MigrationError> migrationErrors = null;
        private Entity bpfSelected = null;
        private MessageBusEventArgs callerArgs = null;
        private string fetchxmlQuery = null;
        private string recordEntityToMigrate = null;
        private DataManager dm = null;
        internal PluginSettings settings = new PluginSettings();
        public LogUsage log = null;
        private int totalRecordToMigrate = 0;
        private int timePerThousandMigration = 60;
        private bool continueOnPermissionError = false;

        public string RepositoryName => "XTBPlugins.BPFManager";
        public string UserName => "carfup";
        public string HelpUrl => "https://github.com/carfup/XTBPlugins.BPFManager";
        public string EmailAccount => "clement@carfup.com";
        public string DonationDescription => "Thanks a lot for your support, this really mean something to me, and push me to keep going for sure !";
        #endregion

        public BPFManager()
        {
            InitializeComponent();
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            dm = new DataManager(newService);
            IsVersionSupported(detail);

            base.UpdateConnection(newService, detail, actionName, parameter);

            if (IsConnectedToEnvironment())
                radioButtonQueryView.Checked = true;
        }

        private void IsVersionSupported(ConnectionDetail cd)
        {
            if (cd == null  || (cd.OrganizationMajorVersion >= 9 || (cd.OrganizationMajorVersion >= 8 && cd.OrganizationMinorVersion >= 2)))
                return;

            MessageBox.Show($"Your Instance version is below 8.2, plugin won't properly work.");
           
        }

        private bool IsConnectedToEnvironment()
        {
            bool isConnected = this.ConnectionDetail != null;

            comboBoxChooseEntity.Enabled = isConnected;
            comboBoxChooseView.Enabled = isConnected;
            btnOpenFXB.Enabled = isConnected;

            if (!isConnected)
                MessageBox.Show("Make sure you are connected to an instance before proceeding.");

            return isConnected;
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            callerArgs = message;
            if (message.TargetArgument != null)
            {
                fetchxmlQuery = (string)message.TargetArgument;
            }

            btnRetrieveRecordsFetchQuery.Enabled = !String.IsNullOrEmpty(fetchxmlQuery);
        }

        private void BPFMigration_Load(object sender, EventArgs e)
        {
            log = new LogUsage(this);
            log.LogData(EventType.Event, LogAction.PluginOpened);
            LoadSetting();

            //displaying the proper control for query
            radioButtonQueryView.Checked = true;
        }
    
        private void LoadSetting()
        {
            try
            {
                if (SettingsManager.Instance.TryLoad<PluginSettings>(typeof(BPFManager), out settings))
                {
                    return;
                }
                else
                    settings = new PluginSettings();

            }
            catch (InvalidOperationException ex)
            {
                log.LogData(EventType.Exception, LogAction.SettingLoaded, ex);
            }

            log.LogData(EventType.Event, LogAction.SettingLoaded);

            if (!settings.AllowLogUsage.HasValue)
            {
                log.PromptToLog();
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            log.LogData(EventType.Event, LogAction.SettingsSaved);
            SettingsManager.Instance.Save(typeof(BPFManager), settings);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.log.LogData(EventType.Event, LogAction.PluginClosed);

            // Saving settings for the next usage of plugin
            SaveSettings();
            this.log.Flush();
            CloseTool();
        }

        private void btnOpenFXB_Click(object sender, EventArgs e)
        {
            log.LogData(EventType.Event, LogAction.FXBBuilerUsed);
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder")
            {
                SourcePlugin = "BPF Manager",
                TargetArgument = fetchxmlQuery
            };
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        private bool isFetchQueryValidated()
        {
            return fetchxmlQuery.ToLower().StartsWith("<fetch");
        }

        private void btnRetrieveRecordsFetchQuery_Click(object sender, EventArgs evt)
        {
            if (!isFetchQueryValidated())
            {
                MessageBox.Show("Error with your query",
                    "It seems that you are trying to execute a wrong FetchXML query", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!IsConnectedToEnvironment())
                return;

            var attributeName = "";
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Looking for records...",
                IsCancelable = true,
                Work = (bw, e) =>
                {
                    recordToMigrateList = dm.GetRecordsToMigrate(fetchxmlQuery, bw);

                    userList = dm.GetUsers(bw);
                    //e.Result = this.Service.RetrieveMultiple(new FetchExpression(fetchxmlQuery)).Entities;
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.log.LogData(EventType.Exception, LogAction.RecordsToMigrateRetrieved, e.Error);
                        return;
                    }

                    if (recordToMigrateList.Count == 0)
                    {
                        MessageBox.Show("Your record query has no result");
                        tbRecordsRetrieved.Text = "";
                        return;
                    }

                    if (userList.Count == 0)
                    {
                        MessageBox.Show("You seem to have no active users on your instance.");
                        tbRecordsRetrieved.Text = "";
                        return;
                    }


                    recordEntityToMigrate = recordToMigrateList.FirstOrDefault()?.LogicalName;
                    attributeName = dm.GetPrimaryNameAttributeOfEntity(recordToMigrateList.FirstOrDefault().LogicalName);

                    tbRecordsRetrieved.Text =
                        $"We retrieved {recordToMigrateList.Count} records from {recordToMigrateList.FirstOrDefault()?.LogicalName} entity.{Environment.NewLine}{Environment.NewLine}We retrieved {userList.Count} active users.";

                    //Enabling Load BPF button
                    btnLoadBPFs.Enabled = true;

                    this.log.LogData(EventType.Event, LogAction.RecordsToMigrateRetrieved);


                    totalRecordToMigrate = userList.Count * recordToMigrateList.Count;
                    DisplayStatsMiddle();
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void DisplayStatsMiddle()
        {
            int time = (totalRecordToMigrate / 1000) * timePerThousandMigration;
            labelNumberOfRecordsToMigrate.Text = $"The migration will handle : {totalRecordToMigrate} records.";
            labelTimeEstimation.Text = $"This can take up to {((time < 60) ? "60" : time.ToString())} seconds.";
            labelRecordsRemaining.Text = $"{totalRecordToMigrate}";
        }

        private void btnRetrieveUsers_Click(object sender, EventArgs evt)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Looking for active users...",
                IsCancelable = true,
                Work = (bw, e) =>
                {
                    userList = dm.GetUsers(bw);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          this.log.LogData(EventType.Exception, LogAction.UsersRetrieved, e.Error);
                        return;
                    }

                    if (userList.Count == 0)
                    {
                        MessageBox.Show("Your query has no result");
                        return;
                    }

                    this.log.LogData(EventType.Event, LogAction.UsersRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void btnLoadBPFs_Click(object sender, EventArgs evt)
        {
            cbTargetBPFList.Items.Clear();
            bpfList = new List<Entity>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Querying for related Business Process Flows...",
                Work = (bw, e) =>
                {
                    bpfList = dm.GetRelatedBPF(recordEntityToMigrate);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          this.log.LogData(EventType.Exception, LogAction.RelatedBPFRetrieved, e.Error);
                        return;
                    }

                    if (bpfList.Count == 0)
                    {
                        this.log.LogData(EventType.Event, LogAction.NoBPFForEntity);
                        MessageBox.Show("This entity has no BPF(s) associated yet...");
                        return;
                    }

                    foreach (var record in bpfList)
                    {
                        cbTargetBPFList.Items.Add(record.Attributes["name"]);
                    }

                    cbTargetBPFList.Enabled = true;
                    this.log.LogData(EventType.Event, LogAction.RelatedBPFRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbTargetBPFList_SelectedIndexChanged(object sender, EventArgs evt)
        {
            cbTargetBPFStages.Items.Clear();
            cbTargetBPFStages.SelectedIndex = -1;
            stageList = new List<Entity>();
            bpfSelected = bpfList.FirstOrDefault(x => x.Attributes["name"] == cbTargetBPFList.SelectedItem);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Querying for Business Process Flow Stages...",
                Work = (bw, e) =>
                {
                    stageList = dm.GetBPFStages(bpfSelected.Id);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          this.log.LogData(EventType.Exception, LogAction.RelatedBPFStagesRetrieved, e.Error);
                        return;
                    }

                    if (stageList.Count == 0)
                    {
                        this.log.LogData(EventType.Event, LogAction.NoStagesForBPF);
                        MessageBox.Show("There are no stages associated to this BPF...");
                        return;
                    }

                    foreach (var stage in stageList)
                    {
                        cbTargetBPFStages.Items.Add(stage.Attributes["stagename"]);
                    }

                    cbTargetBPFStages.Enabled = true;

                    this.log.LogData(EventType.Event, LogAction.RelatedBPFStagesRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbTargetBPFStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTargetBPFStages.SelectedIndex == -1) return;

            btnMigrateRecordBPF.Enabled = (cbTargetBPFStages.SelectedItem != null || cbTargetBPFStages.SelectedItem != "");

                if (recordToMigrateList != null && userList!= null && cbTargetBPFStages.SelectedItem != null &&
                    cbTargetBPFList.SelectedItem != null)
                    btnMigrateRecordBPF.Enabled = true;
        }

        public bool AllowMigrateButton()
        {
            if (recordToMigrateList == null)
            {
                MessageBox.Show("You need to load the records to migrate first.");
                return false;
            }

            if (userList == null)
            {
                MessageBox.Show("You need to load the users first.");
                return false;
            }

            if (cbTargetBPFStages.SelectedItem == "" || cbTargetBPFStages.SelectedItem == null)
            {
                MessageBox.Show("You need to select a target Business process flow first.");
                return false;
            }

            if (cbTargetBPFList.SelectedItem == "" || cbTargetBPFList.SelectedItem == null)
            {
                MessageBox.Show("You need to select a target Business process flow Stage first.");
                return false;
            }

            return true;
        }

        private void btnMigrateRecordBPF_Click(object sender, EventArgs evt)
        {
            if (!AllowMigrateButton())
                return;

            string bpfSelectedEntityTarget = bpfSelected.Attributes["uniquename"].ToString();
            var stageId = stageList.FirstOrDefault(w => w.Attributes["stagename"] == cbTargetBPFStages.SelectedItem);
            List<string> traversedpath = new List<string>();
            string targetStage = cbTargetBPFStages.SelectedItem.ToString();
            var totalRecordMigrated = 0;
            var totalRecordInstanced = 0;
            var totalRecordUpdated = 0;
            var totalSkipped = 0;
            totalRecordToMigrate = userList.Count * recordToMigrateList.Count;
            migrationErrors = new List<MigrationError>();

            manageEnablingOfControls(false);
            DisplayStatsMiddle();

            // Init progressBar

            SendMessageToStatusBar(this, new StatusBarMessageEventArgs(0, "Starting migration ..."));

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Migrating the Business Process flows for each users and records {Environment.NewLine}May take a moment ...",
                IsCancelable = true,
                Work = (bw, e) =>
                {
                    var userProceed = 1;
                    int progress = ((((totalRecordUpdated + totalRecordInstanced) / 2) * 100) / totalRecordToMigrate);
                    foreach (var user in userList)
                    {
                        if (bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        var numberOfRecordsToProceed = recordToMigrateList.Count;
                        var recordInstanced = 0;
                        var recordUpdated = 0;

                        var executeMultipleRequestSetBPF = new ExecuteMultipleRequest()
                        {
                            Settings = new ExecuteMultipleSettings()
                            {
                                ContinueOnError = false,
                                ReturnResponses = true
                            },
                            Requests = new OrganizationRequestCollection()
                        };

                        // Instancing the BPF first
                        foreach (var record in recordToMigrateList)
                        {
                            if (bw.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }

                            // Create the instance of the BPF on the record
                            SetProcessRequest setProcReq = new SetProcessRequest
                            {
                                Target = record.ToEntityReference(),
                                NewProcess = new EntityReference(bpfSelected.LogicalName, bpfSelected.Id)
                            };
                            executeMultipleRequestSetBPF.Requests.Add(setProcReq);

                            recordInstanced++;
                            totalRecordInstanced++;

                            if (recordInstanced % this.settings.NumberOfRecordPerRound == 0 || numberOfRecordsToProceed == recordInstanced)
                            {
                                ExecuteMultipleRequestBPF(user.Id, ref executeMultipleRequestSetBPF, bw,
                                    recordInstanced, userProceed, "instanced");
                                progress = ((((totalRecordUpdated + totalRecordInstanced) / 2) * 100) / totalRecordToMigrate);
                                SendMessageToStatusBar(this, new StatusBarMessageEventArgs(progress, $"Migration in progress {progress}%  ..."));                                
                            }
                        }


                        var executeMultipleRequestUpdateBPF = new ExecuteMultipleRequest
                        {
                            Settings = new ExecuteMultipleSettings
                            {
                                ContinueOnError = true,
                                ReturnResponses = true
                            },
                            Requests = new OrganizationRequestCollection()
                        };

                        List<Entity> resultQueryProperBPF = null;
                        //Updating the BPF stage + traversedpath 
                        foreach (var record in recordToMigrateList)
                        {
                            if (bw.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }

                            var attrForCondition = bpfSelectedEntityTarget.Contains("_") ? $"bpf_{record.LogicalName}id" : $"{record.LogicalName}id";

                            // So we do it only once
                            if(resultQueryProperBPF == null)
                            {
                                try
                                {
                                    resultQueryProperBPF = this.dm.GetProperBPFList(bpfSelectedEntityTarget,
                                        recordToMigrateList, attrForCondition);
                                }
                                catch (Exception exception)
                                {
                                    if (!continueOnPermissionError)
                                    {
                                        var result = MessageBox.Show(exception.Message, "Error during migration !",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                                        if (result == DialogResult.No)
                                            return;
                                        else if (result == DialogResult.Yes)
                                        {
                                            continueOnPermissionError = true;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                            var wantedBPFInstanceREcord = resultQueryProperBPF.FirstOrDefault(x => ((EntityReference)x.Attributes[attrForCondition]).Id == record.Id);

                            if(wantedBPFInstanceREcord == null)
                            {
                                //migrationErrors.Add(record);
                                continue;
                            }

                            // Preparing the traversedpath so we do it only once as it's the same path for all records
                            if (traversedpath.Count == 0)
                            {
                                var activePathRequest = new RetrieveActivePathRequest
                                {
                                    ProcessInstanceId = wantedBPFInstanceREcord.Id
                                };
                                var activePathResponse =
                                    (RetrieveActivePathResponse)this.Service.Execute(activePathRequest);

                                var stageDefinitions =
                                    ((EntityCollection)activePathResponse.Results.Values.FirstOrDefault())?.Entities;

                                foreach (var path in stageDefinitions)
                                {
                                    traversedpath.Add(path.Id.ToString());

                                    if (path.Attributes["stagename"].ToString() == targetStage)
                                        break;
                                }
                            }

                            var bpfInstance = new Entity()
                            {
                                LogicalName = wantedBPFInstanceREcord.LogicalName,
                                Id = wantedBPFInstanceREcord.Id
                            };
                            bpfInstance["activestageid"] = new EntityReference(stageId.LogicalName, stageId.Id);
                            bpfInstance["traversedpath"] = String.Join(",",traversedpath);

                            UpdateRequest ur = new UpdateRequest()
                            {
                                Target = bpfInstance,
                                ConcurrencyBehavior = ConcurrencyBehavior.AlwaysOverwrite
                                
                            };
                            executeMultipleRequestUpdateBPF.Requests.Add(ur);

                            recordUpdated++;
                            totalRecordMigrated++;
                            totalRecordUpdated++;

                            if (totalRecordUpdated % this.settings.NumberOfRecordPerRound == 0 || numberOfRecordsToProceed == recordUpdated)
                            {
                                ExecuteMultipleRequestBPF(user.Id, ref executeMultipleRequestUpdateBPF, bw,
                                    recordUpdated, userProceed, "updated", false);
                                progress = ((((totalRecordUpdated + totalRecordInstanced) / 2) * 100) / totalRecordToMigrate);
                                SendMessageToStatusBar(this, new StatusBarMessageEventArgs(progress, $"Migration in progress {progress}%  ..."));
                                
                            }

                            Invoke(new Action(() =>
                            {
                                labelRecordsRemaining.Text = $@"{totalRecordToMigrate - totalRecordMigrated}";
                            }));
                        }

                        userProceed++;
                        bw?.ReportProgress(0, $"Processing user {userProceed}/{userList.Count} ...{Environment.NewLine}Total records migrated : {totalRecordMigrated}");
                        SendMessageToStatusBar(this, new StatusBarMessageEventArgs(progress, $"Migration in progress {progress}%  ..."));
                    }

                    e.Result = totalRecordMigrated;
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          this.log.LogData(EventType.Exception, LogAction.RecordsMigrated, e.Error);
                        return;
                    }
                    else if (e.Cancelled)
                    {
                        this.log.LogData(EventType.Event, LogAction.MigrationCancelled);
                        MessageBox.Show(
                                $"The migration was successfully cancelled. {Environment.NewLine}{totalRecordMigrated} records were migrated.",
                                "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        labelNumberOfRecordsToMigrate.Text = "The migration will handle : X records.";
                        labelRecordsRemaining.Text = "X";
                        labelTimeEstimation.Text = "This can take up to X time.";

                        SendMessageToStatusBar(this, new StatusBarMessageEventArgs(0, "Cancelled ..."));
                    }
                    else
                    {

                        MessageBox.Show($"You migrated {totalRecordMigrated} records !", "Migration done.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SendMessageToStatusBar(this, new StatusBarMessageEventArgs("done!."));
                        this.log.LogData(EventType.Event, LogAction.RecordsMigrated);
                    }

                    manageEnablingOfControls(true);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        public void ExecuteMultipleRequestBPF(Guid userId,  ref ExecuteMultipleRequest executeMultipleRequestSetBPF, BackgroundWorker bw, int number, int userProceed, string text, bool impersonate = true)
        {
            ExecuteMultipleResponse executeMultipleResponse = null;
            try
            {
                if (impersonate)
                {
                    var proxy = (OrganizationServiceProxy)this.Service;
                    proxy.CallerId = userId;
                    executeMultipleResponse = (ExecuteMultipleResponse)proxy.Execute(executeMultipleRequestSetBPF);
                }
                else
                {
                    executeMultipleResponse = (ExecuteMultipleResponse)this.Service.Execute(executeMultipleRequestSetBPF);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            foreach (var responseItem in executeMultipleResponse.Responses)
            {
                // An error has occurred.
                if (responseItem.Fault != null)
                {
                    migrationErrors.Add(new MigrationError()
                    {
                        request = executeMultipleRequestSetBPF.Requests[responseItem.RequestIndex],
                        fault = responseItem.Fault
                    });
                }
            }

            executeMultipleRequestSetBPF = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };
            
            bw?.ReportProgress(0, $"Processing user {userProceed}/{userList.Count} ...{Environment.NewLine}{number} business process flows {text}");   
        }

        private void radioButtonBuildQuery_CheckedChanged(object sender, EventArgs e)
        {
            ManageQueryTypeToDisplay();
        }

        private void radioButtonQueryView_CheckedChanged(object sender, EventArgs evt)
        {
            ManageQueryTypeToDisplay();
            comboBoxChooseEntity.Items.Clear();
            ExecuteMethod(LoadEntityWithBPF);
        }

        public void ManageQueryTypeToDisplay()
        {
            btnOpenFXB.Visible = radioButtonBuildQuery.Checked;
            labelChooseEntity.Visible = radioButtonQueryView.Checked;
            labelChooseView.Visible = radioButtonQueryView.Checked;
            comboBoxChooseEntity.Visible = radioButtonQueryView.Checked;
            comboBoxChooseView.Visible = radioButtonQueryView.Checked;
        }

        private void comboBoxChooseEntity_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseEntity.Items.Count == 0)
                ExecuteMethod(LoadEntityWithBPF);
        }

        private void comboBoxChooseEntity_SelectedIndexChanged(object sender, EventArgs evt)
        {
            entityViews = new List<Entity>();
            comboBoxChooseView.Items.Clear();
            comboBoxChooseView.SelectedIndex = -1;
            comboBoxChooseView.SelectedItem = null;
            cbTargetBPFStages.Enabled = false;
            cbTargetBPFList.Enabled = false;
            List<Entity> personalViews = new List<Entity>();
            List<Entity> systemViews = new List<Entity>();

            var entitySelectedDropDown =
                comboBoxChooseEntity.SelectedItem.ToString().Split('(').Last().Replace(")", "");


            WorkAsync(new WorkAsyncInfo
            {
                Message = "Looking for entity views...",
                Work = (bw, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        personalViews = dm.GetPersonalViewsOfEntity(entitySelectedDropDown);
                        systemViews = dm.GetSystemViewsOfEntity(entitySelectedDropDown);
                    }));
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.log.LogData(EventType.Exception, LogAction.BPFEntityViewsRetrieved, e.Error);
                        return;
                    }

                    if (personalViews.Count == 0 || systemViews.Count == 0)
                    {
                        MessageBox.Show("Your query has no result");
                        return;
                    }

                    entityViews.AddRange(systemViews.Union(personalViews));
                    comboBoxChooseView.Items.Add("####### System Views #######");
                    comboBoxChooseView.Items.AddRange(systemViews.Select(x => x.Attributes["name"]).OrderBy(x => x).ToArray());
                    comboBoxChooseView.Items.Add("####### Personal Views #######");
                    comboBoxChooseView.Items.AddRange(personalViews.Select(x => x.Attributes["name"]).OrderBy(x => x).ToArray());
                    this.log.LogData(EventType.Event, LogAction.BPFEntityViewsRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        public void LoadEntityWithBPF()
        {
            ManageQueryTypeToDisplay();
            comboBoxChooseEntity.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading the entities with BPF...",
                Work = (bw, e) =>
                {
                    e.Result = dm.GetEntitiesWithBPF();
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.log.LogData(EventType.Exception, LogAction.EntitiesWithBPFRetrieved, e.Error);
                        return;
                    }

                    var result = e.Result as List<EntityDetailledName>;

                    if (result.Count == 0)
                    {
                        MessageBox.Show("There are no entities with BPF(s) associated yet...");
                        return;
                    }

                    foreach (var r in result)
                    {
                        comboBoxChooseEntity.Items.Add($"{r.displayName} ({r.logicalName})");
                    }

                  //  comboBoxChooseEntity.Items.AddRange(result.ToArray().ToString());

                    this.log.LogData(EventType.Event, LogAction.EntitiesWithBPFRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void comboBoxChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChooseView.SelectedIndex == -1 ||
                comboBoxChooseView.SelectedItem.ToString().Contains("Personal Views") ||
                comboBoxChooseView.SelectedItem.ToString().Contains("System Views"))
            {
                fetchxmlQuery = null;
                btnRetrieveRecordsFetchQuery.Enabled = false;
                return;
            }

            var selectedView = entityViews.FirstOrDefault(x => x.Attributes["name"] == comboBoxChooseView.SelectedItem);
            fetchxmlQuery = selectedView.GetAttributeValue<string>("fetchxml");

            btnRetrieveRecordsFetchQuery.Enabled = !String.IsNullOrEmpty(fetchxmlQuery);
        }

        public static string CurrentVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersionInfo.ProductVersion;
            }
        }
        
        private void toolStripButtonOptions_Click(object sender, EventArgs e)
        {
            var allowLogUsage = settings.AllowLogUsage;
            var optionDlg = new Options(this);
            if (optionDlg.ShowDialog(this) == DialogResult.OK)
            {
                settings = optionDlg.GetSettings();
                if (allowLogUsage != settings.AllowLogUsage)
                {
                    if (settings.AllowLogUsage == true)
                    {
                        this.log.updateForceLog();
                        this.log.LogData(EventType.Event, LogAction.StatsAccepted);
                    }
                    else if (!settings.AllowLogUsage == true)
                    {
                        this.log.updateForceLog();
                        this.log.LogData(EventType.Event, LogAction.StatsDenied);
                    }
                }
            }
        }

        private void manageEnablingOfControls(bool enabled)
        {
            btnRetrieveRecordsFetchQuery.Enabled = enabled;
            btnMigrateRecordBPF.Enabled = enabled;
            btnLoadBPFs.Enabled = enabled;
            comboBoxChooseView.Enabled = enabled;
            comboBoxChooseEntity.Enabled = enabled;
            cbTargetBPFList.Enabled = enabled;
            cbTargetBPFStages.Enabled = enabled;
            tsbCancel.Visible = !enabled;
            tssCancel.Visible = !enabled;
            pictureBoxPatience.Visible = !enabled;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            CancelWorker();
        }
    }
}