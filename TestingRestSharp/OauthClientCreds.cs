using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace TestingRestSharp
{
    public class OAuthBody
    {
        public string? grant_type { get; set; }
        public string? refresh_token { get; set; }
        public string? client_id { get; set; }
        public string? client_secret { get; set; }
        public string? username { get; set; }
        public string? location_id { get; set; }
    }

public class ApiHTTPClient
    {
        public async static Task<HttpResponseMessage> PostApi(String basePath = "https://api.intacct.com/ia/api/v1/")
        {
            var oAuthBody = new OAuthBody
            {
                grant_type = "client_credentials",
                client_id = "xxxxxxxxxxxxxxxxxxxx.app.sage.com",
                client_secret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                username = "EthosIntegrations@IntacctCompany"
            };

            var RestClient = new HttpClient();
            RestClient.BaseAddress = new Uri(basePath);
            JObject body = JObject.FromObject(oAuthBody, new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore });
            var postData = new StringContent(body.ToString(), Encoding.UTF8, "application/json");

            try
            {
                RestClient.DefaultRequestHeaders.Add("Authorization", "Bearer ");
                return await RestClient.PostAsync("oauth2/token", postData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}
