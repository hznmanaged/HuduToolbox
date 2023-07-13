using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox
{
    internal class ProcessReport : IDisposable
    {
        private List<ProcessReportSection> sections = new List<ProcessReportSection>();

        public ProcessReport() {

        }

        public override string ToString()
        {
            var str = new StringBuilder("<html><head></head><body>");
            foreach(var section in sections)
            {
                str.Append(section.ToString());
            }

            str.AppendLine("</body></html>");
            return str.ToString();
        }

        #region IDispose implementation
        private bool disposedValue;

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
        // ~ProcessReport()
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
        #endregion
    }

    internal class ProcessReportSection
    {
        internal List<string> entries = new List<string>();

        public override string ToString()
        {
            var sb = new StringBuilder("<ul>");

            foreach(var entry in entries)
            {
                sb.AppendLine("<li>"+entry.ToString()+"</li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }

}
