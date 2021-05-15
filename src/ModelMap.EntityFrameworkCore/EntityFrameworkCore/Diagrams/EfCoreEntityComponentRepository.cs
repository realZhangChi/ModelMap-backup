using ModelMap.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ModelMap.EntityFrameworkCore.Diagrams
{
    public class EfCoreEntityComponentRepository : EfCoreRepository<ModelMapDbContext, EntityComponent, Guid>, IEntityComponentRepository
    {

        public EfCoreEntityComponentRepository(IDbContextProvider<ModelMapDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
