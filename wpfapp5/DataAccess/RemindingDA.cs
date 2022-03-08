using Newtonsoft.Json.Linq;
using StarNote.Model;
using StarNote.Utils;
using StarNote.ViewModel;
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

namespace StarNote.DataAccess
{
    public class RemindingDA
    {
        HttpClient client;
        TokenModel tk = new TokenModel();
        private static string controller = "Reminding/";
        public RemindingDA()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tk.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public List<RemindingModel> GetAll()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<RemindingModel> list = new List<RemindingModel>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("GetAllRemindings").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<RemindingModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Tablo Api verisi alındı", "");              
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public List<RemindingModel> GetOldRemindings()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<RemindingModel> list = new List<RemindingModel>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("Getoldreminding").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<RemindingModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public List<RemindingModel> GetSelectedoldremindings(int id)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<RemindingModel> list = new List<RemindingModel>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("Getoldremindingsforselectedid?ID="+id).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<RemindingModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public List<string> Getrecordlist()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> list = new List<string>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("Filloldrecord").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<string>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Eski Kayıt Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Eski Kayıt doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Eski Kayıt doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public OrderModel Getselectedmainmodel(int ID)
        {           
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            OrderModel obj = new OrderModel();
            try
            {
                response = client.GetAsync("Getselectedrecord?ID=" + ID.ToString()).Result;
                var result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                obj = result.ToObject<OrderModel>();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Seçilen Mainmodel Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Seçilen Mainmodel doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Seçilen Mainmodel doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public List<string> Getstatussource()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> list = new List<string>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("Getstatussource").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<string>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma status Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma status doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma status doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public List<string> Gettypesource()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<string> list = new List<string>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("Gettypesource").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    list.Add(item.ToObject<string>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma type Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma type doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma type doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return list;
        }

        public bool Update(RemindingModel obj)
        {
            bool isUpdated = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Update");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + tk.access_token);
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
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Güncelleme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Güncelleme  hatası", ex.Message);
            }
            return isUpdated;
        }

        public bool Add(RemindingModel obj)
        {
            bool isadded = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Add");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + tk.access_token);
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
                isadded = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Güncelleme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Güncelleme  hatası", ex.Message);
            }
            return isadded;
        }

        public bool Delete(RemindingModel obj)
        {
            bool isdeleted = false;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() + controller + "Delete");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + tk.access_token);
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
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hatırlatma Silme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hatırlatma Silme  hatası", ex.Message);
            }
            return isdeleted;
        }
    }
}
