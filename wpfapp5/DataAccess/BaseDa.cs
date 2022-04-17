using Newtonsoft.Json.Linq;
using StarNote.Utils;
using StarNote.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.DataAccess
{
    public class BaseDa
    {
        public BaseDa()
        {
            ServicePointManager
    .ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public bool DoPost<T>(T obj, string controller, string method, string parametername = "") where T : class
        {
            bool isok = false;
            try
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                string url = "";
                if (parametername != "")
                    url = method + "?" + parametername;
                else
                    url = method;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + url);
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isok = true;
                var timeTotal = s.Elapsed;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "POST Request verisi Alındı", controller + " Gerçekleşme süresi = " + timeTotal.ToString());
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", method + "  hatası", ex.Message);
            }
            return isok;
        }

        public T DoGet<T>(T obj, string controller, string method, string parametername = "", string parametername1 = "", bool itsjob = false)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller+"/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            string url = "";

            if (parametername != "")
                url = method + "?" + parametername;
            else
                url = method;
            if (parametername1 != "")
                url = url + "&" + parametername1;
            try
            {
                response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JRaw.Parse(response.Content.ReadAsStringAsync().Result);
                    obj = result.ToObject<T>();
                    var timeTotal = s.Elapsed;                   
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Get Request verisi Alındı", controller + " Gerçekleşme süresi = " + timeTotal.ToString());
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Haberleşme Hatası");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Request Hatası", response.StatusCode.ToString());
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Get Request verisi Alındı", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Get Request verisi Alındı", response.StatusCode.ToString());
            }
            return obj;
        }
    }
}
