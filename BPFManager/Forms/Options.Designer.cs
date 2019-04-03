namespace Carfup.XTBPlugins.Forms
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownNumberOfRecordsPerRound = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bgStats = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkboxAllowStats = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRecordsPerRound)).BeginInit();
            this.bgStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.numericUpDownNumberOfRecordsPerRound);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(737, 150);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // numericUpDownNumberOfRecordsPerRound
            // 
            this.numericUpDownNumberOfRecordsPerRound.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNumberOfRecordsPerRound.Location = new System.Drawing.Point(293, 44);
            this.numericUpDownNumberOfRecordsPerRound.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownNumberOfRecordsPerRound.Name = "numericUpDownNumberOfRecordsPerRound";
            this.numericUpDownNumberOfRecordsPerRound.Size = new System.Drawing.Size(396, 29);
            this.numericUpDownNumberOfRecordsPerRound.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of records per call :";
            // 
            // bgStats
            // 
            this.bgStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bgStats.Controls.Add(this.label2);
            this.bgStats.Controls.Add(this.checkboxAllowStats);
            this.bgStats.Location = new System.Drawing.Point(15, 177);
            this.bgStats.Margin = new System.Windows.Forms.Padding(6);
            this.bgStats.Name = "bgStats";
            this.bgStats.Padding = new System.Windows.Forms.Padding(6);
            this.bgStats.Size = new System.Drawing.Size(737, 231);
            this.bgStats.TabIndex = 17;
            this.bgStats.TabStop = false;
            this.bgStats.Text = "Statistics";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(713, 131);
            this.label2.TabIndex = 6;
            this.label2.Text = "This plugin collects ONLY anonymous usage statistics. \r\nNo information related yo" +
    "ur CRM / Organization will be retrieve. \r\n\r\nThis will help us to improve the mos" +
    "t used features !\r\n";
            // 
            // checkboxAllowStats
            // 
            this.checkboxAllowStats.AutoSize = true;
            this.checkboxAllowStats.Checked = true;
            this.checkboxAllowStats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAllowStats.Location = new System.Drawing.Point(18, 174);
            this.checkboxAllowStats.Margin = new System.Windows.Forms.Padding(6);
            this.checkboxAllowStats.Name = "checkboxAllowStats";
            this.checkboxAllowStats.Size = new System.Drawing.Size(164, 29);
            this.checkboxAllowStats.TabIndex = 5;
            this.checkboxAllowStats.Text = "Allow statistics";
            this.checkboxAllowStats.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(614, 415);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 42);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(466, 415);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(138, 42);
            this.buttonOk.TabIndex = 18;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 473);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.bgStats);
            this.Controls.Add(this.groupBox3);
            this.Name = "Options";
            this.ShowIcon = false;
            this.Text = "Options";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRecordsPerRound)).EndInit();
            this.bgStats.ResumeLayout(false);
            this.bgStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRecordsPerRound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox bgStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkboxAllowStats;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}