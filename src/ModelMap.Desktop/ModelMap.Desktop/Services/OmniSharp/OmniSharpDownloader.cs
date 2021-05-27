using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.OmniSharp
{
    public class OmniSharpDownloader : IOmniSharpDownloader, ITransientDependency
    {
        private const string ServerUrl = "https://github.com";
        private const string LatestVersionFileServerPath = "releases/versioninfo.txt";
        // TODO: get platform info https://github.com/OmniSharp/omnisharp-roslyn/releases/download/v1.37.9/omnisharp-mono.zip
        private const string Platform = "mono";

        private readonly HttpClient _httpClient;

        public OmniSharpDownloader(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(ServerUrl);
            _httpClient = httpClient;
        }

        public async Task DownloadAndInstallAsync(string installPath)
        {
            var fileName = $"omnisharp-mono.zip";
            //var latestVersion = await _httpClient.GetStringAsync(LatestVersionFileServerPath);
            //var downloadUrl = $"releases/1.37.9/{fileName}";
            var downloadUrl = "OmniSharp/omnisharp-roslyn/releases/download/v1.37.4/omnisharp-mono.zip";

            var response = await _httpClient.GetAsync(downloadUrl);
            if (!response.IsSuccessStatusCode)
            {
                // TODO: handle error
                throw new NotImplementedException();
            }

            var stream = await response.Content.ReadAsStreamAsync();
            var zipFilePath = Path.Combine(installPath, fileName);
            _ = Directory.CreateDirectory(Path.GetDirectoryName(zipFilePath));
            using var fs = new FileStream(zipFilePath, FileMode.CreateNew);
            await stream.CopyToAsync(fs);
            await fs.FlushAsync();
            fs.Close();
            ZipFile.ExtractToDirectory(zipFilePath, installPath);
        }
    }
}
