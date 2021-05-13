using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelMap.Solutions;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModelMap.EntityFrameworkCore.EntityConfigurations.Solutions
{
    class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(ModelMapConsts.DbTablePrefix + "Projects", ModelMapConsts.DbSchema);
            builder.ConfigureByConvention();
        }
    }
}
