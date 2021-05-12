using Volo.Abp.Modularity;

namespace ModelMap
{
    [DependsOn(
        typeof(ModelMapApplicationModule),
        typeof(ModelMapDomainTestModule)
        )]
    public class ModelMapApplicationTestModule : AbpModule
    {

    }
}