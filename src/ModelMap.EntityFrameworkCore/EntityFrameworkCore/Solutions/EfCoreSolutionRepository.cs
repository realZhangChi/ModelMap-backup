using Microsoft.EntityFrameworkCore;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ModelMap.EntityFrameworkCore.Solutions
{
    public class EfCoreSolutionRepository : EfCoreRepository<ModelMapDbContext, Solution, Guid>, ISolutionRepository
    {
        public EfCoreSolutionRepository(IDbContextProvider<ModelMapDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Solution>> GetListAsync(Guid? userId = null, int maxResultCount = int.MaxValue, int skipCount = 0)
        {
            return await (await GetDbSetAsync())
                .WhereIf(userId is not null, s => s.CreatorId == userId)
                .OrderByDescending(s => s.CreationTime)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync();
        }
    }
}
