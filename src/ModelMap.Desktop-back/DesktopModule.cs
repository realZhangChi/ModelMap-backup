using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.IdentityModel;
using Volo.Abp.Modularity;

namespace ModelMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAutoMapperModule),
        typeof(ModelMapHttpApiClientModule),
        typeof(AbpHttpClientModule),
        typeof(AbpIdentityModelModule)
        )]
    public class DesktopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DesktopModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ModelMapDesktopAutoMapProfile>(validate: true);
            });

            context.Services.AddSingleton<MainWindow>();
            context.Services.AddBlazorWebView();
        }
    }
}

