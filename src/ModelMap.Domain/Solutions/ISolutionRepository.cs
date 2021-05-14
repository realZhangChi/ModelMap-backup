using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ModelMap.Solutions
{
    public interface ISolutionRepository : IRepository<Solution, Guid>
    {
        Task<List<Solution>> GetListAsync(
            Guid? userId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0);
    }
}
