using IdentityModel.Client;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.Authentication;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.IdentityModel;

namespace ModelMap.Desktop
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IRemoteServiceHttpClientAuthenticator))]
    public class RemoteServiceAuthenticator : IdentityModelRemoteServiceHttpClientAuthenticator, ITransientDependency
    {
        public RemoteServiceAuthenticator(
            IIdentityModelAuthenticationService identityModelAuthenticationService)
            : base(identityModelAuthenticationService)
        {
        }


        public override async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            if (context.RemoteService.GetUseCurrentAccessToken() != false)
            {
                var accessToken = Properties.Settings.Default.AccessToken;
                if (accessToken != null)
                {
                    context.Request.SetBearerToken(accessToken);
                    return;
                }
            }

            await base.Authenticate(context);
        }
    }
}
