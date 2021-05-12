using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ModelMap.EntityFrameworkCore
{
    [DependsOn(
        typeof(ModelMapEntityFrameworkCoreModule)
        )]
    public class ModelMapEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ModelMapMigrationsDbContext>();
        }
    }
}
