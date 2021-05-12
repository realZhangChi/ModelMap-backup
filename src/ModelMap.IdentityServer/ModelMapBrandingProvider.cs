using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ModelMap
{
    [Dependency(ReplaceServices = true)]
    public class ModelMapBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ModelMap";
    }
}
