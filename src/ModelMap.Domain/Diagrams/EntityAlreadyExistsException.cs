using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.Diagrams
{
    public class EntityAlreadyExistsException : UserFriendlyException
    {
        public EntityAlreadyExistsException()
            : base("An entity with the same name already exists in the same namespace!")
        {

        }
    }
}
