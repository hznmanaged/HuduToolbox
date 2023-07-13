using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox
{
    public class RewriteUrlSettingsEntry
    {
        public string SearchRegex { get; set; }
        public string ReplacementPattern { get; set; }
        public string ReplacementDisplayPattern { get; set; }


        public string GenerateReplacementOutput(string input)
            => GenerateOutput(input: input, outputPattern: ReplacementPattern);
        public string GenerateReplacementDisplayOutput(string input)
            => GenerateOutput(input: input, outputPattern:
                String.IsNullOrWhiteSpace(ReplacementDisplayPattern) ? 
                    ReplacementPattern : ReplacementDisplayPattern);

        private string GenerateOutput(string input, string outputPattern)
        {
            var pattern = new Regex(SearchRegex);
            var match = pattern.Match(input);

            var builder = new StringBuilder(outputPattern);

            for(int i = 0; i <= match.Groups.Count; i++)
            {
                builder.Replace("${" + i + "}", match.Groups[i].Value);
            }
            return builder.ToString();
        }
    }
}
