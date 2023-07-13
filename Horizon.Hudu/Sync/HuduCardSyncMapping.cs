using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Hudu.Sync
{
    public interface IHuduCardSyncMapping
    {
        public int AssetLayoutID { get; }
        public string IntegratorID { get; }
        public int AssetFieldID { get; }
        public IEnumerable<string> CardPath { get; }
    }
}
