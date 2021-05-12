using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ModelMap.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class ModelMapBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ModelMap";
    }
}
