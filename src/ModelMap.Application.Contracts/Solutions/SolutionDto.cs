using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModelMap.Solutions
{
    public class SolutionDto : FullAuditedEntityDto<Guid>
    {
        public string AbsolutePath { get; set; }

        public string Name { get; set; }
    }
}
