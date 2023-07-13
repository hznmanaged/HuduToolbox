using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Horizon.Hudu
{
    internal class RestClient: HttpClient
    {
        private string _apiKey;

        public RestClient(string apiKey)
        {
            _apiKey = apiKey;
            this.SetHeaders();
        }

        protected virtual void SetHeaders()
        {
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        // Hudu has a 300 requests/min rate limit
        private static DateTimeOffset? NextRequestTime = null;
        private static readonly TimeSpan MinimumTimeBetweenRequests = 
            new TimeSpan(ticks: (TimeSpan.TicksPerMinute/100));

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(NextRequestTime.HasValue && NextRequestTime > DateTimeOffset.UtcNow)
            {
                await Task.Delay(delay: MinimumTimeBetweenRequests);
            }
            

            var output =await base.SendAsync(request, cancellationToken);
            NextRequestTime = DateTimeOffset.UtcNow + MinimumTimeBetweenRequests;
            return output;
        }
    }
}
