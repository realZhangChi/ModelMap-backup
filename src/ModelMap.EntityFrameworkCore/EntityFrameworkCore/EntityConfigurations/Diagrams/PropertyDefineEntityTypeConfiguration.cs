using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelMap.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModelMap.EntityFrameworkCore.EntityConfigurations.Diagrams
{
    class PropertyDefineEntityTypeConfiguration : IEntityTypeConfiguration<PropertyDefine>
    {
        public void Configure(EntityTypeBuilder<PropertyDefine> builder)
        {
            builder.ToTable(ModelMapConsts.DbTablePrefix + "PropertyDefines", ModelMapConsts.DbSchema);
            builder.ConfigureByConvention();
        }
    }
}
