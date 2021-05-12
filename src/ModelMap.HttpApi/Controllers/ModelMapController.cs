using ModelMap.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ModelMap.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ModelMapController : AbpController
    {
        protected ModelMapController()
        {
            LocalizationResource = typeof(ModelMapResource);
        }
    }
}