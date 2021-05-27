using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.Setting
{
    public class SettingService : ISettingService, ITransientDependency
    {
        public string AccessToken
        {
            get => Properties.Settings.Default.AccessToken;
            set
            {
                Properties.Settings.Default.AccessToken = value;
                Properties.Settings.Default.Save();
            }
        }

        public string RefreshToken
        {
            get => Properties.Settings.Default.RefreshToken;
            set
            {
                Properties.Settings.Default.RefreshToken = value;
                Properties.Settings.Default.Save();
            }
        }
        public string IdentityToken
        {
            get => Properties.Settings.Default.IdentityToken;
            set
            {
                Properties.Settings.Default.IdentityToken = value;
                Properties.Settings.Default.Save();
            }
        }

        public long AccessTokenExpirationUnixTimeSeconds
        {
            get => Properties.Settings.Default.AccessTokenExpiration;
            set
            {
                Properties.Settings.Default.AccessTokenExpiration = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
