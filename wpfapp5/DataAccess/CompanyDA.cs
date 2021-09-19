using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StarNote.Utils;
using StarNote.Model;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using StarNote.ViewModel;
using System.IO;

namespace StarNote.DataAccess
{
    public class CompanyDA
    {     
            HttpClient client;
        // TokenModel tk = new TokenModel();
            private static string controller = "Company/";
            public CompanyDA()
            {
               
            ServicePointManager
           .ServerCertificateValidationCallback +=
           (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            }

            public List<CompanyModel> GetAll()
            {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<CompanyModel> list = new List<CompanyModel>();
                try
                {
                    response = client.GetAsync("GetAll").Result;
                    var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                    foreach (var item in result)
                    {
                    list.Add(item.ToObject<CompanyModel>());
                    }
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Tablo Api verisi alındı", "");
                }
                catch (Exception ex)
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Tablo Api doldurma hatası", ex.Message);
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Tablo Api doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
                return list;
            }

            public bool Update(CompanyModel obj)
            {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isUpdated = false;
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Update");
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
                    isUpdated = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Güncelleme Yapıldı", "");
                }
                catch (Exception ex)
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Güncelleme  hatası", ex.Message);
                }
                return isUpdated;
            }


            public bool Add(CompanyModel obj)
            {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isadded = false;
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Add");
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
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Güncelleme Yapıldı", "");
                isadded = true;
                }
                catch (Exception ex)
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Güncelleme  hatası", ex.Message);
                }
                return isadded;
            }

            public bool Delete(CompanyModel obj)
            {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isdeleted = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Delete");
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
                isdeleted = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Silme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Silme  hatası", ex.Message);
            }
            return isdeleted;
        }


        
    }
}
