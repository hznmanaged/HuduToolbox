using Horizon.Hudu.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Horizon.Hudu.Responses
{
    internal class FolderResponse
    {
        [JsonPropertyName("folder")]
        public Folder Folder{ get; set; }
    }
}
