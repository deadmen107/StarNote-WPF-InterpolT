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
using StarNote.Service;

namespace StarNote.DataAccess
{
    public class AnalysisMontlyDA
    {
        HttpClient client;
        //TokenModel tk = new TokenModel();
        private static string controller = "AnalysisMontly/";



        public AnalysisMontlyDA()
        {        
            ServicePointManager
    .ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public List<AnalysisMontlyModel> FillMontlyAnalysis(string date)
        {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<AnalysisMontlyModel> analysismodel = new List<AnalysisMontlyModel>();
            try
            {                
                response = client.GetAsync("GetMontlyAnalysis?date=" + date+"&type="+RefreshViews.pagecount).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    analysismodel.Add(item.ToObject<AnalysisMontlyModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Tablo doldurma hatası" , ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return analysismodel;
        }

        public string Fillmontlygaugesales(string date)
        {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<string> input = new List<string>();
            try
            {               
                response = client.GetAsync("Getmontlysalesgauge?date=" + date + "&type=" + RefreshViews.pagecount).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    input.Add((item.ToObject<string>()));
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Satış Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Satış Gauge doldurma hatası" , ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Satış Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return input[0].Replace(',','.');
        }

        public string Fillmontlygaugepurchase(string date)
        {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<string> input = new List<string>();
            try
            {
                response = client.GetAsync("Getmontlypurchasegauge?date=" + date + "&type=" + RefreshViews.pagecount).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    input.Add((item.ToObject<string>()));
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Satın Alma Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Satın Alma Gauge doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Satın Alma Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }           
            return input[0].Replace(',', '.');
        }

        public string Fillmontlygaugenet(string date)
        {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<string> input = new List<string>();
            try
            {
                response = client.GetAsync("Getmontlynetgauge?date=" + date + "&type=" + RefreshViews.pagecount).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    input.Add((item.ToObject<string>()));
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Net Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Net Gauge doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Net Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }            
            return input[0].Replace(',', '.');
        }

        public string Fillmontlypotansial(string date)
        {
            // tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<string> input = new List<string>();
            try
            {
                response = client.GetAsync("Getmontlypotansialgauge?date=" + date + "&type=" + RefreshViews.pagecount).Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    input.Add((item.ToObject<string>()));
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Net Gauge Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Net Gauge doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Net Gauge doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return input[0].Replace(',', '.');
        }

    }
}
