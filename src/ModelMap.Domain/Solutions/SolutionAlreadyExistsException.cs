using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ModelMap.Solutions
{
    public class SolutionAlreadyExistsException : UserFriendlyException
    {
        public SolutionAlreadyExistsException()
            : base("A solution with the same path already exists!")
        {

        }
    }
}
