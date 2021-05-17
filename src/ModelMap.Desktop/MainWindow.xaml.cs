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
        }

        private async void WindowLoadedAsync(object sender, RoutedEventArgs e)
        {
            _ = MSBuildLocator.RegisterDefaults();
            //using (var workspace = MSBuildWorkspace.Create())
            //{
            //    //var solution = await workspace.OpenSolutionAsync(@"C:\Users\Chi\source\repos\Acme.BookStore\aspnet-core\Acme.BookStore.sln");
            //    var project1 = await workspace.OpenProjectAsync(@"C:\Users\Chi\source\repos\Acme.BookStore\aspnet-core\src\Acme.BookStore.Application\Acme.BookStore.Application.csproj");

            //    var solution1 = project1.AddDocument("Foo.cs", "public class Foo { }", filePath: @"C:\Users\Chi\source\repos\Acme.BookStore\aspnet-core\src\Acme.BookStore.Application\").Project.Solution;
            //    workspace.TryApplyChanges(solution1);
            //    //foreach (var project in solution.Projects)
            //    //{
            //    //    var compilation = await project.GetCompilationAsync();

            //    //    // Perform analysis...
            //    //}
            //}
            if (!string.IsNullOrWhiteSpace(_serviceProvider.GetRequiredService<ISettingService>()?.AccessToken))
            {
                return;
            }

            var identityServer = _serviceProvider.GetRequiredService<IIdentityService>();
            await identityServer.LoginAsync();
        }
    }
}
