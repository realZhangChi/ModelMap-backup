using ModelMap.Desktop.Events;
using ModelMap.Desktop.Services.OmniSharp;
using ModelMap.Desktop.Services.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;

namespace ModelMap.Desktop.EventHandlers
{
    public class SolutionChangedHandler : IDistributedEventHandler<SolutionChangedEvent>, ITransientDependency
    {
        private readonly ICurrentSolution _currentSolution;

        private readonly IOmniSharpService _omniSharpService;

        public SolutionChangedHandler(
            ICurrentSolution currentSolution,
            IOmniSharpService omniSharpService)
        {
            _currentSolution = currentSolution;
            _omniSharpService = omniSharpService;
        }

        public async Task HandleEventAsync(SolutionChangedEvent eventData)
        {
            await _omniSharpService.StartAsync(eventData.SolutionPath);
            await _currentSolution.SetAsync(eventData.SolutionPath);
        }
    }
}
