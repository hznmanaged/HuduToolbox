using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Hudu
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task ThrowIfNotSuccess(this HttpResponseMessage message)
        {
            if(!message.IsSuccessStatusCode)
            {
                var responseContent = await message.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Server sent an error response: ({message.StatusCode}) {responseContent}");

            }
        }
    }
}
