using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace ModelMap.Diagrams
{
    public class PropertyDefine : Entity<Guid>
    {
        [Required]
        [MaxLength(DiagramConsts.AccessLevelMaxLength)]
        public string AccessLevel { get; private set; }

        [Required]
        [MaxLength(DiagramConsts.TypeNameMaxLength)]
        public string Type { get; private set; }

        [Required]
        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(DiagramConsts.AccessLevelMaxLength)]
        public string GetAccessLevel { get; private set; }

        [Required]
        [MaxLength(DiagramConsts.AccessLevelMaxLength)]
        public string SetAccessLevel { get; private set; }

        public virtual Guid EntityComponentId { get; protected set; }
        public virtual EntityComponent EntityComponent { get; protected set; }

        protected PropertyDefine()
        {

        }

        protected internal PropertyDefine(
            Guid id,
            Guid entityId,
            string accessLevel,
            [NotNull] string type,
            [NotNull] string name,
            string getAccessLevel,
            string setAccessLevel) : base(id)
        {
            _ = Check.NotNullOrWhiteSpace(type, nameof(type), DiagramConsts.TypeNameMaxLength);
            _ = Check.NotNullOrWhiteSpace(name, nameof(name), DiagramConsts.ClassNameMaxLength);

            // TODO: AccessLevel Define
            EntityComponentId = entityId;
            AccessLevel = string.IsNullOrWhiteSpace(accessLevel) ? "public" : accessLevel;
            Type = type;
            Name = name;
            GetAccessLevel = string.IsNullOrWhiteSpace(getAccessLevel) ? string.Empty : getAccessLevel;
            SetAccessLevel = string.IsNullOrWhiteSpace(setAccessLevel) ? string.Empty : setAccessLevel;
        }
    }
}
