using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox
{
    public static class SharedData
    {

        public static Regex[] GetInternalImageRegexes(string serverUrl)
        {
            //var fullUrl = StringTools.CombineURI(serverURl, "api/attachment/image");

            if(!serverUrl.StartsWith("https://"))
            {
                throw new Exception("Only https servers are supported at present");
            }

            var serverUrlRegEx = new StringBuilder(serverUrl.Substring(8));
            serverUrlRegEx.Replace(".", "\\.");
            serverUrlRegEx.Replace(":", "\\:");
            serverUrlRegEx.Replace("/", "\\/");

            return new Regex[] {
                new Regex(@"^(https?\:\/\/)("  + serverUrlRegEx.ToString() +  @".+)$"),
                new Regex(@"^(https?\:\/\/)(hudu[^\.]+.[^\.]+\.digitaloceanspaces\.com\/.+)$"),
            };

        }
    }
}
