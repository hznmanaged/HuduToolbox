using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox
{
    public class SharedServiceSettings
    {
        public bool IncludeArticles { get; set; }
        public bool IncludeAssets { get; set; }
        public string SearchString { get; set; }
        public bool DryRun { get; set; }
    }
}
