using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace ModelMap.Desktop.Models.ContextMenus
{
    public class ContextMenuOptionModel
    {
        public string Name { get; private set; }

        public bool IsEnable { get; private set; }

        public EventCallback OnClickedCallBack { get; private set; }

        public ContextMenuOptionModel(
            [NotNull] string name,
            EventCallback @onClickedCallBack,
            bool isEnable = true)
        {
            Name = name;
            OnClickedCallBack = onClickedCallBack;
            IsEnable = isEnable;
        }
    }
}
