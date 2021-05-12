using System;
using System.Collections.Generic;
using System.Text;
using ModelMap.Localization;
using Volo.Abp.Application.Services;

namespace ModelMap
{
    /* Inherit your application services from this class.
     */
    public abstract class ModelMapAppService : ApplicationService
    {
        protected ModelMapAppService()
        {
            LocalizationResource = typeof(ModelMapResource);
        }
    }
}
