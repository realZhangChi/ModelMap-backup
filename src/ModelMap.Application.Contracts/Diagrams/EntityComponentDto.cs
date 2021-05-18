using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModelMap.Diagrams
{
    public class EntityComponentDto : FullAuditedEntityDto<Guid>
    {
        public Guid SolutionId { get; set; }

        public PositionDto Position { get; set; }

        public List<string> Imports { get; set; }

        public string NamespaceBelongingTo { get; set; }

        public string ProjectRelativePath { get; set; }

        public string Directory { get; set; }

        public string Name { get; set; }

        public string BaseClass { get; set; }

        public List<string> BaseInterfaces { get; set; }

        public List<PropertyDefineDto> Properties { get; set; }
    }
}
