using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Pages.Designers
{
    internal class DesignerInvokeHelper
    {
        private Func<Guid, double, double, Task> _action;

        public DesignerInvokeHelper(Func<Guid, double, double, Task> action)
        {
            _action = action;
        }

        [JSInvokable]
        public Task ShowCanvasContextMenuAsync(Guid id, double clientX, double clientY)
        {
            return _action.Invoke(id, clientX, clientY);
        }
    }
}
