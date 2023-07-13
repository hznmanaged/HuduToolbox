using Horizon.Hudu.Controllers;
using Horizon.Hudu.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Hudu
{
    public class HuduAPIClient: IDisposable
    {
        private readonly string ApiKey;
        public readonly string URL;
        private bool disposedValue;

        public readonly ArticlesController Articles;
        public readonly AssetsController Assets;
        public readonly AssetLayoutsController AssetLayouts;
        public readonly CompaniesController Companies;
        public readonly FoldersController Folders;

        public HuduAPIClient(string url, string apiKey)
        {
            if(String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if(String.IsNullOrWhiteSpace(apiKey))   throw new ArgumentNullException(nameof(apiKey));
            this.URL = url;
            this.ApiKey = apiKey;

            this.Articles = new ArticlesController(this);
            this.Assets = new AssetsController(this);
            this.AssetLayouts = new AssetLayoutsController(this);
            this.Companies = new CompaniesController(this);
            this.Folders = new FoldersController(this);
        }


        /// <summary>
        /// Translates relative URLs for data objects into absolute URLs using the client's current URL.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetObjectAbsoluteURL(IHuduURL input)
            => GetAbsoluteURL(input.URL);


        /// <summary>
        /// Translates relative URLs for data objects into absolute URLs using the client's current URL.
        /// </summary>
        /// <param name="partialUrl"></param>
        /// <returns></returns>
        public string GetAbsoluteURL(string partialUrl)
        {
            if (UriTools.IsAbsoluteUri(partialUrl))
            {
                return partialUrl;
            }
            return StringTools.CombineURI(this.URL, partialUrl);
        }

        internal RestClient InstantiateRestClient()
            => disposedValue ? throw new ObjectDisposedException(nameof(HuduAPIClient)) : 
            new RestClient(apiKey: this.ApiKey);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HuduAPIClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
