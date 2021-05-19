using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMap.Diagrams
{
    public class UpdateEntityComponentDto
    {
        [Required]
        public PositionDto Position { get; set; }

        [MaxLength(DiagramConsts.ClassNameMaxLength)]
        public string Name { get; set; }

        public List<PropertyDefineDto> Properties { get; set; }
    }
}
