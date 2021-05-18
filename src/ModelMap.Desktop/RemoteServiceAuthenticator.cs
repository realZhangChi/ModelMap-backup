using IdentityModel.Client;
using ModelMap.Desktop.Services.Identity;
using ModelMap.Desktop.Services.Setting;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.Authentication;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.IdentityModel;

namespace ModelMap.Desktop
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IRemoteServiceHttpClientAuthenticator))]
    public class RemoteServiceAuthenticator : IdentityModelRemoteServiceHttpClientAuthenticator, ITransientDependency
    {
        private readonly ISettingService _settingService;
        private readonly IIdentityService _identityService;

        public RemoteServiceAuthenticator(
            IIdentityModelAuthenticationService identityModelAuthenticationService,
            ISettingService settingService,
            IIdentityService identityService)
            : base(identityModelAuthenticationService)
        {
            _settingService = settingService;
            _identityService = identityService;
        }


        public override async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            if (context.RemoteService.GetUseCurrentAccessToken() != false)
            {
                var expireAt = _settingService.AccessTokenExpirationUnixTimeSeconds;
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var minusResult = expireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (string.IsNullOrWhiteSpace(_settingService.AccessToken))
                {
                    await _identityService.LoginAsync();
                }
                else if (expireAt > 0 && expireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds() < 600)
                {
                    if (!await _identityService.RefreshTokenAsync())
                    {
                        await _identityService.LoginAsync();
                    }
                }

                var accessToken = _settingService.AccessToken;
                if (accessToken != null)
                {
                    context.Request.SetBearerToken(accessToken);
                    return;
                }
            }

            await base.Authenticate(context);
        }
    }
}
