using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using ModelMap.Desktop.Services.NavigationService;
using System;
using Volo.Abp;
using Application = Microsoft.Maui.Controls.Application;

namespace ModelMap.Desktop
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IAbpApplicationWithExternalServiceProvider application, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            application.Initialize(_serviceProvider);
            InitializeComponent();
        }

        protected override IWindow CreateWindow(IActivationState activationState)
        {
            Microsoft.Maui.Controls.Compatibility.Forms.Init(activationState);

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>()
                .SetImageDirectory("Assets");

            var page = _serviceProvider.GetRequiredService<INavigationService>().Initialize();
            return new Microsoft.Maui.Controls.Window(page);
        }
    }
}
