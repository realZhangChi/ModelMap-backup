using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Pages.Designers
{
    internal class DesignerInvokeHelper
    {
        private Func<Guid, double, double, Task> _showCanvasContextMenuAction;
        private Func<Guid, double, double, Task> _updateEntityPositionAction;

        public DesignerInvokeHelper(
            Func<Guid, double, double, Task> showCanvasContextMenuAction,
            Func<Guid, double, double, Task> updateEntityPositionAction)
        {
            _showCanvasContextMenuAction = showCanvasContextMenuAction;
            _updateEntityPositionAction = updateEntityPositionAction;
        }

        [JSInvokable]
        public Task ShowCanvasContextMenuAsync(Guid id, double clientX, double clientY)
        {
            return _showCanvasContextMenuAction.Invoke(id, clientX, clientY);
        }

        [JSInvokable]
        public Task UpdateEntityPositionAsync(Guid id, double top, double left)
        {
            return _updateEntityPositionAction.Invoke(id, top, left);
        }
    }
}
