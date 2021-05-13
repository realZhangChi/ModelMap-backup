using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.EntityFrameworkCore.EntityConfigurations.Diagrams
{
    internal static class DiagramModelCreatingExtensions
    {
        public static void ConfigureDiagramAggregate(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ApplyConfiguration(new EntityComponentEntityTypeConfiguration());
        }
    }
}
