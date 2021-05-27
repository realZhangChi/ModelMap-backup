using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Controls;
using ModelMap.Desktop.Services.Identity;
using ModelMap.Desktop.Services.Setting;
using ModelMap.Desktop.ViewModel.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.ViewModel
{
    public class LoginPageViewModel : ViewModelBase, ITransientDependency
    {
        private readonly IIdentityService _identityService;

        private readonly ISettingService _settingService;

        private readonly IConfiguration _configuration;

        public string AuthorizeUri { get; init; }

        public ICommand NavigateCommand => new Command<string>(async (url) => await NavigateAsync(url));

        public LoginPageViewModel(
            IIdentityService identityService,
            ISettingService settingService,
            IConfiguration configuration)
        {
            _identityService = identityService;
            _settingService = settingService;
            _configuration = configuration;
            AuthorizeUri = _identityService.CreateAuthorizationRequest();
        }


        private async Task NavigateAsync(string url)
        {
            var unescapedUrl = System.Net.WebUtility.UrlDecode(url);

            //if (unescapedUrl.Equals(GlobalSetting.Instance.LogoutCallback))
            //{
            //    _settingsService.AuthAccessToken = string.Empty;
            //    _settingsService.AuthIdToken = string.Empty;
            //    IsLogin = false;
            //    LoginUrl = _identityService.CreateAuthorizationRequest();
            //}
            //else 
            var rootUri = new Uri(_configuration["AuthServer:RootUrl"]);
            var callbackUri = new Uri(rootUri, _configuration["AuthServer:CallBackRoute"]);
            if (unescapedUrl.StartsWith(callbackUri.ToString()))
            {
                var authResponse = new AuthorizeResponse(url);
                if (!string.IsNullOrWhiteSpace(authResponse.Code))
                {
                    var userToken = await _identityService.GetTokenAsync(authResponse.Code);
                    string accessToken = userToken.AccessToken;

                    if (!string.IsNullOrWhiteSpace(accessToken))
                    {
                        _settingService.AccessToken = accessToken;
                        _settingService.IdentityToken = userToken.IdentityToken;
                        _settingService.ExpiresIn = userToken.ExpiresIn;
                        _settingService.RefreshToken = userToken.RefreshToken;
                        //await NavigationService.NavigateToAsync<MainViewModel>();
                        //await NavigationService.RemoveLastFromBackStackAsync();
                    }
                }
            }
        }
    }
}
