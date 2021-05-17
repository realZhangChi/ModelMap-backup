using ModelMap.Desktop.Events;
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

        public SolutionChangedHandler(ICurrentSolution currentSolution)
        {
            _currentSolution = currentSolution;
        }

        public Task HandleEventAsync(SolutionChangedEvent eventData)
        {
            return _currentSolution.SetAsync(eventData.SolutionPath);
        }
    }
}
