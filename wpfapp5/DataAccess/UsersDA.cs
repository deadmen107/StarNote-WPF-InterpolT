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
    public class UsersDA
    {
        HttpClient client;
        //  TokenModel tk = new TokenModel();
        private static string controller = "User/";
        public UsersDA()
        {           
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public List<UsersModel> GetAll()
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<UsersModel> userlist = new List<UsersModel>();
            try
            {                           
                response = client.GetAsync("GetUserList").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    userlist.Add(item.ToObject<UsersModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar Tablosu Api Verisi Alındı ", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Tablosu Api Hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Tablosu Api Hatası", response.Content.ReadAsStringAsync().Result);
            }
            return userlist;
        }

        public bool Add(UsersModel objnewuser)
        {
            //    tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;           
            bool IsAdded = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() +controller+ "AddUser");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objnewuser);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                IsAdded = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar Kaydetme Tamamlandı ", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Kaydetme  Api Hatası", ex.Message);
            }
            return IsAdded;
        }


        public bool Update(UsersModel objuser)
        {
            //    tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;           
            bool isUpdated = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() +controller+ "UpdateUser");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objuser);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isUpdated = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar Güncelleme Tamamlandı ", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Güncelleme  Api Hatası", ex.Message);
            }
            return isUpdated;
        }

        public bool Delete(UsersModel objuser)
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;           
            bool isUpdated = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString()+ controller + "DeleteUser");
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(objuser);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isUpdated = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar Silme Tamamlandı ", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Silme  Api Hatası", ex.Message);
            }
            return isUpdated;
        }

    }
}
