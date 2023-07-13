using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Horizon.Hudu.Toolbox.Services
{
    public class SettingsService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly ILogger<SettingsService> _logger;

        public SettingsService(ILogger<SettingsService> logger)
        {
            this._logger = logger;
        }

        public string HuduURL
        {
            get => Properties.Settings.Default.HuduURL;
            set
            {
                Properties.Settings.Default.HuduURL = value;
                Properties.Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public string HuduAPIKey
        {
            get => Properties.Settings.Default.HuduAPIKey;
            set
            {
                Properties.Settings.Default.HuduAPIKey = value;
                Properties.Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public IList<RewriteUrlSettingsEntry> LinkRewrites
        {
            get
            {
                IList<RewriteUrlSettingsEntry> rewrites = null;
                try
                {
                    rewrites = JsonSerializer.Deserialize<IList<RewriteUrlSettingsEntry>>(Properties.Settings.Default.LinkRewrites);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Error while deserializing link rewrites");
                }
                return rewrites ?? new List<RewriteUrlSettingsEntry>();
            }
            set
            {
                Properties.Settings.Default.LinkRewrites = JsonSerializer.Serialize(value);
                Properties.Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
