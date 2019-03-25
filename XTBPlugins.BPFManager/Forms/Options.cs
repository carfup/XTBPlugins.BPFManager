using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carfup.XTBPlugins.AppCode;

namespace Carfup.XTBPlugins.Forms
{
    public partial class Options : Form
    {

        private BPFManager.BPFManager bpfManager;
        public Options(BPFManager.BPFManager bpfMigration)
        {
            InitializeComponent();
            this.bpfManager = bpfMigration;
            PopulateSettings(this.bpfManager.settings);
        }

        private void PopulateSettings(PluginSettings settings)
        {
            if (settings == null)
            {
                settings = new PluginSettings();
            }

            checkboxAllowStats.Checked = settings.AllowLogUsage != false;
            numericUpDownNumberOfRecordsPerRound.Value = settings.NumberOfRecordPerRound;
        }

        internal PluginSettings GetSettings()
        {
            var settings = this.bpfManager.settings;
            settings.AllowLogUsage = checkboxAllowStats.Checked;
            settings.CurrentVersion = BPFManager.BPFManager.CurrentVersion;
            settings.NumberOfRecordPerRound = (int) numericUpDownNumberOfRecordsPerRound.Value;

            return settings;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.bpfManager.settings = GetSettings();
            this.bpfManager.SaveSettings();
            this.Close();
        }
    }
}
