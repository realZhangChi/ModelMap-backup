using ModelMap.Diagrams;
using System;
using System.Collections.Generic;

namespace ModelMap.Desktop.Models
{
    public class EntityComponentModel : EntityComponentDto
    {
        public new Guid? Id { get; set; }

        public new IList<PropertyModel> Properties { get; set; }

        public EntityComponentModel()
        {
            Properties = new List<PropertyModel>();
        }
    }
}
