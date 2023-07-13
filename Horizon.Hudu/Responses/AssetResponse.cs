using Horizon.Hudu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Horizon.Hudu.Responses
{
    internal class AssetResponse
    {
        [JsonPropertyName("asset")]
        public Asset Asset { get; set; }
    }
}
