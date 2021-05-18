using IdentityModel.OidcClient;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using ModelMap.Desktop.Services.Identity;
using ModelMap.Desktop.Services.Setting;
using System;
using System.Windows;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Build.Locator;
using System.Linq;

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
            _ = MSBuildLocator.RegisterDefaults();
        }
    }
}
