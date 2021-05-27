using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.OmniSharp
{
    public class OmniSharpService : IOmniSharpService, ITransientDependency
    {
        private const string InstallPath = ".omnisharp";
        private const string ExeName = "OmniSharp.exe";

        private readonly IOmniSharpDownloader _omniSharpDownloader;

        public OmniSharpService(IOmniSharpDownloader omniSharpDownloader)
        {
            _omniSharpDownloader = omniSharpDownloader;
        }

        public async Task StartAsync(string solutionPath)
        {
            var installPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name,
                InstallPath);
            var omniSharpPath = Path.Combine(@"C:\Users\Chi\Desktop\omnisharp.http-win-x64", ExeName);
            if (!System.IO.File.Exists(omniSharpPath))
            {
                await _omniSharpDownloader.DownloadAndInstallAsync(installPath);
            }
            var info = new ProcessStartInfo()
            {
                FileName = omniSharpPath,
                Arguments = $"-s {solutionPath}",
                UseShellExecute = false
            };
            var process = new Process()
            {
                StartInfo = info
            };
            process.Start();
        }
    }
}
