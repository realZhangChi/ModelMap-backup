using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Solutions
{
    public interface ISolutionManager
    {
        Task<Solution> CreateAsync(string absolutePath);
    }
}
