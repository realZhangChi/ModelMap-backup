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
            [NotNull] string accessLevel,
            [NotNull] string type,
            [NotNull] string name,
            [NotNull] string getAccessLevel,
            [NotNull] string setAccessLevel) : base(id)
        {
            _ = Check.NotNullOrWhiteSpace(accessLevel, nameof(accessLevel), DiagramConsts.AccessLevelMaxLength);
            _ = Check.NotNullOrWhiteSpace(type, nameof(type), DiagramConsts.TypeNameMaxLength);
            _ = Check.NotNullOrWhiteSpace(name, nameof(name), DiagramConsts.ClassNameMaxLength);
            _ = Check.NotNullOrWhiteSpace(getAccessLevel, nameof(getAccessLevel), DiagramConsts.AccessLevelMaxLength);
            _ = Check.NotNullOrWhiteSpace(setAccessLevel, nameof(setAccessLevel), DiagramConsts.AccessLevelMaxLength);

            EntityComponentId = entityId;
            AccessLevel = accessLevel;
            Type = type;
            Name = name;
            GetAccessLevel = getAccessLevel;
            SetAccessLevel = setAccessLevel;
        }
    }
}
