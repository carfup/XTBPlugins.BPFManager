using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Carfup.XTBPlugins.AppCode;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using EntityReference = Microsoft.Xrm.Sdk.EntityReference;
using System.Reflection;
using System.Diagnostics;
using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Forms;

namespace Carfup.XTBPlugins.BPFManager
{
    public partial class BPFManager : PluginControlBase, IMessageBusHost, IGitHubPlugin, IStatusBarMessenger
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

        public string RepositoryName => "XTBPlugins.BBPFManager";
        public string UserName => "carfup";
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
        }

        private void IsVersionSupported(ConnectionDetail cd)
        {
            if (cd == null  || (cd.OrganizationMajorVersion >= 8 && cd.OrganizationMinorVersion >= 2))
                return;

            MessageBox.Show($"Your Instance version is below 8.2, plugin won't properly work.");
           
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
        
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            //SettingsManager.Instance.Save(GetType(), mySettings);
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

        private void btnRetrieveRecordsFetchQuery_Click(object sender, EventArgs evt)
        {
            var attributeName = "";
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Looking for records...",
                IsCancelable = true,
                Work = (bw, e) =>
                {
                    recordToMigrateList = dm.GetRecordsToMigrate(fetchxmlQuery, bw);
                    attributeName = dm.GetPrimaryNameAttributeOfEntity(recordToMigrateList.FirstOrDefault().LogicalName);
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

                    checkedListBoxRecordsResult.Items.Clear();

                    if (recordToMigrateList.Count == 0)
                    {
                        MessageBox.Show("Your query has no result");
                        return;
                    }

                    checkedListBoxRecordsResult.Items.AddRange(recordToMigrateList.Select(x => x.Attributes[attributeName]).ToArray());

                    recordEntityToMigrate = recordToMigrateList.FirstOrDefault()?.LogicalName;

                    tbRecordsRetrieved.Text =
                        $"We retrieved {recordToMigrateList.Count} records from {recordToMigrateList.FirstOrDefault()?.LogicalName} entity.";

                    //Enabling Load BPF button
                    btnLoadBPFs.Enabled = true;

                    this.log.LogData(EventType.Event, LogAction.RecordsToMigrateRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
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

                    checkedListBoxUsersResult.Items.AddRange(userList.Select(x => x.Attributes["fullname"]).ToArray());
                    tbUsersRetrieved.Text = $"We retrieved {userList.Count} active users.";

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
                        MessageBox.Show("Your query has no result");
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
                        MessageBox.Show("Your query has no result");
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
                btnMigrateRecordBPF.Enabled = cbTargetBPFStages.SelectedItem != "";

                if (recordToMigrateList != null && userList!= null && cbTargetBPFStages.SelectedItem != "" &&
                    cbTargetBPFList.SelectedItem != "")
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
            int totalRecordToMigrate = userList.Count * recordToMigrateList.Count;
            migrationErrors = new List<MigrationError>();

            SendMessageToStatusBar(this, new StatusBarMessageEventArgs(0, "Migrating ..."));

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Migrating the Business Process flows for each users and records {Environment.NewLine}May take a moment ...",
                Work = (bw, e) =>
                {
                    var userProceed = 1;
                    int progress = ((((totalRecordUpdated + totalRecordInstanced) / 2) * 100) / totalRecordToMigrate);
                    foreach (var user in userList)
                    {
                        var numberOfRecordsToProceed = recordToMigrateList.Count;
                        var recordInstanced = 1;
                        var recordUpdated = 1;

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
                            var attrForCondition = bpfSelectedEntityTarget.Contains("_") ? $"bpf_{record.LogicalName}id" : $"{record.LogicalName}id";

                            // So we do it only once
                            if(resultQueryProperBPF == null)
                            {
                                resultQueryProperBPF = this.dm.GetProperBPFList(bpfSelectedEntityTarget,
                                    recordToMigrateList, attrForCondition);
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

                            if (recordInstanced % this.settings.NumberOfRecordPerRound == 0 || numberOfRecordsToProceed == recordUpdated)
                            {
                                ExecuteMultipleRequestBPF(user.Id, ref executeMultipleRequestSetBPF, bw,
                                    recordUpdated, userProceed, "updated", false);
                                progress = ((((totalRecordUpdated + totalRecordInstanced) / 2) * 100) / totalRecordToMigrate);
                                SendMessageToStatusBar(this, new StatusBarMessageEventArgs(progress, $"Migration in progress {progress}%  ..."));
                            }
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

                    MessageBox.Show($"You migrated {totalRecordMigrated} records !");
                    SendMessageToStatusBar(this, new StatusBarMessageEventArgs("done!."));
                    this.log.LogData(EventType.Event, LogAction.RecordsMigrated);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        public void ExecuteMultipleRequestBPF(Guid userId,  ref ExecuteMultipleRequest executeMultipleRequestSetBPF, BackgroundWorker bw, int number, int userProceed, string text, bool impersonate = true)
        {
            ExecuteMultipleResponse executeMultipleResponse = null;
            if (impersonate)
            {
                var proxy = (OrganizationServiceProxy) this.Service;
                proxy.CallerId = userId;
                executeMultipleResponse = (ExecuteMultipleResponse) proxy.Execute(executeMultipleRequestSetBPF);
            }
            else
            {
                executeMultipleResponse = (ExecuteMultipleResponse)this.Service.Execute(executeMultipleRequestSetBPF);
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

                    var result = e.Result as string[];

                    if (result.Length == 0)
                    {
                        MessageBox.Show("Your query has no result");
                        return;
                    }

                    comboBoxChooseEntity.Items.AddRange(result);

                    this.log.LogData(EventType.Event, LogAction.EntitiesWithBPFRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        public void ManageQueryTypeToDisplay()
        {
            btnOpenFXB.Visible = radioButtonBuildQuery.Checked;
            labelChooseEntity.Visible = radioButtonQueryView.Checked;
            labelChooseView.Visible = radioButtonQueryView.Checked;
            comboBoxChooseEntity.Visible = radioButtonQueryView.Checked;
            comboBoxChooseView.Visible = radioButtonQueryView.Checked;
        }

        private void comboBoxChooseEntity_SelectedIndexChanged(object sender, EventArgs evt)
        {
            entityViews = new List<Entity>();
            comboBoxChooseView.Items.Clear();
            comboBoxChooseView.SelectedItem = null;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Looking for entity views...",
                Work = (bw, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        e.Result = dm.GetViewsOfEntity(comboBoxChooseEntity.SelectedItem.ToString());
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

                    var result = e.Result as List<Entity>;

                    if (result.Count == 0)
                    {
                        MessageBox.Show("Your query has no result");
                        return;
                    }

                    entityViews.AddRange(result);
                    comboBoxChooseView.Items.AddRange(result.Select(x => x.Attributes["name"]).ToArray());
                    this.log.LogData(EventType.Event, LogAction.BPFEntityViewsRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void comboBoxChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}