using Horizon.Hudu.Sync;
using Horizon.Hudu.Toolbox.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeDetective;

namespace Horizon.Hudu.Toolbox
{
    internal static class Program
    {

        private static IServiceProvider ServiceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Program.ServiceProvider = serviceCollection.BuildServiceProvider();
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddLoggingInterceptor()
                .AddLogging(configure => configure.AddConsole().AddDebug().AddInterceptor())
                .AddSingleton<ServiceHelpers>()
                .AddTransient<HuduAPIClient>((sp) => {
                        var settings = sp.GetRequiredService<SettingsService>();
                        var logging = sp.GetRequiredService<ILogger<HuduAPIClient>>();
                        if (string.IsNullOrWhiteSpace(settings.HuduURL))
                        {
                            logging.LogError("Hudu URL not set, click Settings button to set it.");
                        }
                        if (string.IsNullOrWhiteSpace(settings.HuduAPIKey))
                        {
                            logging.LogError("Hudu API Key not set, click Settings button to set it.");
                        }
                        return new HuduAPIClient(url: settings.HuduURL, apiKey: settings.HuduAPIKey);
                    })
                .AddTransient<ImageImportService>()
                .AddTransient<HuduCardSyncService>()
                .AddTransient<UrlRewriteService>()
                .AddTransient<BrokenImageReportService>()
                .AddSingleton<SettingsService>()
                .AddSingleton<ContentInspector>((sp) => new ContentInspectorBuilder()
                        {
                            Definitions = new MimeDetective.Definitions.ExhaustiveBuilder()
                            {
                                UsageType = MimeDetective.Definitions.Licensing.UsageType.PersonalNonCommercial
                            }.Build()
                }.Build())
                .AddScoped<Form1>()
                .AddTransient<SettingsForm>()
                .AddTransient<RewriteUrlSettingsForm>();
        }
    }
}