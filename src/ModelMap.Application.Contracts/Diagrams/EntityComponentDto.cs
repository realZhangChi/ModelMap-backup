using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModelMap.Diagrams
{
    public class EntityComponentDto : FullAuditedEntityDto<Guid>
    {
        public virtual PositionDto Position { get; set; }

        public virtual List<string> Imports { get; set; }

        public virtual string NamespaceBelongingTo { get; set; }

        public virtual string ProjectFullPath { get; set; }

        public virtual string Directory { get; set; }

        public virtual string Name { get; set; }

        public virtual string BaseClass { get; set; }

        public virtual List<string> BaseInterfaces { get; set; }

        public virtual List<PropertyDefineDto> Properties { get; set; }
    }
}
