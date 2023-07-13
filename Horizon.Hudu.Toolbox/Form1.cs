using Horizon.Hudu.Toolbox.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Horizon.Hudu.Toolbox
{
    public partial class Form1 : Form
    {
        private readonly SettingsService settingsService;
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<Form1> logger;
        private readonly LoggingInterceptor loggingInterceptor;
        private CancellationTokenSource? cancellationTokenSource = null;

        public Form1(IServiceProvider serviceProvider, ILogger<Form1> logger,
            LoggingInterceptor loggingInterceptor, SettingsService settingsService)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            this.loggingInterceptor = loggingInterceptor;
            loggingInterceptor.OnLog += onLoggingIntercept;
            this.settingsService = settingsService;
        }

        private void WriteToOutput(String message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                textBox1.AppendText($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}: {message}");
                textBox1.AppendText(Environment.NewLine);
            }
        }

        private void onLoggingIntercept(object? sender, LoggingInterceptorEventArgs e)
        {
            WriteToOutput(e.FormattedMessage);
        }

        private SharedServiceSettings GetSharedServiceSettings()
            => new SharedServiceSettings()
            {
                IncludeArticles = chkProcessArticles.Checked,
                IncludeAssets = chkTargetAssets.Checked,
                SearchString = txtFilter.Text,
                DryRun = chkDryRun.Checked,
            };

        private async void btnImportImages_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkHuduCredentials()) return;
                this.textBox1.Text = "";

                setEnabledness(false);
                cancellationTokenSource = new CancellationTokenSource();
                var service = serviceProvider.GetRequiredService<ImageImportService>();
                await service.Run(settings: GetSharedServiceSettings(),
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while running image import");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
                setEnabledness(true);
            }
        }

        private void setEnabledness(bool enabled)
        {

            foreach (object child in buttonGroupBox.Controls)
            {
                if (child is Control childControl)
                {
                    childControl.Enabled = enabled;
                }
            }

            foreach (object child in grpNameFilter.Controls)
            {
                if (child is Control childControl)
                {
                    childControl.Enabled = enabled;
                }
            }

            foreach (object child in grpBoxTargets.Controls)
            {
                if (child is Control childControl)
                {
                    childControl.Enabled = enabled;
                }
            }

            btnCancel.Visible = !enabled;
            btnCancel.Enabled = !enabled;

            settingsBtn.Enabled = enabled;
            aboutBtn.Enabled = enabled;

        }

        private async void btnUrlRewrite_Click(object sender, EventArgs e)
        {


            try
            {
                if (!checkHuduCredentials()) return;
                this.textBox1.Text = "";
                setEnabledness(false);
                cancellationTokenSource = new CancellationTokenSource();
                var service = serviceProvider.GetRequiredService<UrlRewriteService>();
                await service.Run(settings: GetSharedServiceSettings(),
                    settingsService.LinkRewrites,
                    cancellationToken: cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while running URL rewrite");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
                setEnabledness(true);
            }
        }

        private async void btnBrokenImageReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkHuduCredentials()) return;
                this.textBox1.Text = "";

                setEnabledness(false);
                cancellationTokenSource = new CancellationTokenSource();
                var service = serviceProvider.GetRequiredService<BrokenImageReportService>();
                var result = await service.Run(settings: GetSharedServiceSettings(),
                    cancellationToken: cancellationTokenSource.Token);

                if (!String.IsNullOrWhiteSpace(result))
                {
                    saveFileDialog1.Title = "Save Broken image report";
                    var timestamp = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
                    saveFileDialog1.FileName = $"Broken image report {StringTools.SanitizeForFileName(timestamp)}.html";
                    var dialogResult = saveFileDialog1.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, result);
                        logger.LogInformation($"Saved report to {saveFileDialog1.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while running broken image report");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
                setEnabledness(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource?.Cancel();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while running broken image report");
            }
        }

        private bool checkHuduCredentials()
        {
            if (String.IsNullOrWhiteSpace(settingsService.HuduURL) ||
                String.IsNullOrWhiteSpace(settingsService.HuduAPIKey))
            {
                settingsBtn_Click(this, new EventArgs());
                return false;
            }
            return true;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            var form = serviceProvider.GetRequiredService<SettingsForm>();
            form.ShowDialog(this);
        }

        private void rewriteUrlSettingsPic_Click(object sender, EventArgs e)
        {
            var form = serviceProvider.GetRequiredService<RewriteUrlSettingsForm>();
            form.ShowDialog(this);
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog(this);
        }
    }
}