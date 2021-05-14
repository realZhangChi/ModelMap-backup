using IdentityModel.OidcClient;
using System;
using System.Windows;

namespace ModelMap.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            Resources.Add("services", serviceProvider);
            InitializeComponent();
        }

        private async void WindowLoadedAsync(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.AccessToken))
            {
                return;
            }
            var options = new OidcClientOptions()
            {
                // TODO: use configuration
                Authority = "https://localhost:44331",
                ClientId = "ModelMap_Desktop",
                Scope = "openid profile email offline_access ModelMap",
                RedirectUri = "http://127.0.0.1/authentication/login-callback",
                Browser = new WpfEmbeddedBrowser(),
                Policy = new Policy
                {
                    RequireIdentityTokenSignature = false
                }
            };

            var _oidcClient = new OidcClient(options);

            LoginResult loginResult;
            try
            {
                loginResult = await _oidcClient.LoginAsync();
            }
            catch (Exception exception)
            {
                return;
            }

            if (!loginResult.IsError)
            {
                // TODO: migrate to maui
                Properties.Settings.Default.AccessToken = loginResult.AccessToken;
                Properties.Settings.Default.Save();
            }
        }
    }
}
