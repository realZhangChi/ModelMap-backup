using ModelMap.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ModelMap.Blazor
{
    public abstract class ModelMapComponentBase : AbpComponentBase
    {
        protected ModelMapComponentBase()
        {
            LocalizationResource = typeof(ModelMapResource);
        }
    }
}
