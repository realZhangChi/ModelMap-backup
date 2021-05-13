using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMap.Desktop.Components.Modals
{
    public class ModalSaveClickEventArgs
    {
        public ModalSaveClickEventArgs(object data)
        {
            Data = data;
        }

        public object Data { get; protected set; }
    }
}
