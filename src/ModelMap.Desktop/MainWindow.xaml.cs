using IdentityModel.OidcClient;
using Microsoft.Extensions.DependencyInjection;
using ModelMap.Desktop.Services.Identity;
using System;
using System.Windows;

namespace ModelMap.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Resources.Add("services", serviceProvider);
            InitializeComponent();
        }

        private async void WindowLoadedAsync(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.AccessToken))
            {
                return;
            }

            var identityServer = _serviceProvider.GetRequiredService<IIdentityService>();
            await identityServer.LoginAsync();
        }
    }
}
