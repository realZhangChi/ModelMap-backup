using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelMap.Desktop.Services.Solution
{
    public interface ICurrentSolution
    {
        Microsoft.CodeAnalysis.Solution Value { get; }

        Task SetAsync(string path);
    }
}
