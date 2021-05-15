using IdentityModel.OidcClient.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserInfoResult> GetUserInfoAsync();

        Task<bool> LoginAsync();

        Task LogoutAsync();

        Task RefreshTokenAsync();
    }
}
