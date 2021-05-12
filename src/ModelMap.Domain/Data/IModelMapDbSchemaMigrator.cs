using System.Threading.Tasks;

namespace ModelMap.Data
{
    public interface IModelMapDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
