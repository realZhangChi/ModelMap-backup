using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.OmniSharp
{
    public interface IOmniSharpService
    {
        Task StartAsync(string solutionPath);
    }
}
