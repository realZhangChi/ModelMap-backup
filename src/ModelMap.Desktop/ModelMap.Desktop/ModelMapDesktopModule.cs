using Microsoft.Extensions.DependencyInjection;
using ModelMap.Desktop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ModelMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule))]
    public class ModelMapDesktopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            context.Services.AddBlazorWebView();
            context.Services.AddSingleton<WeatherForecastService>();
        }
    }
}
