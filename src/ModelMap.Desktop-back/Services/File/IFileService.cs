using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.File
{
    public interface IFileService
    {
        Task<string> SelectFileAsync();
    }
}
