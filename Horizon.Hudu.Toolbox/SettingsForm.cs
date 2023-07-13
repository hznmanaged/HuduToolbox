using Horizon.Hudu.Toolbox.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon.Hudu.Toolbox
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settingsService;

        public SettingsForm(SettingsService settingsService)
        {
            this._settingsService = settingsService;
            InitializeComponent();
            huduUrlTxt.Text = _settingsService.HuduURL;
            huduApiKeyTxt.Text = _settingsService.HuduAPIKey;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _settingsService.HuduURL = huduUrlTxt.Text;
            _settingsService.HuduAPIKey = huduApiKeyTxt.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
