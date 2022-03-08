using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.ViewModel;
using StarNote.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Configuration;
using StarNote.Utils;

namespace StarNote.DataAccess
{
    public class DailyAccountingDA
    {
        HttpClient client;
        //  TokenModel tk = new TokenModel();
        private static string controller = "DailyAccounting/";
        public DailyAccountingDA()
        {          
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public OrderModel Getselectedrecord(int ID)
        {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            OrderModel obj = new OrderModel();
            try
            {
                response = client.GetAsync("Getselectedstok?ID=" + ID).Result;
                var result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                obj = result.ToObject<OrderModel>();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Seçilen stok Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Seçilen stok doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Seçilen stok doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public List<DailyAccountingModel> dailysalesfill(string date)
        {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<DailyAccountingModel> dailysalesmodelsales = new List<DailyAccountingModel>();
            try
            {
                string url = "GetDailySales" + "?date=" + date;
                response = client.GetAsync(url).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    dailysalesmodelsales.Add(item.ToObject<DailyAccountingModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satış Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satış Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satış Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return dailysalesmodelsales;
        }

        public List<DailyAccountingModel> dailypurchasefill(string date)
        {
            //  tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<DailyAccountingModel> dailysalesmodelpurchase = new List<DailyAccountingModel>();
            try
            {
                string url = "GetPurchaseSales" + "?date=" + date;
                response = client.GetAsync(url).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    dailysalesmodelpurchase.Add(item.ToObject<DailyAccountingModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satın Alma Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satın Alma Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satın Alma Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return dailysalesmodelpurchase;        
        }

        public List<GaugeModel> dailygaugepurchasefill(string date)
        {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            try
            {
                string url = "GetDailygaugevalues" + "?date=" + date;
                response = client.GetAsync(url).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    gaugelist.Add(item.ToObject<GaugeModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satın Alma Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satın Alma Gauge doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satın Alma Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return gaugelist;
        }

        public List<GaugeModel> dailygaugesalesfill(string date)
        {
            //  tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<GaugeModel> gaugelist = new List<GaugeModel>();
            try
            {
                string url = "GetDailysalesgaugevalues" + "?date=" + date;
                response = client.GetAsync(url).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    gaugelist.Add(item.ToObject<GaugeModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satış Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satış Gauge doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satış Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return gaugelist;
        }

    }
}
