using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMap.Diagrams
{
    public class PositionDto
    {
        [Required]
        public double Top { get; set; }

        [Required]
        public double Left { get; set; }
    }
}
