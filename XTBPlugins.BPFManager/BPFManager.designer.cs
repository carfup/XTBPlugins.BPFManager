namespace Carfup.XTBPlugins.BPFManager
{
    partial class BPFManager
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOptions = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbPreparation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRecordsResult = new System.Windows.Forms.TabPage();
            this.checkedListBoxRecordsResult = new System.Windows.Forms.CheckedListBox();
            this.tabPageUsersResult = new System.Windows.Forms.TabPage();
            this.checkedListBoxUsersResult = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRetrieveRecordsFetchQuery = new System.Windows.Forms.Button();
            this.tbRecordsRetrieved = new System.Windows.Forms.TextBox();
            this.tbUsersRetrieved = new System.Windows.Forms.TextBox();
            this.btnRetrieveUsers = new System.Windows.Forms.Button();
            this.panelBuildQuery = new System.Windows.Forms.Panel();
            this.labelChooseView = new System.Windows.Forms.Label();
            this.labelChooseEntity = new System.Windows.Forms.Label();
            this.comboBoxChooseView = new System.Windows.Forms.ComboBox();
            this.comboBoxChooseEntity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonBuildQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonQueryView = new System.Windows.Forms.RadioButton();
            this.btnOpenFXB = new System.Windows.Forms.Button();
            this.gpMigration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadBPFs = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTargetBPFList = new System.Windows.Forms.ComboBox();
            this.cbTargetBPFStages = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMigrateRecordBPF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.toolStripMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbPreparation.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRecordsResult.SuspendLayout();
            this.tabPageUsersResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBuildQuery.SuspendLayout();
            this.gpMigration.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.toolStripButtonOptions});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1701, 37);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.close;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(91, 34);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButtonOptions
            // 
            this.toolStripButtonOptions.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.gear;
            this.toolStripButtonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOptions.Name = "toolStripButtonOptions";
            this.toolStripButtonOptions.Size = new System.Drawing.Size(114, 34);
            this.toolStripButtonOptions.Text = "Options";
            this.toolStripButtonOptions.Click += new System.EventHandler(this.toolStripButtonOptions_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.03021F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.96979F));
            this.tableLayoutPanel1.Controls.Add(this.gbPreparation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpMigration, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 777F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1667, 777);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // gbPreparation
            // 
            this.gbPreparation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPreparation.Controls.Add(this.tableLayoutPanel2);
            this.gbPreparation.Location = new System.Drawing.Point(3, 3);
            this.gbPreparation.Name = "gbPreparation";
            this.gbPreparation.Size = new System.Drawing.Size(1161, 771);
            this.gbPreparation.TabIndex = 0;
            this.gbPreparation.TabStop = false;
            this.gbPreparation.Text = "Preparation";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelBuildQuery, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1123, 711);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 4);
            this.tabControl1.Controls.Add(this.tabPageRecordsResult);
            this.tabControl1.Controls.Add(this.tabPageUsersResult);
            this.tabControl1.Location = new System.Drawing.Point(3, 372);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 336);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPageRecordsResult
            // 
            this.tabPageRecordsResult.Controls.Add(this.checkedListBoxRecordsResult);
            this.tabPageRecordsResult.Location = new System.Drawing.Point(4, 33);
            this.tabPageRecordsResult.Name = "tabPageRecordsResult";
            this.tabPageRecordsResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecordsResult.Size = new System.Drawing.Size(1109, 299);
            this.tabPageRecordsResult.TabIndex = 0;
            this.tabPageRecordsResult.Text = "Records result (preview)";
            this.tabPageRecordsResult.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxRecordsResult
            // 
            this.checkedListBoxRecordsResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxRecordsResult.FormattingEnabled = true;
            this.checkedListBoxRecordsResult.Location = new System.Drawing.Point(6, 6);
            this.checkedListBoxRecordsResult.Name = "checkedListBoxRecordsResult";
            this.checkedListBoxRecordsResult.Size = new System.Drawing.Size(1097, 268);
            this.checkedListBoxRecordsResult.TabIndex = 0;
            // 
            // tabPageUsersResult
            // 
            this.tabPageUsersResult.Controls.Add(this.checkedListBoxUsersResult);
            this.tabPageUsersResult.Location = new System.Drawing.Point(4, 33);
            this.tabPageUsersResult.Name = "tabPageUsersResult";
            this.tabPageUsersResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsersResult.Size = new System.Drawing.Size(1109, 299);
            this.tabPageUsersResult.TabIndex = 1;
            this.tabPageUsersResult.Text = "Users result (preview)";
            this.tabPageUsersResult.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxUsersResult
            // 
            this.checkedListBoxUsersResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxUsersResult.FormattingEnabled = true;
            this.checkedListBoxUsersResult.Location = new System.Drawing.Point(6, 11);
            this.checkedListBoxUsersResult.Name = "checkedListBoxUsersResult";
            this.checkedListBoxUsersResult.Size = new System.Drawing.Size(1097, 268);
            this.checkedListBoxUsersResult.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRetrieveRecordsFetchQuery);
            this.panel1.Controls.Add(this.tbRecordsRetrieved);
            this.panel1.Controls.Add(this.tbUsersRetrieved);
            this.panel1.Controls.Add(this.btnRetrieveUsers);
            this.panel1.Location = new System.Drawing.Point(564, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 363);
            this.panel1.TabIndex = 25;
            // 
            // btnRetrieveRecordsFetchQuery
            // 
            this.btnRetrieveRecordsFetchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveRecordsFetchQuery.Enabled = false;
            this.btnRetrieveRecordsFetchQuery.Location = new System.Drawing.Point(3, 3);
            this.btnRetrieveRecordsFetchQuery.Name = "btnRetrieveRecordsFetchQuery";
            this.btnRetrieveRecordsFetchQuery.Size = new System.Drawing.Size(549, 50);
            this.btnRetrieveRecordsFetchQuery.TabIndex = 25;
            this.btnRetrieveRecordsFetchQuery.Text = "Retrieve records";
            this.btnRetrieveRecordsFetchQuery.UseVisualStyleBackColor = true;
            this.btnRetrieveRecordsFetchQuery.Click += new System.EventHandler(this.btnRetrieveRecordsFetchQuery_Click);
            // 
            // tbRecordsRetrieved
            // 
            this.tbRecordsRetrieved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordsRetrieved.Location = new System.Drawing.Point(3, 59);
            this.tbRecordsRetrieved.Multiline = true;
            this.tbRecordsRetrieved.Name = "tbRecordsRetrieved";
            this.tbRecordsRetrieved.ReadOnly = true;
            this.tbRecordsRetrieved.Size = new System.Drawing.Size(549, 107);
            this.tbRecordsRetrieved.TabIndex = 26;
            // 
            // tbUsersRetrieved
            // 
            this.tbUsersRetrieved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUsersRetrieved.Location = new System.Drawing.Point(3, 231);
            this.tbUsersRetrieved.Multiline = true;
            this.tbUsersRetrieved.Name = "tbUsersRetrieved";
            this.tbUsersRetrieved.ReadOnly = true;
            this.tbUsersRetrieved.Size = new System.Drawing.Size(549, 98);
            this.tbUsersRetrieved.TabIndex = 28;
            // 
            // btnRetrieveUsers
            // 
            this.btnRetrieveUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveUsers.Location = new System.Drawing.Point(0, 175);
            this.btnRetrieveUsers.Name = "btnRetrieveUsers";
            this.btnRetrieveUsers.Size = new System.Drawing.Size(556, 50);
            this.btnRetrieveUsers.TabIndex = 27;
            this.btnRetrieveUsers.Text = "Retrieve active users";
            this.btnRetrieveUsers.UseVisualStyleBackColor = true;
            this.btnRetrieveUsers.Click += new System.EventHandler(this.btnRetrieveUsers_Click);
            // 
            // panelBuildQuery
            // 
            this.panelBuildQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuildQuery.Controls.Add(this.labelChooseView);
            this.panelBuildQuery.Controls.Add(this.labelChooseEntity);
            this.panelBuildQuery.Controls.Add(this.comboBoxChooseView);
            this.panelBuildQuery.Controls.Add(this.comboBoxChooseEntity);
            this.panelBuildQuery.Controls.Add(this.label1);
            this.panelBuildQuery.Controls.Add(this.radioButtonBuildQuery);
            this.panelBuildQuery.Controls.Add(this.radioButtonQueryView);
            this.panelBuildQuery.Controls.Add(this.btnOpenFXB);
            this.panelBuildQuery.Location = new System.Drawing.Point(3, 3);
            this.panelBuildQuery.Name = "panelBuildQuery";
            this.panelBuildQuery.Size = new System.Drawing.Size(555, 363);
            this.panelBuildQuery.TabIndex = 31;
            // 
            // labelChooseView
            // 
            this.labelChooseView.AutoSize = true;
            this.labelChooseView.Location = new System.Drawing.Point(18, 257);
            this.labelChooseView.Name = "labelChooseView";
            this.labelChooseView.Size = new System.Drawing.Size(168, 25);
            this.labelChooseView.TabIndex = 32;
            this.labelChooseView.Text = "Choose the view :";
            this.labelChooseView.Visible = false;
            // 
            // labelChooseEntity
            // 
            this.labelChooseEntity.AutoSize = true;
            this.labelChooseEntity.Location = new System.Drawing.Point(18, 141);
            this.labelChooseEntity.Name = "labelChooseEntity";
            this.labelChooseEntity.Size = new System.Drawing.Size(463, 25);
            this.labelChooseEntity.TabIndex = 31;
            this.labelChooseEntity.Text = "Choose the Entity you want to migrate records from :";
            this.labelChooseEntity.Visible = false;
            // 
            // comboBoxChooseView
            // 
            this.comboBoxChooseView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChooseView.FormattingEnabled = true;
            this.comboBoxChooseView.Location = new System.Drawing.Point(10, 294);
            this.comboBoxChooseView.Name = "comboBoxChooseView";
            this.comboBoxChooseView.Size = new System.Drawing.Size(542, 32);
            this.comboBoxChooseView.Sorted = true;
            this.comboBoxChooseView.TabIndex = 30;
            this.comboBoxChooseView.Visible = false;
            this.comboBoxChooseView.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseView_SelectedIndexChanged);
            // 
            // comboBoxChooseEntity
            // 
            this.comboBoxChooseEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChooseEntity.FormattingEnabled = true;
            this.comboBoxChooseEntity.Location = new System.Drawing.Point(10, 185);
            this.comboBoxChooseEntity.Name = "comboBoxChooseEntity";
            this.comboBoxChooseEntity.Size = new System.Drawing.Size(542, 32);
            this.comboBoxChooseEntity.Sorted = true;
            this.comboBoxChooseEntity.TabIndex = 29;
            this.comboBoxChooseEntity.Visible = false;
            this.comboBoxChooseEntity.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseEntity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Choose how do you want to query your records :";
            // 
            // radioButtonBuildQuery
            // 
            this.radioButtonBuildQuery.AutoSize = true;
            this.radioButtonBuildQuery.Checked = true;
            this.radioButtonBuildQuery.Location = new System.Drawing.Point(10, 60);
            this.radioButtonBuildQuery.Name = "radioButtonBuildQuery";
            this.radioButtonBuildQuery.Size = new System.Drawing.Size(217, 29);
            this.radioButtonBuildQuery.TabIndex = 26;
            this.radioButtonBuildQuery.TabStop = true;
            this.radioButtonBuildQuery.Text = "Build query with FXB";
            this.radioButtonBuildQuery.UseVisualStyleBackColor = true;
            this.radioButtonBuildQuery.CheckedChanged += new System.EventHandler(this.radioButtonBuildQuery_CheckedChanged);
            // 
            // radioButtonQueryView
            // 
            this.radioButtonQueryView.AutoSize = true;
            this.radioButtonQueryView.Location = new System.Drawing.Point(268, 59);
            this.radioButtonQueryView.Name = "radioButtonQueryView";
            this.radioButtonQueryView.Size = new System.Drawing.Size(184, 29);
            this.radioButtonQueryView.TabIndex = 25;
            this.radioButtonQueryView.TabStop = true;
            this.radioButtonQueryView.Text = "Query with views";
            this.radioButtonQueryView.UseVisualStyleBackColor = true;
            this.radioButtonQueryView.CheckedChanged += new System.EventHandler(this.radioButtonQueryView_CheckedChanged);
            // 
            // btnOpenFXB
            // 
            this.btnOpenFXB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFXB.Location = new System.Drawing.Point(0, 122);
            this.btnOpenFXB.Name = "btnOpenFXB";
            this.btnOpenFXB.Size = new System.Drawing.Size(555, 214);
            this.btnOpenFXB.TabIndex = 24;
            this.btnOpenFXB.Text = "Build your record query with \r\nFetchXMLBuilder\r\n";
            this.btnOpenFXB.UseVisualStyleBackColor = true;
            this.btnOpenFXB.Click += new System.EventHandler(this.btnOpenFXB_Click);
            // 
            // gpMigration
            // 
            this.gpMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMigration.Controls.Add(this.tableLayoutPanel3);
            this.gpMigration.Location = new System.Drawing.Point(1170, 3);
            this.gpMigration.Name = "gpMigration";
            this.gpMigration.Size = new System.Drawing.Size(494, 771);
            this.gpMigration.TabIndex = 2;
            this.gpMigration.TabStop = false;
            this.gpMigration.Text = "Migration";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMigrateRecordBPF, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 42);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(482, 711);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnLoadBPFs);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbTargetBPFList);
            this.panel2.Controls.Add(this.cbTargetBPFStages);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 267);
            this.panel2.TabIndex = 0;
            // 
            // btnLoadBPFs
            // 
            this.btnLoadBPFs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadBPFs.Enabled = false;
            this.btnLoadBPFs.Location = new System.Drawing.Point(9, 2);
            this.btnLoadBPFs.Name = "btnLoadBPFs";
            this.btnLoadBPFs.Size = new System.Drawing.Size(456, 66);
            this.btnLoadBPFs.TabIndex = 9;
            this.btnLoadBPFs.Text = "Load BPFs";
            this.btnLoadBPFs.UseVisualStyleBackColor = true;
            this.btnLoadBPFs.Click += new System.EventHandler(this.btnLoadBPFs_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Target Stage :";
            // 
            // cbTargetBPFList
            // 
            this.cbTargetBPFList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTargetBPFList.Enabled = false;
            this.cbTargetBPFList.FormattingEnabled = true;
            this.cbTargetBPFList.Location = new System.Drawing.Point(20, 109);
            this.cbTargetBPFList.Name = "cbTargetBPFList";
            this.cbTargetBPFList.Size = new System.Drawing.Size(445, 32);
            this.cbTargetBPFList.Sorted = true;
            this.cbTargetBPFList.TabIndex = 15;
            this.cbTargetBPFList.SelectedIndexChanged += new System.EventHandler(this.cbTargetBPFList_SelectedIndexChanged);
            // 
            // cbTargetBPFStages
            // 
            this.cbTargetBPFStages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTargetBPFStages.Enabled = false;
            this.cbTargetBPFStages.FormattingEnabled = true;
            this.cbTargetBPFStages.Location = new System.Drawing.Point(17, 182);
            this.cbTargetBPFStages.Name = "cbTargetBPFStages";
            this.cbTargetBPFStages.Size = new System.Drawing.Size(448, 32);
            this.cbTargetBPFStages.Sorted = true;
            this.cbTargetBPFStages.TabIndex = 17;
            this.cbTargetBPFStages.SelectedIndexChanged += new System.EventHandler(this.cbTargetBPFStages_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(292, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Target Business Process Flow : ";
            // 
            // btnMigrateRecordBPF
            // 
            this.btnMigrateRecordBPF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMigrateRecordBPF.Enabled = false;
            this.btnMigrateRecordBPF.Location = new System.Drawing.Point(3, 276);
            this.btnMigrateRecordBPF.Name = "btnMigrateRecordBPF";
            this.btnMigrateRecordBPF.Size = new System.Drawing.Size(476, 432);
            this.btnMigrateRecordBPF.TabIndex = 19;
            this.btnMigrateRecordBPF.Text = "Migrate !";
            this.btnMigrateRecordBPF.UseVisualStyleBackColor = true;
            this.btnMigrateRecordBPF.Click += new System.EventHandler(this.btnMigrateRecordBPF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 537);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "opp list";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(697, 464);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(238, 32);
            this.comboBox5.TabIndex = 19;
            // 
            // BPFManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "BPFManager";
            this.Size = new System.Drawing.Size(1701, 855);
            this.Load += new System.EventHandler(this.BPFMigration_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbPreparation.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRecordsResult.ResumeLayout(false);
            this.tabPageUsersResult.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBuildQuery.ResumeLayout(false);
            this.panelBuildQuery.PerformLayout();
            this.gpMigration.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbPreparation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button btnOpenFXB;
        private System.Windows.Forms.Button btnRetrieveRecordsFetchQuery;
        private System.Windows.Forms.GroupBox gpMigration;
        private System.Windows.Forms.TextBox tbUsersRetrieved;
        private System.Windows.Forms.Button btnRetrieveUsers;
        private System.Windows.Forms.Button btnMigrateRecordBPF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTargetBPFStages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTargetBPFList;
        private System.Windows.Forms.Button btnLoadBPFs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRecordsResult;
        private System.Windows.Forms.TabPage tabPageUsersResult;
        private System.Windows.Forms.TextBox tbRecordsRetrieved;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBuildQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonBuildQuery;
        private System.Windows.Forms.RadioButton radioButtonQueryView;
        private System.Windows.Forms.Label labelChooseView;
        private System.Windows.Forms.Label labelChooseEntity;
        private System.Windows.Forms.ComboBox comboBoxChooseView;
        private System.Windows.Forms.ComboBox comboBoxChooseEntity;
        private System.Windows.Forms.CheckedListBox checkedListBoxRecordsResult;
        private System.Windows.Forms.CheckedListBox checkedListBoxUsersResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOptions;
    }
}
