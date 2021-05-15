using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMap.Diagrams
{
    public class CreateEntityComponentDto
    {
        [Required]
        public Guid SolutionId { get; set; }

        [Required]
        public PositionDto Position { get; set; }

        public List<string> Imports { get; set; }

        [Required]
        [MaxLength(DiagramConsts.NamespaceMaxLength)]
        public string NamespaceBelongingTo { get; set; }

        [Required]
        [MaxLength(DiagramConsts.PathMaxLength)]
        public string ProjectRelativePath { get; set; }

        [Required]
        [MaxLength(DiagramConsts.PathMaxLength)]
        public string Directory { get; set; }

        [Required]
        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public string BaseClass { get; set; }

        public List<string> BaseInterfaces { get; set; }

        public List<PropertyDefineDto> Properties { get; set; }
    }
}
