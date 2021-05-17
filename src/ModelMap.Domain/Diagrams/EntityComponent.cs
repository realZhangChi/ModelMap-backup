using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.Diagrams
{
    public class EntityComponent : ComponentBase
    {
        public Guid SolutionId { get; private set; }

        [MaxLength(DiagramConsts.ArrayStringMaxLength)]
        public string _imports;
        public virtual IReadOnlyCollection<string> Imports => string.IsNullOrWhiteSpace(_imports) ? new List<string>() : _imports.Split(';');

        [Required]
        [MaxLength(DiagramConsts.NamespaceMaxLength)]
        public virtual string NamespaceBelongingTo { get; set; }

        [Required]
        [MaxLength(DiagramConsts.PathMaxLength)]
        public virtual string ProjectRelativePath { get; set; }

        [Required]
        [MaxLength(DiagramConsts.PathMaxLength)]
        public virtual string Directory { get; set; }

        [Required]
        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public virtual string Name { get; set; }

        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public virtual string BaseClass { get; set; }

        [MaxLength(DiagramConsts.ArrayStringMaxLength)]
        private string _baseInterfaces;
        public virtual IReadOnlyCollection<string> BaseInterfaces => string.IsNullOrWhiteSpace(_baseInterfaces) ? new List<string>() : _baseInterfaces.Split(';');

        private readonly List<PropertyDefine> _properties;
        public virtual IReadOnlyCollection<PropertyDefine> Properties => _properties;

        protected EntityComponent()
        {
            _properties = new List<PropertyDefine>();
        }

        protected internal EntityComponent(
            Guid id,
            Guid solutionId,
            double top,
            double left,
            ICollection<string> imports,
            [NotNull] string namespaceBeloningTo,
            [NotNull] string projectRelativePath,
            [NotNull] string directory,
            [NotNull] string name,
            [NotNull] string baseClass,
            ICollection<string> baseInterfaces,
            [NotNull] ICollection<PropertyDefine> properties
            ) : base(id, top, left)
        {
            _ = Check.NotNullOrWhiteSpace(namespaceBeloningTo, nameof(namespaceBeloningTo), DiagramConsts.NamespaceMaxLength);
            _ = Check.NotNullOrWhiteSpace(projectRelativePath, nameof(projectRelativePath), DiagramConsts.PathMaxLength);
            _ = Check.NotNullOrWhiteSpace(directory, nameof(directory), DiagramConsts.PathMaxLength);
            _ = Check.NotNullOrWhiteSpace(name, nameof(name), DiagramConsts.ClassNameMaxLength);

            SolutionId = solutionId;

            var importsString = imports is { Count: > 0 } ? imports.Aggregate((i, j) => i + ";" + j) : string.Empty;
            _ = Check.NotNull(importsString, nameof(importsString), DiagramConsts.ArrayStringMaxLength);
            _imports = importsString;

            NamespaceBelongingTo = namespaceBeloningTo;
            ProjectRelativePath = projectRelativePath;
            Directory = directory;
            Name = name;
            BaseClass = baseClass;

            var baseInterfacesString = baseInterfaces is { Count: > 0 } ? baseInterfaces.Aggregate((i, j) => i + ";" + j) : string.Empty;
            _ = Check.NotNull(baseInterfacesString, nameof(baseInterfacesString), DiagramConsts.ArrayStringMaxLength);
            _baseInterfaces = baseInterfacesString;

            _properties = properties.ToList();
        }

        public EntityComponent AddProperty(
            Guid id,
            string accessLevel,
            string type,
            string name,
            string getAccessLevel,
            string setAccessLevel)
        {
            var property = new PropertyDefine(
                id,
                Id,
                accessLevel,
                type,
                name,
                getAccessLevel,
                setAccessLevel
                );

            _properties.Add(property);

            return this;
        }

        public EntityComponent RemoveAllProperties()
        {
            _properties.Clear();

            return this;
        }
    }
}
