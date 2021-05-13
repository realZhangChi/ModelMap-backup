using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ModelMap.Solutions
{
    public class Solution : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        [MaxLength(SolutionConsts.PathMaxLength)]
        public virtual string AbsolutePath { get; private set; }

        [NotMapped]
        public virtual string Name => Path.GetFileNameWithoutExtension(AbsolutePath);

        private readonly List<Project> _projects;
        public virtual IReadOnlyCollection<Project> Projects => _projects;

        protected Solution()
        {

        }

        public Solution(
            [NotNull] string absolutePath)
        {
            Check.NotNullOrWhiteSpace(absolutePath, nameof(absolutePath), SolutionConsts.PathMaxLength);

            if (!Path.HasExtension(absolutePath) || Path.GetExtension(absolutePath) != ".sln")
            {
                throw new SolutionPathInvalidException();
            }
            if (!File.Exists(absolutePath))
            {
                throw new SolutionDoesNotExistException();
            }

            AbsolutePath = absolutePath;
        }
    }
}
