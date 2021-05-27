using Microsoft.Win32;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.File
{
    public class FileService : IFileService, ITransientDependency
    {
        public Task<string> SelectFileAsync()
        {
            return Task.Run(() =>
            {
                //var openFileDialog = new OpenFileDialog();
                //openFileDialog.DefaultExt = ".sln";
                //openFileDialog.Title = "Select a solution";
                //openFileDialog.Filter = "Solution Files (*.sln)|*.sln";

                //var result = openFileDialog.ShowDialog();
                //if (result == true)
                //{
                //    return openFileDialog.FileName;
                //}
                return string.Empty;
            });
        }
    }
}
