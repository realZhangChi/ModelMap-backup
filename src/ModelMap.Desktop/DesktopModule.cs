using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ModelMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule)
        )]
    public class DesktopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<MainWindow>();
            context.Services.AddBlazorWebView();
        }
    }
}

