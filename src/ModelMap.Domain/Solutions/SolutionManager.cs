using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace ModelMap.Solutions
{
    public class SolutionManager : DomainService, ISolutionManager
    {
        protected ISolutionRepository Repository => LazyServiceProvider.LazyGetRequiredService<ISolutionRepository>();
        protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

        public async Task<Solution> CreateAsync(string absolutePath)
        {
            await ValidatePathAsync(absolutePath);
            return new Solution(GuidGenerator.Create(), absolutePath);
        }

        private async Task ValidatePathAsync(string path)
        {
            // TODO: throw error when path is not absolute path
            var exist = await Repository.AnyAsync(s => s.CreatorId == CurrentUser.Id && s.AbsolutePath == path);
            if (exist)
            {
                throw new SolutionAlreadyExistsException();
            }
        }
    }
}
