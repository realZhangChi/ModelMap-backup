using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ModelMap.Desktop.Services.Setting;
using System;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.NavigationService
{
    public class NavigationService : INavigationService, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISettingService _settingService;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _settingService = _serviceProvider.GetRequiredService<ISettingService>();
        }

        public Page Initialize()
        {
            if (string.IsNullOrWhiteSpace(_settingService.AccessToken))
            {
                return _serviceProvider.GetRequiredService<LoginPage>();
            }

            return _serviceProvider.GetRequiredService<MainPage>();
        }
    }
}
