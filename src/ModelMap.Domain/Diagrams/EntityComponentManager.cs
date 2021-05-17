using JetBrains.Annotations;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace ModelMap.Diagrams
{
    public class EntityComponentManager : DomainService, IEntityComponentManager
    {
        public IEntityComponentRepository Repository => LazyServiceProvider.LazyGetRequiredService<IEntityComponentRepository>();

        public ISolutionRepository SolutionRepository => LazyServiceProvider.LazyGetRequiredService<ISolutionRepository>();

        public async Task<EntityComponent> CreateAsync(
            Guid solutionId,
            double top,
            double left,
            ICollection<string> imports,
            [NotNull] string namespaceBeloningTo,
            [NotNull] string projectRelativePath,
            [NotNull] string directory,
            [NotNull] string name,
            string baseClass,
            ICollection<string> baseInterfaces)
        {
            var solution = await SolutionRepository.FindAsync(solutionId);
            if (solution is null)
            {
                throw new SolutionDoesNotExistException();
            }

            var existing = await Repository.AnyAsync(e =>
                e.SolutionId == solutionId &&
                e.NamespaceBelongingTo == namespaceBeloningTo &&
                e.Name == name);
            if (existing)
            {
                throw new EntityAlreadyExistsException();
            }

            var entity = new EntityComponent(
                GuidGenerator.Create(),
                solution.Id,
                top,
                left,
                imports,
                namespaceBeloningTo,
                projectRelativePath,
                directory,
                name,
                baseClass,
                baseInterfaces,
                new List<PropertyDefine>()
                );

            return await Repository.InsertAsync(entity);
        }
    }
}
