using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.OmniSharp
{
    public interface IOmniSharpDownloader
    {
        Task DownloadAndInstallAsync(string installPath);
    }
}
