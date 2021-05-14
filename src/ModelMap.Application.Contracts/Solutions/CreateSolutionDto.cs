using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelMap.Solutions
{
    public class CreateSolutionDto
    {
        [Required]
        [MaxLength(SolutionConsts.PathMaxLength)]
        public virtual string AbsolutePath { get; set; }
    }
}
