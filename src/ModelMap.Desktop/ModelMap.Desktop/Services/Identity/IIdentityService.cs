using ModelMap.Desktop.Models.Token;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();

        Task<UserToken> GetTokenAsync(string code);
    }
}
