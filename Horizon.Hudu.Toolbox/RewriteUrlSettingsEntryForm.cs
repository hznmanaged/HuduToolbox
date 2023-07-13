using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon.Hudu.Toolbox
{
    public partial class RewriteUrlSettingsEntryForm : Form
    {

        public RewriteUrlSettingsEntryForm(RewriteUrlSettingsEntry? entry = null)
        {
            InitializeComponent();
            if (entry != null)
            {
                this.searchPatternText.Text = entry.SearchRegex;
                this.replacementPatternText.Text = entry.ReplacementPattern;
                this.replacementDisplayPatternText.Text = entry.ReplacementDisplayPattern;
            }
        }

        private bool ValidateInput()
        {
            if (String.IsNullOrWhiteSpace(this.searchPatternText.Text))
            {
                MessageBox.Show(this, text: "Search pattern is required");
                return false;
            }

            try
            {
                new Regex(this.searchPatternText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, text: "Search pattern is not a valid RegEx");
                return false;
            }

            if (String.IsNullOrWhiteSpace(this.replacementPatternText.Text))
            {
                MessageBox.Show(this, text: "Replacement pattern is required");
                return false;
            }
            return true;
        }

        public RewriteUrlSettingsEntry GetEntry()
        {
            return new RewriteUrlSettingsEntry()
            {
                ReplacementDisplayPattern = this.replacementDisplayPatternText.Text,
                ReplacementPattern = this.replacementPatternText.Text,
                SearchRegex = this.searchPatternText.Text,
            };
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.outputText.Text = "";
                this.displayOutputText.Text = "";
                if (!ValidateInput()) return;

                if (String.IsNullOrWhiteSpace(this.testText.Text))
                {
                    return;
                }
                var regex = new Regex(this.searchPatternText.Text);

                if (!regex.IsMatch(this.testText.Text))
                {
                    MessageBox.Show(this, text: "Search pattern does not match test text");
                    return;
                }
                var entry = GetEntry();


                this.outputText.Text = entry.GenerateReplacementOutput(this.testText.Text);
                this.displayOutputText.Text = entry.GenerateReplacementDisplayOutput(this.testText.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error while running test: {ex.Message}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error while adding url rewrite entry: {ex.Message}");
            }
        }
    }
}
