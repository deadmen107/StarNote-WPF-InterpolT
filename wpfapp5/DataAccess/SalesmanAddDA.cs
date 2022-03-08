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
using StarNote.Utils;

namespace StarNote.DataAccess
{
    public class SalesmanAddDA
    {
        HttpClient client;
        // TokenModel tk = new TokenModel();
        private static string controller = "Salesman/";
        public SalesmanAddDA()
        {        
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public List<ParameterModel> GetAll()
        {
            //    tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<ParameterModel> objMainList = new List<ParameterModel>();
            try
            {
                response = client.GetAsync("GetSalesmanList").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    objMainList.Add(item.ToObject<ParameterModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Tablo Api doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Tablo Api doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return objMainList;
        }

        public bool Update(ParameterModel objsalesman)
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isUpdated = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() +controller+ "UpdateSalesman");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objsalesman);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isUpdated = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Güncelleme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Güncelleme  hatası", ex.Message);
            }
            return isUpdated;
        }


        public bool Add(ParameterModel objnewmain)
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isadded = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString()+ controller + "AddSalesman");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objnewmain);

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isadded = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Güncelleme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Güncelleme  hatası", ex.Message);
            }
            return isadded;
        }

        public bool Delete(ParameterModel objsalesman)
        {
            //  tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isdeleted = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString()+ controller+ "DeleteSalesman");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objsalesman);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isdeleted = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Silme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Silme  hatası", ex.Message);
            }
            return isdeleted;
        }


    }
}

