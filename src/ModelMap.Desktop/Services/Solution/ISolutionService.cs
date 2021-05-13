﻿using JetBrains.Annotations;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Services.Solution
{
    public interface ISolutionService
    {
        // TODO: Create SolutionModel
        Task<SolutionDto> GetSolutionModelAsync([NotNull] string path);
    }
}