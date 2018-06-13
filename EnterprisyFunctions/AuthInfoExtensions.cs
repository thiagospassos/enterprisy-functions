using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace EnterprisyFunctions
{
    public static class AuthInfoExtensions
    {
        private static HttpClient _httpClient = new HttpClient(); // cache and reuse to avoid repeated creation on Function calls

        /// <summary>
        /// Find a claim of the specified type
        /// </summary>
        /// <param name="authInfo"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static AuthUserClaim GetClaim(this AuthInfo authInfo, string claimType)
        {
            return authInfo.UserClaims.FirstOrDefault(c => c.Type == claimType);
        }

        /// <summary>
        /// Get the EasyAuth properties for the currently authenticated user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<AuthInfo> GetAuthInfoAsync(this HttpRequest request)
        {
            string zumoAuthToken = request.GetZumoAuthToken();
            if (string.IsNullOrEmpty(zumoAuthToken))
            {
                return null;
            }
            var authMeRequest = new HttpRequestMessage(HttpMethod.Get, GetEasyAuthEndpoint())
            {
                Headers =
                {
                    { "X-ZUMO-AUTH", zumoAuthToken }
                }
            };
            var response = await _httpClient.SendAsync(authMeRequest);
            var authInfoString = await response.Content.ReadAsStringAsync();//.ReadAsAsync<AuthInfo[]>();
            var authInfoArray = JsonConvert.DeserializeObject<AuthInfo[]>(authInfoString);
            return authInfoArray.Length >= 1 ? authInfoArray[0] : null; // The .auth/me content is a single item array if it is populated
        }
        private static string GetEasyAuthEndpoint()
        {
            // Get the hostname from environment variables so that we don't need config - thank you App Service!
            var hostname = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
            // Build up the .auth/me url
            string requestUri = $"https://{hostname}/.auth/me";
            return requestUri;
        }
        private static string GetZumoAuthToken(this HttpRequest req)
        {
            StringValues values;
            if (req.Headers.TryGetValue("X-ZUMO-AUTH", out values))
            {
                return values.FirstOrDefault();
            }
            return string.Empty;
        }
    }
}