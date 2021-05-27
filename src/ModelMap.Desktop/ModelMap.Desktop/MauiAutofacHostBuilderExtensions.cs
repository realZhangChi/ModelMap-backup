using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using Volo.Abp.Autofac;

namespace ModelMap.Desktop
{
    public static class MauiAutofacHostBuilderExtensions
    {
        public static IAppHostBuilder UseMauiAutofac(this IAppHostBuilder hostBuilder)
        {
            var containerBuilder = new ContainerBuilder();

            return hostBuilder.ConfigureServices((_, services) =>
            {
                services.AddObjectAccessor(containerBuilder);
            })
            .UseServiceProviderFactory(new AbpAutofacServiceProviderFactory(containerBuilder));
        }
    }
}
