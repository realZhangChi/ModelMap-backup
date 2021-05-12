using ModelMap.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ModelMap.Permissions
{
    public class ModelMapPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ModelMapPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ModelMapPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ModelMapResource>(name);
        }
    }
}
