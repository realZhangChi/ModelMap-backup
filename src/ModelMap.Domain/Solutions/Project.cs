using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Volo.Abp.Domain.Entities;

namespace ModelMap.Solutions
{
    public class Project : Entity<Guid>
    {
        public virtual Guid SolutionId { get; set; }

        [Required]
        [MaxLength(SolutionConsts.PathMaxLength)]
        public virtual string RelativePath { get; protected set; }

        [NotMapped]
        public virtual string Name => Path.GetFileNameWithoutExtension(RelativePath);

        public virtual Solution Solution { get; set; }

        protected Project()
        {

        }
    }
}
