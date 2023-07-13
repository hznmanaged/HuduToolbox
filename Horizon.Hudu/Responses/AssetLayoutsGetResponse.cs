using Horizon.Hudu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Horizon.Hudu.Responses
{
    internal class AssetLayoutsGetResponse
    {
        [JsonPropertyName("asset_layouts")]
        public IEnumerable<AssetLayout> AssetLayouts { get; set; }
    }
}
