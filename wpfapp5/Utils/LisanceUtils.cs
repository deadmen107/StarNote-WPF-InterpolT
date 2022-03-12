using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarNote.Model;
using StarNote.ViewModel;

namespace StarNote.Utils
{
    public class LisanceUtils
    {
        HttpClient client;
        //TokenModel tk = new TokenModel();
        private static string controller = "Lisance/";

        public LisanceUtils()
        {                      
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public bool createactivationfile()
        {
            bool iscreated = false;
            try
            {
                string msg = "";
                msg = createjson();
                createfile(msg);
                iscreated = true;

               
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Lisans Dosyası oluşturudu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Lisans Dosyası oluşturudu hatası", ex.Message);
            }
            return iscreated;
        }
        
        public List<string> createmaclist()
        {
            
            List<string> macadresslist = new List<string>();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAdress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                macadresslist.Add(adapter.Name.ToString() + "=" + adapter.GetPhysicalAddress().ToString());
            }
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Uygulama lisans verileri toplandı", "");
            return macadresslist;
        }

        public void createfile(string msg)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ActivationRequest.txt";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                fi.Delete();
            }
            var c = new StreamWriter(path, true);
            c.AutoFlush = true;
            c.WriteLine(msg);
            c.Dispose();
        }

        public string createjson()
        {                      
            dynamic Lisans = new JObject();
            Lisans.Hostname = System.Environment.MachineName;
            Lisans.date = DateTime.Now.ToString();                  
            Lisans.Tags = new JArray(createmaclist());
            string json = Convert.ToString(Lisans);
            string şifrelenmişmesaj = Encrypt(json);
            return şifrelenmişmesaj;
        }

        public List<LisanceModel> GetAll()
        {
            TokenModel tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tk.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<LisanceModel> objlisance = new List<LisanceModel>();
            try
            {
                response = client.GetAsync("GetLisanceAll").Result;
                var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
                foreach (var item in result)
                {
                    objlisance.Add(item.ToObject<LisanceModel>());
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Lisans Tablo Api verisi alındı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Lisans Tablo doldurma hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Lisans Tablo doldurma hatası", response.Content.ReadAsStringAsync().Result);
            }
            return objlisance;
        }

        public bool readlisans()
        {
            bool isok = false;            
            List<LisanceModel> lisancelist = new List<LisanceModel>();
            List<string> tempmaclist = new List<string>();
            tempmaclist = createmaclist();
            lisancelist = GetAll();
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", lisancelist.Count+ " adet lisans bulundu", "");
            foreach (var lisancelistitem in lisancelist)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "lisans kontrol başlıyor ", "");
                int basarılımacsayısı = 0;
                string[] apimaclist = Decrypt(lisancelistitem.Ürünanahtarı).Split(new[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                DateTime fromapi = Convert.ToDateTime(lisancelistitem.Sonaermetarihi);
                DateTime dtnow = DateTime.Now;
                int res = DateTime.Compare(dtnow, fromapi);
                if (lisancelistitem.Durum=="GOOD" && res<=0 )
                {                   
                    foreach (var apimac in apimaclist)
                    {
                        foreach (var tempmac in tempmaclist)
                        {
                            try
                            {
                                string[] tempmacparsed = tempmac.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                                if (apimac == tempmacparsed[1])
                                {
                                    basarılımacsayısı++;
                                }
                            }
                            catch (Exception)
                            {

                              
                            }
                          

                        }
                    }
                }
                else if (lisancelistitem.Durum != "BROKEN" && res > 0)
                {
                    //LİSANSI ENDED YAP 
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", basarılımacsayısı + " adet eşleşme bulundu ", "");
                if (basarılımacsayısı+4>=apimaclist.Length)
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "doğru eşleşme bulundu Lisans kontrol başarılı", "lisans adı = " + lisancelistitem.LisansAdı);
                    isok = true;
                }
                else if(lisancelistitem.Durum == "GOOD" && res <= 0 && basarılımacsayısı < apimaclist.Length)
                {
                    //LİSANSI BROKEN YAP
                }
                
            }
            return isok;
        }

        public static string Encrypt(string plainText)
        {
            //byte[] initVectorBytes = Encoding.ASCII.GetBytes("teto1620@#$%asdf");
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("MehBur2020@#€€#*");
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            //byte[] keyBytes = Encoding.Unicode.GetBytes("_+)&qwer9512popo");
            byte[] keyBytes = Encoding.Unicode.GetBytes("starnot*#tonrats");
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string Decrypt(string cipherText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("MehBur2020@#€€#*");
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = Encoding.Unicode.GetBytes("starnot*#tonrats");
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }

       
    }    
}
