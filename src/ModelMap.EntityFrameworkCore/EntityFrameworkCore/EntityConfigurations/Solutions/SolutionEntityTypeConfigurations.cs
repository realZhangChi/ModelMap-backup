using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelMap.Solutions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModelMap.EntityFrameworkCore.EntityConfigurations.Solutions
{
    class SolutionEntityTypeConfigurations : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.ToTable(ModelMapConsts.DbTablePrefix + "Solutions", ModelMapConsts.DbSchema);
            builder.ConfigureByConvention();


            var navigation = builder.Metadata.FindNavigation(nameof(Solution.Projects));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
