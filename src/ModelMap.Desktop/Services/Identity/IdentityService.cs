using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Results;
using Microsoft.Extensions.Configuration;
using ModelMap.Desktop.Services.Setting;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.Identity
{
    public class IdentityService : IIdentityService, ITransientDependency
    {
        private readonly OidcClient _oidcClient;

        private readonly ISettingService _settingService;

        public IdentityService(
            IConfiguration configuration,
            ISettingService settingService,
            IServiceProvider serviceProvider)
        {
            _settingService = settingService;

            var options = new OidcClientOptions()
            {
                Authority = configuration["AuthServer:Authority"],
                ClientId = configuration["AuthServer:ClientId"],
                Scope = configuration["AuthServer:Scope"],
                RedirectUri = $"{configuration["AuthServer:RootUrl"].RemovePostFix("/")}/authentication/login-callback",
                Browser = new LoginBrowser(),
                Policy = new Policy
                {
                    RequireIdentityTokenSignature = false
                }
            };
            _oidcClient = new OidcClient(options);
        }

        public Task<UserInfoResult> GetUserInfoAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync()
        {
            var loginResult = await _oidcClient.LoginAsync();
            if (loginResult.IsError)
            {
                // TODO: handle login error
                return false;
            }

            _settingService.AccessToken = loginResult.AccessToken;
            _settingService.RefreshToken = loginResult.RefreshToken;
            _settingService.IdentityToken = loginResult.IdentityToken;
            _settingService.AccessTokenExpirationUnixTimeSeconds = loginResult.AccessTokenExpiration.ToUnixTimeSeconds();
            return true;
        }

        public Task LogoutAsync()
        {
            return _oidcClient.LogoutAsync(
                new LogoutRequest()
                {
                    BrowserDisplayMode = IdentityModel.OidcClient.Browser.DisplayMode.Hidden,
                    IdTokenHint = _settingService.IdentityToken
                });
        }

        public async Task RefreshTokenAsync()
        {
            var refreshToken = _settingService.RefreshToken;
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return;
            }

            var refreshResult = await _oidcClient.RefreshTokenAsync(_settingService.RefreshToken);

            if (refreshResult.IsError)
            {
                // TODO: handle Error
                return;
            }

            _settingService.AccessToken = refreshResult.AccessToken;
            _settingService.RefreshToken = refreshResult.RefreshToken;
            _settingService.AccessTokenExpirationUnixTimeSeconds = refreshResult.AccessTokenExpiration.ToUnixTimeSeconds();
        }
    }
}
