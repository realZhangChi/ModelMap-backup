using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.Setting
{
    public interface ISettingService
    {
        string AccessToken { get; set; }

        string RefreshToken { get; set; }

        string IdentityToken { get; set; }

        long AccessTokenExpirationUnixTimeSeconds { get; set; }
    }
}
