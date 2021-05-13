using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModelMap.Diagrams
{
    public class PropertyDefineDto : EntityDto<Guid>
    {
        public string AccessLevel { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string GetAccessLevel { get; set; }

        public string SetAccessLevel { get; set; }
    }
}
