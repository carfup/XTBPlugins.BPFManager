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
            this.tssCancel = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbPreparation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRemainingLabel = new System.Windows.Forms.Label();
            this.labelTimeEstimation = new System.Windows.Forms.Label();
            this.labelRecordsRemaining = new System.Windows.Forms.Label();
            this.labelNumberOfRecordsToMigrate = new System.Windows.Forms.Label();
            this.labelHasPermissions = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRetrieveRecordsFetchQuery = new System.Windows.Forms.Button();
            this.tbRecordsRetrieved = new System.Windows.Forms.TextBox();
            this.panelBuildQuery = new System.Windows.Forms.Panel();
            this.labelChooseView = new System.Windows.Forms.Label();
            this.labelChooseEntity = new System.Windows.Forms.Label();
            this.comboBoxChooseView = new System.Windows.Forms.ComboBox();
            this.comboBoxChooseEntity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonBuildQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonQueryView = new System.Windows.Forms.RadioButton();
            this.btnOpenFXB = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxPatience = new System.Windows.Forms.PictureBox();
            this.gpMigration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTargetStageEntityDiff = new System.Windows.Forms.Label();
            this.btnLoadBPFs = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTargetBPFList = new System.Windows.Forms.ComboBox();
            this.cbTargetBPFStages = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMigrateRecordBPF = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbEnabledDisabledRecordsNo = new System.Windows.Forms.RadioButton();
            this.rbEnabledDisabledRecordsYes = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.toolStripMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbPreparation.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBuildQuery.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatience)).BeginInit();
            this.gpMigration.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.toolStripButtonOptions,
            this.tssCancel,
            this.tsbCancel});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(928, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.close;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(64, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonOptions
            // 
            this.toolStripButtonOptions.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.gear;
            this.toolStripButtonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOptions.Name = "toolStripButtonOptions";
            this.toolStripButtonOptions.Size = new System.Drawing.Size(77, 28);
            this.toolStripButtonOptions.Text = "Options";
            this.toolStripButtonOptions.Click += new System.EventHandler(this.toolStripButtonOptions_Click);
            // 
            // tssCancel
            // 
            this.tssCancel.Name = "tssCancel";
            this.tssCancel.Size = new System.Drawing.Size(6, 31);
            this.tssCancel.Visible = false;
            // 
            // tsbCancel
            // 
            this.tsbCancel.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.cancel;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(71, 28);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 421F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 421);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // gbPreparation
            // 
            this.gbPreparation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPreparation.Controls.Add(this.tableLayoutPanel2);
            this.gbPreparation.Location = new System.Drawing.Point(2, 2);
            this.gbPreparation.Margin = new System.Windows.Forms.Padding(2);
            this.gbPreparation.Name = "gbPreparation";
            this.gbPreparation.Padding = new System.Windows.Forms.Padding(2);
            this.gbPreparation.Size = new System.Drawing.Size(632, 417);
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
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelBuildQuery, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(612, 384);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.groupBoxDetails);
            this.panel4.Location = new System.Drawing.Point(308, 170);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(302, 212);
            this.panel4.TabIndex = 33;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxDetails.Location = new System.Drawing.Point(2, 8);
            this.groupBoxDetails.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDetails.Size = new System.Drawing.Size(298, 206);
            this.groupBoxDetails.TabIndex = 2;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Details";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelRemainingLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelTimeEstimation, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelRecordsRemaining, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelNumberOfRecordsToMigrate, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelHasPermissions, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 188);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // labelRemainingLabel
            // 
            this.labelRemainingLabel.AutoSize = true;
            this.labelRemainingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemainingLabel.Location = new System.Drawing.Point(2, 149);
            this.labelRemainingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRemainingLabel.Name = "labelRemainingLabel";
            this.labelRemainingLabel.Size = new System.Drawing.Size(287, 17);
            this.labelRemainingLabel.TabIndex = 3;
            this.labelRemainingLabel.Text = "Records remaing :";
            this.labelRemainingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimeEstimation
            // 
            this.labelTimeEstimation.AutoSize = true;
            this.labelTimeEstimation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTimeEstimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeEstimation.Location = new System.Drawing.Point(2, 127);
            this.labelTimeEstimation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeEstimation.Name = "labelTimeEstimation";
            this.labelTimeEstimation.Size = new System.Drawing.Size(287, 17);
            this.labelTimeEstimation.TabIndex = 2;
            this.labelTimeEstimation.Text = "This can take up to X time.";
            this.labelTimeEstimation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRecordsRemaining
            // 
            this.labelRecordsRemaining.AutoSize = true;
            this.labelRecordsRemaining.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelRecordsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordsRemaining.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelRecordsRemaining.Location = new System.Drawing.Point(2, 166);
            this.labelRecordsRemaining.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRecordsRemaining.Name = "labelRecordsRemaining";
            this.labelRecordsRemaining.Size = new System.Drawing.Size(287, 22);
            this.labelRecordsRemaining.TabIndex = 3;
            this.labelRecordsRemaining.Text = "0";
            this.labelRecordsRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNumberOfRecordsToMigrate
            // 
            this.labelNumberOfRecordsToMigrate.AutoSize = true;
            this.labelNumberOfRecordsToMigrate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelNumberOfRecordsToMigrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfRecordsToMigrate.Location = new System.Drawing.Point(2, 102);
            this.labelNumberOfRecordsToMigrate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberOfRecordsToMigrate.Name = "labelNumberOfRecordsToMigrate";
            this.labelNumberOfRecordsToMigrate.Size = new System.Drawing.Size(287, 20);
            this.labelNumberOfRecordsToMigrate.TabIndex = 1;
            this.labelNumberOfRecordsToMigrate.Text = "The migration will handle : X records.";
            this.labelNumberOfRecordsToMigrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHasPermissions
            // 
            this.labelHasPermissions.AutoSize = true;
            this.labelHasPermissions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHasPermissions.Location = new System.Drawing.Point(2, 0);
            this.labelHasPermissions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHasPermissions.Name = "labelHasPermissions";
            this.labelHasPermissions.Size = new System.Drawing.Size(287, 26);
            this.labelHasPermissions.TabIndex = 4;
            this.labelHasPermissions.Text = "Please make sure that you have the proper permissions on the Target BPF";
            this.labelHasPermissions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRetrieveRecordsFetchQuery);
            this.panel1.Controls.Add(this.tbRecordsRetrieved);
            this.panel1.Location = new System.Drawing.Point(308, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 164);
            this.panel1.TabIndex = 25;
            // 
            // btnRetrieveRecordsFetchQuery
            // 
            this.btnRetrieveRecordsFetchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieveRecordsFetchQuery.Enabled = false;
            this.btnRetrieveRecordsFetchQuery.Location = new System.Drawing.Point(2, 2);
            this.btnRetrieveRecordsFetchQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnRetrieveRecordsFetchQuery.Name = "btnRetrieveRecordsFetchQuery";
            this.btnRetrieveRecordsFetchQuery.Size = new System.Drawing.Size(298, 94);
            this.btnRetrieveRecordsFetchQuery.TabIndex = 25;
            this.btnRetrieveRecordsFetchQuery.Text = "Retrieve records";
            this.btnRetrieveRecordsFetchQuery.UseVisualStyleBackColor = true;
            this.btnRetrieveRecordsFetchQuery.Click += new System.EventHandler(this.btnRetrieveRecordsFetchQuery_Click);
            // 
            // tbRecordsRetrieved
            // 
            this.tbRecordsRetrieved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordsRetrieved.Location = new System.Drawing.Point(1, 99);
            this.tbRecordsRetrieved.Margin = new System.Windows.Forms.Padding(2);
            this.tbRecordsRetrieved.Multiline = true;
            this.tbRecordsRetrieved.Name = "tbRecordsRetrieved";
            this.tbRecordsRetrieved.ReadOnly = true;
            this.tbRecordsRetrieved.Size = new System.Drawing.Size(300, 63);
            this.tbRecordsRetrieved.TabIndex = 26;
            // 
            // panelBuildQuery
            // 
            this.panelBuildQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuildQuery.Controls.Add(this.labelChooseView);
            this.panelBuildQuery.Controls.Add(this.labelChooseEntity);
            this.panelBuildQuery.Controls.Add(this.comboBoxChooseView);
            this.panelBuildQuery.Controls.Add(this.comboBoxChooseEntity);
            this.panelBuildQuery.Controls.Add(this.label1);
            this.panelBuildQuery.Controls.Add(this.radioButtonBuildQuery);
            this.panelBuildQuery.Controls.Add(this.radioButtonQueryView);
            this.panelBuildQuery.Controls.Add(this.btnOpenFXB);
            this.panelBuildQuery.Location = new System.Drawing.Point(2, 2);
            this.panelBuildQuery.Margin = new System.Windows.Forms.Padding(2);
            this.panelBuildQuery.Name = "panelBuildQuery";
            this.panelBuildQuery.Size = new System.Drawing.Size(302, 164);
            this.panelBuildQuery.TabIndex = 31;
            // 
            // labelChooseView
            // 
            this.labelChooseView.AutoSize = true;
            this.labelChooseView.Location = new System.Drawing.Point(10, 118);
            this.labelChooseView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseView.Name = "labelChooseView";
            this.labelChooseView.Size = new System.Drawing.Size(93, 13);
            this.labelChooseView.TabIndex = 32;
            this.labelChooseView.Text = "Choose the View :";
            this.labelChooseView.Visible = false;
            // 
            // labelChooseEntity
            // 
            this.labelChooseEntity.AutoSize = true;
            this.labelChooseEntity.Location = new System.Drawing.Point(10, 66);
            this.labelChooseEntity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseEntity.Name = "labelChooseEntity";
            this.labelChooseEntity.Size = new System.Drawing.Size(96, 13);
            this.labelChooseEntity.TabIndex = 31;
            this.labelChooseEntity.Text = "Choose the Entity :";
            this.labelChooseEntity.Visible = false;
            // 
            // comboBoxChooseView
            // 
            this.comboBoxChooseView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChooseView.FormattingEnabled = true;
            this.comboBoxChooseView.Location = new System.Drawing.Point(5, 139);
            this.comboBoxChooseView.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseView.Name = "comboBoxChooseView";
            this.comboBoxChooseView.Size = new System.Drawing.Size(296, 21);
            this.comboBoxChooseView.TabIndex = 30;
            this.comboBoxChooseView.Visible = false;
            this.comboBoxChooseView.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseView_SelectedIndexChanged);
            // 
            // comboBoxChooseEntity
            // 
            this.comboBoxChooseEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChooseEntity.FormattingEnabled = true;
            this.comboBoxChooseEntity.Location = new System.Drawing.Point(5, 88);
            this.comboBoxChooseEntity.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxChooseEntity.Name = "comboBoxChooseEntity";
            this.comboBoxChooseEntity.Size = new System.Drawing.Size(296, 21);
            this.comboBoxChooseEntity.Sorted = true;
            this.comboBoxChooseEntity.TabIndex = 29;
            this.comboBoxChooseEntity.Visible = false;
            this.comboBoxChooseEntity.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseEntity_SelectedIndexChanged);
            this.comboBoxChooseEntity.Click += new System.EventHandler(this.comboBoxChooseEntity_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Choose how do you want to query your records :";
            // 
            // radioButtonBuildQuery
            // 
            this.radioButtonBuildQuery.AutoSize = true;
            this.radioButtonBuildQuery.Location = new System.Drawing.Point(144, 35);
            this.radioButtonBuildQuery.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBuildQuery.Name = "radioButtonBuildQuery";
            this.radioButtonBuildQuery.Size = new System.Drawing.Size(122, 17);
            this.radioButtonBuildQuery.TabIndex = 26;
            this.radioButtonBuildQuery.Text = "Build query with FXB";
            this.radioButtonBuildQuery.UseVisualStyleBackColor = true;
            this.radioButtonBuildQuery.CheckedChanged += new System.EventHandler(this.radioButtonBuildQuery_CheckedChanged);
            // 
            // radioButtonQueryView
            // 
            this.radioButtonQueryView.AutoSize = true;
            this.radioButtonQueryView.Location = new System.Drawing.Point(10, 35);
            this.radioButtonQueryView.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonQueryView.Name = "radioButtonQueryView";
            this.radioButtonQueryView.Size = new System.Drawing.Size(105, 17);
            this.radioButtonQueryView.TabIndex = 25;
            this.radioButtonQueryView.Text = "Query with views";
            this.radioButtonQueryView.UseVisualStyleBackColor = true;
            this.radioButtonQueryView.CheckedChanged += new System.EventHandler(this.radioButtonQueryView_CheckedChanged);
            // 
            // btnOpenFXB
            // 
            this.btnOpenFXB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFXB.Location = new System.Drawing.Point(0, 66);
            this.btnOpenFXB.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenFXB.Name = "btnOpenFXB";
            this.btnOpenFXB.Size = new System.Drawing.Size(302, 93);
            this.btnOpenFXB.TabIndex = 24;
            this.btnOpenFXB.Text = "Build your record query with \r\nFetchXMLBuilder\r\n";
            this.btnOpenFXB.UseVisualStyleBackColor = true;
            this.btnOpenFXB.Click += new System.EventHandler(this.btnOpenFXB_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pictureBoxPatience);
            this.panel3.Location = new System.Drawing.Point(2, 170);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 212);
            this.panel3.TabIndex = 32;
            // 
            // pictureBoxPatience
            // 
            this.pictureBoxPatience.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPatience.Image = global::Carfup.XTBPlugins.BPFManager.Properties.Resources.patience;
            this.pictureBoxPatience.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPatience.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxPatience.Name = "pictureBoxPatience";
            this.pictureBoxPatience.Size = new System.Drawing.Size(295, 209);
            this.pictureBoxPatience.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPatience.TabIndex = 0;
            this.pictureBoxPatience.TabStop = false;
            this.pictureBoxPatience.Visible = false;
            // 
            // gpMigration
            // 
            this.gpMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMigration.Controls.Add(this.tableLayoutPanel3);
            this.gpMigration.Location = new System.Drawing.Point(638, 2);
            this.gpMigration.Margin = new System.Windows.Forms.Padding(2);
            this.gpMigration.Name = "gpMigration";
            this.gpMigration.Padding = new System.Windows.Forms.Padding(2);
            this.gpMigration.Size = new System.Drawing.Size(269, 417);
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
            this.tableLayoutPanel3.Controls.Add(this.btnMigrateRecordBPF, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(263, 384);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.lblTargetStageEntityDiff);
            this.panel2.Controls.Add(this.btnLoadBPFs);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbTargetBPFList);
            this.panel2.Controls.Add(this.cbTargetBPFStages);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 150);
            this.panel2.TabIndex = 0;
            // 
            // lblTargetStageEntityDiff
            // 
            this.lblTargetStageEntityDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetStageEntityDiff.AutoSize = true;
            this.lblTargetStageEntityDiff.ForeColor = System.Drawing.Color.Red;
            this.lblTargetStageEntityDiff.Location = new System.Drawing.Point(3, 124);
            this.lblTargetStageEntityDiff.Name = "lblTargetStageEntityDiff";
            this.lblTargetStageEntityDiff.Size = new System.Drawing.Size(322, 26);
            this.lblTargetStageEntityDiff.TabIndex = 19;
            this.lblTargetStageEntityDiff.Text = "Target Entity stage and Primary Entity of the BPF are different.\r\nMake sure the r" +
    "elated Lookup is filled before moving the this stage.\r\n";
            this.lblTargetStageEntityDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTargetStageEntityDiff.Visible = false;
            // 
            // btnLoadBPFs
            // 
            this.btnLoadBPFs.AutoSize = true;
            this.btnLoadBPFs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadBPFs.Enabled = false;
            this.btnLoadBPFs.Location = new System.Drawing.Point(0, 0);
            this.btnLoadBPFs.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadBPFs.Name = "btnLoadBPFs";
            this.btnLoadBPFs.Size = new System.Drawing.Size(259, 36);
            this.btnLoadBPFs.TabIndex = 9;
            this.btnLoadBPFs.Text = "Load BPFs";
            this.btnLoadBPFs.UseVisualStyleBackColor = true;
            this.btnLoadBPFs.Click += new System.EventHandler(this.btnLoadBPFs_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Target Stage :";
            // 
            // cbTargetBPFList
            // 
            this.cbTargetBPFList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTargetBPFList.Enabled = false;
            this.cbTargetBPFList.FormattingEnabled = true;
            this.cbTargetBPFList.Location = new System.Drawing.Point(11, 59);
            this.cbTargetBPFList.Margin = new System.Windows.Forms.Padding(2);
            this.cbTargetBPFList.Name = "cbTargetBPFList";
            this.cbTargetBPFList.Size = new System.Drawing.Size(244, 21);
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
            this.cbTargetBPFStages.Location = new System.Drawing.Point(9, 99);
            this.cbTargetBPFStages.Margin = new System.Windows.Forms.Padding(2);
            this.cbTargetBPFStages.Name = "cbTargetBPFStages";
            this.cbTargetBPFStages.Size = new System.Drawing.Size(245, 21);
            this.cbTargetBPFStages.Sorted = true;
            this.cbTargetBPFStages.TabIndex = 17;
            this.cbTargetBPFStages.SelectedIndexChanged += new System.EventHandler(this.cbTargetBPFStages_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Target Business Process Flow : ";
            // 
            // btnMigrateRecordBPF
            // 
            this.btnMigrateRecordBPF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMigrateRecordBPF.Enabled = false;
            this.btnMigrateRecordBPF.Location = new System.Drawing.Point(2, 200);
            this.btnMigrateRecordBPF.Margin = new System.Windows.Forms.Padding(2);
            this.btnMigrateRecordBPF.Name = "btnMigrateRecordBPF";
            this.btnMigrateRecordBPF.Size = new System.Drawing.Size(259, 182);
            this.btnMigrateRecordBPF.TabIndex = 19;
            this.btnMigrateRecordBPF.Text = "Migrate !";
            this.btnMigrateRecordBPF.UseVisualStyleBackColor = true;
            this.btnMigrateRecordBPF.Click += new System.EventHandler(this.btnMigrateRecordBPF_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.rbEnabledDisabledRecordsNo);
            this.panel5.Controls.Add(this.rbEnabledDisabledRecordsYes);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(3, 157);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 38);
            this.panel5.TabIndex = 20;
            // 
            // rbEnabledDisabledRecordsNo
            // 
            this.rbEnabledDisabledRecordsNo.AutoSize = true;
            this.rbEnabledDisabledRecordsNo.Checked = true;
            this.rbEnabledDisabledRecordsNo.Enabled = false;
            this.rbEnabledDisabledRecordsNo.Location = new System.Drawing.Point(206, 9);
            this.rbEnabledDisabledRecordsNo.Name = "rbEnabledDisabledRecordsNo";
            this.rbEnabledDisabledRecordsNo.Size = new System.Drawing.Size(39, 17);
            this.rbEnabledDisabledRecordsNo.TabIndex = 2;
            this.rbEnabledDisabledRecordsNo.TabStop = true;
            this.rbEnabledDisabledRecordsNo.Text = "No";
            this.rbEnabledDisabledRecordsNo.UseVisualStyleBackColor = true;
            // 
            // rbEnabledDisabledRecordsYes
            // 
            this.rbEnabledDisabledRecordsYes.AutoSize = true;
            this.rbEnabledDisabledRecordsYes.Enabled = false;
            this.rbEnabledDisabledRecordsYes.Location = new System.Drawing.Point(250, 9);
            this.rbEnabledDisabledRecordsYes.Name = "rbEnabledDisabledRecordsYes";
            this.rbEnabledDisabledRecordsYes.Size = new System.Drawing.Size(43, 17);
            this.rbEnabledDisabledRecordsYes.TabIndex = 1;
            this.rbEnabledDisabledRecordsYes.Text = "Yes";
            this.rbEnabledDisabledRecordsYes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enable disabled records/aborted BPFs ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 291);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "opp list";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(380, 251);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(132, 21);
            this.comboBox5.TabIndex = 19;
            // 
            // BPFManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "BPFManager";
            this.Size = new System.Drawing.Size(928, 463);
            this.Load += new System.EventHandler(this.BPFMigration_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbPreparation.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBuildQuery.ResumeLayout(false);
            this.panelBuildQuery.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatience)).EndInit();
            this.gpMigration.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Button btnMigrateRecordBPF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTargetBPFStages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTargetBPFList;
        private System.Windows.Forms.Button btnLoadBPFs;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOptions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBoxPatience;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label labelRecordsRemaining;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelRemainingLabel;
        private System.Windows.Forms.Label labelTimeEstimation;
        private System.Windows.Forms.Label labelNumberOfRecordsToMigrate;
        private System.Windows.Forms.Label labelHasPermissions;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator tssCancel;
        private System.Windows.Forms.Label lblTargetStageEntityDiff;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbEnabledDisabledRecordsNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEnabledDisabledRecordsYes;
    }
}
