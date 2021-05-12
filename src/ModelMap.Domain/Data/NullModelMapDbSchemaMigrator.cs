using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Data
{
    /* This is used if database provider does't define
     * IModelMapDbSchemaMigrator implementation.
     */
    public class NullModelMapDbSchemaMigrator : IModelMapDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}