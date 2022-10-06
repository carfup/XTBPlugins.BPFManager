using Carfup.XTBPlugins.AppCode;
using Carfup.XTBPlugins.Forms;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
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
        private Entity bpfStageSelected = null;
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
            dm = new DataManager(detail.ServiceClient, detail.OrganizationMajorVersion);
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
            rbEnabledDisabledRecordsNo.Checked = true;
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
                        MessageBox.Show("Your entity query has no results.");
                        tbRecordsRetrieved.Text = "";
                        return;
                    }

                    recordEntityToMigrate = recordToMigrateList.FirstOrDefault()?.LogicalName;
                    attributeName = dm.GetPrimaryNameAttributeOfEntity(recordToMigrateList.FirstOrDefault().LogicalName);

                    tbRecordsRetrieved.Text =
                        $"We retrieved {recordToMigrateList.Count} records from {recordToMigrateList.FirstOrDefault()?.LogicalName} entity.";

                    //Enabling Load BPF button
                    btnLoadBPFs.Enabled = true;

                    this.log.LogData(EventType.Event, LogAction.RecordsToMigrateRetrieved);


                    totalRecordToMigrate = recordToMigrateList.Count;
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
                        cbTargetBPFList.Items.Add(record.GetAttributeValue<string>("name"));
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
            bpfSelected = bpfList.FirstOrDefault(x => x.GetAttributeValue<string>("name") == cbTargetBPFList.SelectedItem.ToString());
            lblTargetStageEntityDiff.Visible = false;

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
                        cbTargetBPFStages.Items.Add($"{stage.GetAttributeValue<string>("stagename")} ({stage.GetAttributeValue<string>("primaryentitytypecode")})");

                    cbTargetBPFStages.Enabled = true;

                    this.log.LogData(EventType.Event, LogAction.RelatedBPFStagesRetrieved);
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void cbTargetBPFStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTargetBPFStages.SelectedIndex == -1) return;

            btnMigrateRecordBPF.Enabled = (cbTargetBPFStages.SelectedItem != null || cbTargetBPFStages.SelectedItem.ToString() != "");

            if (recordToMigrateList != null && cbTargetBPFStages.SelectedItem != null &&
                cbTargetBPFList.SelectedItem != null)
            {
                btnMigrateRecordBPF.Enabled = true;
                rbEnabledDisabledRecordsNo.Enabled = true;
                rbEnabledDisabledRecordsYes.Enabled = true;

                string targetStage = cbTargetBPFStages.SelectedItem.ToString().Split('(')[0];
                targetStage = targetStage.Remove(targetStage.Length - 1);
                bpfStageSelected = stageList.FirstOrDefault(w => w.GetAttributeValue<string>("stagename") == targetStage);

                lblTargetStageEntityDiff.Visible = bpfSelected.GetAttributeValue<string>("primaryentity") != bpfStageSelected.GetAttributeValue<string>("primaryentitytypecode");
            }
                
        }

        public bool AllowMigrateButton()
        {
            if (recordToMigrateList == null)
            {
                MessageBox.Show("You need to load the records to migrate first.");
                return false;
            }

            if (cbTargetBPFStages.SelectedItem == null || cbTargetBPFStages.GetItemText(cbTargetBPFStages.SelectedItem) == "")
            {
                MessageBox.Show("You need to select a target Business process flow first.");
                return false;
            }

            if (cbTargetBPFList.SelectedItem == null || cbTargetBPFStages.GetItemText(cbTargetBPFList.SelectedItem) == "")
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

            List<string> traversedpath = new List<string>();
            var totalRecordMigrated = 0;
            totalRecordToMigrate = recordToMigrateList.Count;
            migrationErrors = new List<MigrationError>();

            manageEnablingOfControls(false);
            DisplayStatsMiddle();

            // Init progressBar

            SendMessageToStatusBar(this, new StatusBarMessageEventArgs(0, "Starting migration ..."));

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Migrating the Business Process flows for each records {Environment.NewLine}May take a moment ...",
                IsCancelable = true,
                Work = (bw, e) =>
                {
                    List<Entity> retrieveExistingBPFInstances = null;
                    try
                    {
                        retrieveExistingBPFInstances = dm.GetExistingBPFInstances(bpfSelected.GetAttributeValue<string>("uniquename"),
                            recordToMigrateList.FirstOrDefault().LogicalName, recordToMigrateList.Select(x => x.Id).ToArray());
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
                            }
                        }
                    }
                    int progress = ((totalRecordMigrated * 100) / totalRecordToMigrate);
                    var bpfSelectedEntityName = bpfSelected.GetAttributeValue<string>("uniquename");

                    // Get lookup field between record entity & bpf entity
                    var referencingAttributeEntityBpf = this.dm.RetrieveReferencingAttributeOfBpf(bpfSelectedEntityName, recordEntityToMigrate);

                    var numberOfRecordsToProceed = recordToMigrateList.Count;

                    var executeMultipleRequestSetBPF = new ExecuteMultipleRequest()
                    {
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = false,
                            ReturnResponses = true
                        },
                        Requests = new OrganizationRequestCollection()
                    };

                    // for each record to migrate
                    foreach (var record in recordToMigrateList)
                    {
                        if (bw.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        var bpfInstanceExist = this.dm.GetExistingBpfInstance(bpfSelectedEntityName, referencingAttributeEntityBpf, record.Id);

                        if (rbEnabledDisabledRecordsYes.Checked)
                        {
                            if (record.GetAttributeValue<OptionSetValue>("statecode").Value == 1) { 
                                record["statecode"] = new OptionSetValue(0);
                                UpsertRequest activateRecordRequest = new UpsertRequest()
                                {
                                    Target = record
                                };

                                executeMultipleRequestSetBPF.Requests.Add(activateRecordRequest);
                            }

                            if (bpfInstanceExist != null && bpfInstanceExist.GetAttributeValue<OptionSetValue>("statecode").Value == 1)
                            {
                                var bpfToUpdateActivate = new Entity(bpfSelectedEntityName);
                                bpfToUpdateActivate.Id = bpfInstanceExist.Id;

                                bpfToUpdateActivate["statecode"] = new OptionSetValue(0);
                                bpfToUpdateActivate["statuscode"] = new OptionSetValue(1);

                                UpsertRequest upsertRequestBPFActivation = new UpsertRequest()
                                {
                                    Target = bpfToUpdateActivate
                                };

                                executeMultipleRequestSetBPF.Requests.Add(upsertRequestBPFActivation);
                            }
                        }

                        var bpfToUpdate = new Entity(bpfSelectedEntityName);
                        if (bpfInstanceExist != null) bpfToUpdate.Id = bpfInstanceExist.Id;
                        bpfToUpdate[referencingAttributeEntityBpf] = record.ToEntityReference();
                        bpfToUpdate["activestageid"] = bpfStageSelected.ToEntityReference();

                        UpsertRequest upsertRequest = new UpsertRequest()
                        {
                            Target = bpfToUpdate
                        };

                        executeMultipleRequestSetBPF.Requests.Add(upsertRequest);

                        totalRecordMigrated++;

                        if (totalRecordMigrated % this.settings.NumberOfRecordPerRound == 0 || numberOfRecordsToProceed == totalRecordMigrated)
                        {
                            ExecuteMultipleRequestBPF(ref executeMultipleRequestSetBPF, bw,
                                         totalRecordMigrated, 0, "updated");
                            progress = ((totalRecordMigrated * 100) / totalRecordToMigrate);
                            SendMessageToStatusBar(this, new StatusBarMessageEventArgs(progress, $"Migration in progress {progress}%  ..."));
                            bw?.ReportProgress(0, $"Processing business process flows {totalRecordMigrated}/{totalRecordToMigrate} migrated ...");
                        }

                        Invoke(new Action(() =>
                        {
                            labelRecordsRemaining.Text = $@"{totalRecordToMigrate - totalRecordMigrated}";
                        }));
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

        public void ExecuteMultipleRequestBPF(ref ExecuteMultipleRequest executeMultipleRequestSetBPF, BackgroundWorker bw, int number, int userProceed, string text)
        {
            ExecuteMultipleResponse executeMultipleResponse = null;
            try
            {
               executeMultipleResponse = (ExecuteMultipleResponse)this.dm.service.Execute(executeMultipleRequestSetBPF);
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
            
            bw?.ReportProgress(0, $"Processing business process flows : {number}  {text}");   
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

                    if (personalViews.Count == 0 && systemViews.Count == 0)
                    {
                        MessageBox.Show("This entity has no related views.");
                        return;
                    }

                    entityViews.AddRange(systemViews.Union(personalViews));
                    comboBoxChooseView.Items.Add("####### System Views #######");
                    comboBoxChooseView.Items.AddRange(systemViews.Select(x => x.GetAttributeValue<string>("name")).OrderBy(x => x).ToArray());
                    comboBoxChooseView.Items.Add("####### Personal Views #######");
                    comboBoxChooseView.Items.AddRange(personalViews.Select(x => x.GetAttributeValue<string>("name")).OrderBy(x => x).ToArray());
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

            var selectedView = entityViews.FirstOrDefault(x => x.GetAttributeValue<string>("name") == comboBoxChooseView.SelectedItem.ToString());
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
            rbEnabledDisabledRecordsNo.Enabled = enabled;
            rbEnabledDisabledRecordsYes.Enabled = enabled;

        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            CancelWorker();
        }

    }
}