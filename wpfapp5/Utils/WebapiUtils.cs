using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.ViewModel;

namespace StarNote.Utils
{
    public class WebapiUtils
    {
        public static string access_token { get; set; }

        public static string token_type { get; set; }

        public static string expires_in { get; set; }

        public static async Task<TokenModel> GetToken()
        {
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            TokenModel obj = new TokenModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TokenURL"].ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    var content = new FormUrlEncodedContent(new[]
                    {
                       new KeyValuePair<string, string>("grant_type", "password"),
                       new KeyValuePair<string, string>("username", "sys"),
                       new KeyValuePair<string, string>("password", "12345")

            });
                    var result = await client.PostAsync("/token", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<TokenModel>(resultContent);
                    
                }
            }
            catch (Exception ex)
            {

                LogVM.Addlog("WebapiUtils", System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Token Çekme Hatası", ex.Message);
            }
            return obj;
        }

        public static bool apitest()
        {
            try
            {
                ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
                HttpClient client;
                string controller = "Home/";
                client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
                TokenModel tk = new TokenModel();
                tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tk.access_token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpResponseMessage response = client.GetAsync("Test").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.ToString() == "\"OK\"")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public static bool Dbtest()
        {
            try
            {
                ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
                HttpClient client;
                string controller = "Home/";
                client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
                TokenModel tk = new TokenModel();
                tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tk.access_token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpResponseMessage response = client.GetAsync("DBTest").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.ToString() == "\"OK\"")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
