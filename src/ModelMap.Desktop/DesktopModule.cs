using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;
using Volo.Abp.Modularity;

namespace ModelMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ModelMapHttpApiClientModule),
        typeof(AbpHttpClientModule),
        typeof(AbpIdentityModelModule)
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

