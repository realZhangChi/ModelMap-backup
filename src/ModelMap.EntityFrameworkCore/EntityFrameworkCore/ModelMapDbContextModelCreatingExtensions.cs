using Microsoft.EntityFrameworkCore;
using ModelMap.EntityFrameworkCore.EntityConfigurations.Diagrams;
using ModelMap.EntityFrameworkCore.Solutions.EntityConfigurations;
using Volo.Abp;

namespace ModelMap.EntityFrameworkCore
{
    public static class ModelMapDbContextModelCreatingExtensions
    {
        public static void ConfigureModelMap(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ModelMapConsts.DbTablePrefix + "YourEntities", ModelMapConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            builder.ConfigureDiagramAggregate();
            builder.ConfigureSolutionAggregate();
        }
    }
}