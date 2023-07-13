using Horizon.Hudu.Toolbox.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon.Hudu.Toolbox
{
    public partial class RewriteUrlSettingsForm : Form
    {
        private readonly SettingsService _settingsService;
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<RewriteUrlSettingsForm> _logger;

        public RewriteUrlSettingsForm(SettingsService settingsService, ILogger<RewriteUrlSettingsForm> logger, IServiceProvider serviceProvider)
        {
            _settingsService = settingsService;
            _logger = logger;
            this.serviceProvider = serviceProvider;

            InitializeComponent();

            this.dataGridView1.UserDeletedRow += DataGridView1_UserDeletedRow;
            this.dataGridView1.DataSource = settingsService.LinkRewrites;

        }



        private void DataGridView1_UserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    var buttonColumn = (DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex];
                    var dataSource = (IList<RewriteUrlSettingsEntry>)dataGridView1.DataSource;
                    var entry = dataSource[e.RowIndex];
                    switch (buttonColumn.Text)
                    {
                        case "Delete":
                            dataSource.Remove(entry);
                            _settingsService.LinkRewrites = dataSource;
                            dataGridView1.DataSource = _settingsService.LinkRewrites;
                            break;
                        case "Edit":
                            var editForm = new RewriteUrlSettingsEntryForm(entry);
                            var result = editForm.ShowDialog(this);
                            if (result == DialogResult.OK)
                            {
                                var newEntry = editForm.GetEntry();
                                dataSource[e.RowIndex] = newEntry;
                                _settingsService.LinkRewrites = dataSource;
                                dataGridView1.DataSource = _settingsService.LinkRewrites;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing url rewrites");
                MessageBox.Show(this, $"Error while editing url rewrites: {ex.Message}");
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var editForm = new RewriteUrlSettingsEntryForm();
                var result = editForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var newEntry = editForm.GetEntry();
                    var entries = _settingsService.LinkRewrites;
                    entries.Add(newEntry);
                    _settingsService.LinkRewrites = entries;
                    this.dataGridView1.DataSource = entries;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding url rewrite entry");
                MessageBox.Show(this, $"Error while adding url rewrite entry: {ex.Message}");
            }
        }
    }
}
