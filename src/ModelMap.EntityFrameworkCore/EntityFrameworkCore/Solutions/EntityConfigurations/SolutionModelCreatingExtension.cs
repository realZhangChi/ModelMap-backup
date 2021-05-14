using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ModelMap.EntityFrameworkCore.Solutions.EntityConfigurations
{
    internal static class SolutionModelCreatingExtension
    {
        public static void ConfigureSolutionAggregate(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ApplyConfiguration(new SolutionEntityTypeConfigurations());
            //builder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
        }
    }
}
