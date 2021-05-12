using Volo.Abp.Settings;

namespace ModelMap.Settings
{
    public class ModelMapSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ModelMapSettings.MySetting1));
        }
    }
}
