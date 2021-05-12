using ModelMap.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ModelMap
{
    [DependsOn(
        typeof(ModelMapEntityFrameworkCoreTestModule)
        )]
    public class ModelMapDomainTestModule : AbpModule
    {

    }
}