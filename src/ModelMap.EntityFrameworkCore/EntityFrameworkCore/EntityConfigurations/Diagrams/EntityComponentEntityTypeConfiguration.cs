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
    class EntityComponentEntityTypeConfiguration : IEntityTypeConfiguration<EntityComponent>
    {
        public void Configure(EntityTypeBuilder<EntityComponent> builder)
        {
            builder.ToTable(ModelMapConsts.DbTablePrefix + "EntityComponents", ModelMapConsts.DbSchema);
            builder.ConfigureByConvention();

            builder.Property<string>("_imports")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Imports");

            builder.Property<string>("_baseInterfaces")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BaseInterfaces");

            builder.OwnsOne(n => n.Position, p =>
            {
                p.WithOwner();
                p.HasIndex(prop => prop.Top);
                p.HasIndex(prop => prop.Left);
            });

            var navigation = builder.Metadata.FindNavigation(nameof(EntityComponent.Properties));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
