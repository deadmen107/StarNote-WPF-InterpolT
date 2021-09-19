using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class SalesmanAnalysisDA
    {
        HttpClient client;
        //  TokenModel tk = new TokenModel();
        private static string controller = "AnalysisSalesman/";
        public SalesmanAnalysisDA()
        {           
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public List<SalesmanAnalysisModel> fillsalesmansales(string ay)
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<SalesmanAnalysisModel> listsalesman = new List<SalesmanAnalysisModel>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("GetSalesmanlistsales?ay="+ay+"").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    listsalesman.Add(item.ToObject<SalesmanAnalysisModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Analiz Satış Tablo Api Verisi Alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Analiz Satış Tablo Api Hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Analiz Satış Tablo Api Hatası", response.Content.ReadAsStringAsync().Result);
            }
            return listsalesman;
        }

        public List<SalesmanAnalysisModel> fillsalesmanpurchase(string ay)
        {
            //   tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<SalesmanAnalysisModel> listsalesman = new List<SalesmanAnalysisModel>();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync("GetSalesmanlistpurchase?ay=" + ay + "").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    listsalesman.Add(item.ToObject<SalesmanAnalysisModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Analiz Satın Alma Tablo Api Verisi Alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Analiz Satın Alma Tablo Api Hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Analiz Satın Alma Tablo Api Hatası", response.Content.ReadAsStringAsync().Result);

            }
            return listsalesman;
        }
        
        public List<DataPoint> loadpiessales(string date)
        {
            //    tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<DataPoint> chartsetsales = new List<DataPoint>();
            try
            {
                response = client.GetAsync("GetSalesPie?date=" + date).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    chartsetsales.Add(item.ToObject<DataPoint>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Personel Satış Pie Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Personel Satış Pie Api  doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Personel Satış Pie Api  doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return chartsetsales;
        }

        public List<DataPoint> loadpiepurchase(string date)
        {
            //    tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<DataPoint> chartsetpurchase = new List<DataPoint>();
            try
            {
                response = client.GetAsync("GetPurchasePie?date=" + date).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    chartsetpurchase.Add(item.ToObject<DataPoint>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Personel Satın Alma Pie Api  verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Personel Satın Alma Pie Api  doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Personel Satın Alma Pie Api  doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return chartsetpurchase;
        }
    }
}
