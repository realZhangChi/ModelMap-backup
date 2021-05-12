using ModelMap.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ModelMap.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ModelMapEntityFrameworkCoreDbMigrationsModule),
        typeof(ModelMapApplicationContractsModule)
        )]
    public class ModelMapDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
