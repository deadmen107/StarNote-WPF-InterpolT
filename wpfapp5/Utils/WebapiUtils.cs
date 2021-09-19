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
    }
}
