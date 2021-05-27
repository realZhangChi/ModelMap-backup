using Microsoft.Extensions.Configuration;
using ModelMap.Desktop.Services.Setting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IdentityModel;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using ModelMap.Desktop.Models.Token;
using System.Net;
using ModelMap.Desktop.Services.RequestProvider;

namespace ModelMap.Desktop.Services.Identity
{
    public class IdentityService : IIdentityService, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ISettingService _settingService;
        private readonly IRequestProvider _requestProvider;

        private static string _codeVerifier;

        public IdentityService(
            IConfiguration configuration,
            ISettingService settingService,
            IRequestProvider requestProvider)
        {
            _configuration = configuration;
            _settingService = settingService;
            _requestProvider = requestProvider;
        }

        public string CreateAuthorizationRequest()
        {
            // Create URI to authorization endpoint
            var authorizeRequest = new AuthorizeRequest($"{_configuration["AuthServer:Authority"]}/connect/authorize");

            // Dictionary with values for the authorize request
            var dic = new Dictionary<string, string>();
            dic.Add("client_id", _configuration["AuthServer:ClientId"]);
            dic.Add("client_secret", _configuration["AuthServer:ClientId"]);
            dic.Add("response_type", "code id_token");
            dic.Add("scope", "openid profile offline_access");
            dic.Add("redirect_uri", $"{_configuration["AuthServer:RootUrl"]}/authentication/login-callback");
            dic.Add("nonce", Guid.NewGuid().ToString("N"));
            dic.Add("code_challenge", CreateCodeChallenge());
            dic.Add("code_challenge_method", "S256");

            // Add CSRF token to protect against cross-site request forgery attacks.
            var currentCSRFToken = Guid.NewGuid().ToString("N");
            dic.Add("state", currentCSRFToken);

            var authorizeUri = authorizeRequest.Create(dic);
            return authorizeUri;
        }

        public async Task<UserToken> GetTokenAsync(string code)
        {
            var rootUri = new Uri(_configuration["AuthServer:RootUrl"]);
            var callbackUri = new Uri(rootUri, _configuration["AuthServer:CallBackRoute"]);
            string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}", code, WebUtility.UrlEncode(callbackUri.ToString()), _codeVerifier);
            var token = await _requestProvider.PostAsync<UserToken>($"{_configuration["AuthServer:Authority"]}/connect/token", data, _configuration["AuthServer:ClientId"], _configuration["AuthServer:ClientId"]);
            return token;
        }

        private string CreateCodeChallenge()
        {
            _codeVerifier = Guid.NewGuid().ToString("N");
            _codeVerifier += Guid.NewGuid().ToString("N");
            _codeVerifier += Guid.NewGuid().ToString("N");
            using var sha256 = SHA256.Create();
            var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_codeVerifier));
            return Base64Url.Encode(challengeBytes);
        }
    }
}
