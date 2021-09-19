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

namespace StarNote.Utils
{
    public class UserUtils
    {
        HttpClient client;
        //TokenModel tk = new TokenModel();
        private static string controller = "User/";
        public UserUtils()
        {           
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public static string ActiveUsername = string.Empty;

        public static string ActiveUsersurname = string.Empty;

        public static string ActiveUser=string.Empty;

        public static string Password=string.Empty;

        public static List<string> Authority = new List<string>();

        private static bool Isactive = true;

        public bool CheckUserfromApi(string username, string password)
        {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"].ToString() + controller);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + WebapiUtils.access_token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;
            List<UsersModel> userlist = new List<UsersModel>();
            UsersModel activeuser = new UsersModel();
            bool isok = false;
            try
            {                             
            response = client.GetAsync("GetUserList").Result;
            var result = JArray.Parse(response.Content.ReadAsStringAsync().Result);
            foreach (var item in result)
            {
                userlist.Add(item.ToObject<UsersModel>());
            }
           
                activeuser = userlist.FirstOrDefault(u => u.Kullanıcıadi == username && u.Şifre == password);
                if (activeuser!=null)
                {
                    ActiveUser = activeuser.Kullanıcıadi;
                    Password = activeuser.Şifre;
                    ActiveUsername = activeuser.İsim;
                    ActiveUsersurname = activeuser.Soyisim;
                    if (activeuser.Yetki=="All")
                    {
                        string[] yetkiler = fillyetki().Split(',');
                        foreach (var yetki in yetkiler)
                        {
                            Authority.Add(yetki.ToString());
                        }
                    }
                    else
                    {
                        string[] yetkiler = activeuser.Yetki.Split(',');
                        foreach (var yetki in yetkiler)
                        {
                            Authority.Add(yetki.ToString());
                        }
                    }
                   
                    Isactive = activeuser.Isactive;
                    isok = true;
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aktif Kullanıcı Api Verisi Alındı ", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aktif Kullanıcı Api Verisi Alınamadı Hatası", ex.Message);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aktif Kullanıcı Api Verisi Alınamadı Hatası", response.Content.ReadAsStringAsync().Result);
            }
            return isok;
        }

        private string fillyetki()
        {
            string yetki = "";
            yetki += Genel_Takip_Ekranı+",";
            yetki += Yeni_Kayıt_Ekleme + ",";
            yetki += Kayıt_Düzenleme + ",";
            yetki += Bütün_Kayıtlar + ",";
            yetki += Geneltakip_yazdırma + ",";
            yetki += Hatırlatma_Ekranı + ",";
            yetki += Hatırlatma_Ekle + ",";
            yetki += Hatırlatma_Düzenle + ",";
            yetki += Bütün_Hatırlatmalar + ",";
            yetki += hatırlatma_yazdırma + ",";
            yetki += Dosya_Takip_Ekranı + ",";
            yetki += Dosya_Kayıt_Oluşturma + ",";
            yetki += Dosya_İndir + ",";
            yetki += Dosya_Silme + ",";
            yetki += Dosyatakip_yazdırma + ",";
            yetki += Günlük_Satın_Alma + ",";
            yetki += Günlük_satın_alma_yazdırma + ",";
            yetki += Günlük_Satış + ",";
            yetki += Günlük_satıs_yazdırma + ",";
            yetki += Aylık_Satın_Alma + ",";
            yetki += Aylık_satınalma_yazdırma + ",";
            yetki += Aylık_Satış + ",";
            yetki += Aylık_Satış_yazdırma + ",";
            yetki += Aylık_Analiz + ",";
            yetki += Aylık_Analiz_yazdırma + ",";
            yetki += Yıllık_Analiz + ",";
            yetki += Yıllık_Analiz_yazdırma + ",";
            yetki += Stok_Takip_Ekranı + ",";
            yetki += Stok_Ekle + ",";
            yetki += Stok_Güncelle + ",";
            yetki += Aktif_Stok_Hareketi + ",";
            yetki += Stok_Yazdırma + ",";
            yetki += Kullanıcıları_Görüntül + ",";
            yetki += Kullanıcı_Ekle + ",";
            yetki += Kullanıcı_Güncelle + ",";
            yetki += Kullanıcı_Sil + ",";
            yetki += Kullanıcı_yazdırma + ",";
            yetki += Satış_görevli_görüntüle + ",";
            yetki += Satış_görevli_Ekle + ",";
            yetki += Satış_görevli_güncelle + ",";
            yetki += Satış_görevli_sil + ",";
            yetki += Satış_görevli_yazdırma + ",";
            yetki += Tür_görüntüle + ",";
            yetki += Tür_Ekle + ",";
            yetki += Tür_Güncelle + ",";
            yetki += Tür_Sil + ",";
            yetki += Tür_Yazdırma + ",";
            yetki += Firma_görüntüle + ",";
            yetki += Firma_ekle + ",";
            yetki += Firma_güncelle + ",";
            yetki += Firma_Sil + ",";
            yetki += Firma_yazdırma + ",";
            yetki += Müşteri_görüntüle + ",";
            yetki += Müşteri_ekle + ",";
            yetki += Müşteri_Güncelle + ",";
            yetki += Müşteri_sil + ",";
            yetki += Müşteri_yazdırma + ",";
            yetki += Dosya_Yolu_Düzenle + ",";
            yetki += Dosya_yolu_görüntüle + ",";
            yetki += Hedef_ekranı + ",";
            yetki += Hedef_Düzenle + ",";
            yetki += İşlem_Kayıt_Görüntüle + ",";
            yetki += SatışGörevli_analiz + ",";
            yetki += SatışGörevli_Yazdırma + ",";
            yetki += Ürün_detay_ekranı + ",";
            yetki += Üründetay_Ekle + ",";
            yetki += ÜrünDetay_Güncelle + ",";
            yetki += ÜrünDetay_Sil + ",";
            yetki += ÜrünDetay_yazdırma + ",";
            return yetki;
        }
        #region yetkiler
        #region genel takip ekranı 
        public static string Genel_Takip_Ekranı = "Main Screen";
        public static string Yeni_Kayıt_Ekleme = "Add Record";
        public static string Kayıt_Düzenleme = "Edit Record";
        public static string Bütün_Kayıtlar = "All Records";
        public static string Geneltakip_yazdırma = "Can Print Main Screen";
        #endregion        
        #region Hatırlatmalar 
        public static string Hatırlatma_Ekranı = "Reminding Screen";
        public static string Hatırlatma_Ekle = "Add Reminding";
        public static string Hatırlatma_Düzenle = "Edit Reminding";
        public static string Bütün_Hatırlatmalar = "All Remindings";
        public static string hatırlatma_yazdırma = "Can Print Reminding";
        #endregion
        #region Dosya Takip 
        public static string Dosya_Takip_Ekranı = "File Screen";
        public static string Dosya_Kayıt_Oluşturma = "Create File";
        public static string Dosya_İndir = "Download File";
        public static string Dosya_Silme = "Delete File";
        public static string Dosyatakip_yazdırma = "File Print";
        #endregion
        #region Raporlar 
        public static string Günlük_Satın_Alma = "Daily Purchase";
        public static string Günlük_satın_alma_yazdırma = "Daily Purchase Print";
        public static string Günlük_Satış = "Daily Sales";
        public static string Günlük_satıs_yazdırma = "Daily Sales Print";
        public static string Aylık_Satın_Alma = "Monthly Purchase";
        public static string Aylık_satınalma_yazdırma = "Monthly Purchase Print";
        public static string Aylık_Satış = "Monthly Sales";
        public static string Aylık_Satış_yazdırma = "Monthly Sales Print";
        public static string Aylık_Analiz = "Monthly Analysis";
        public static string Aylık_Analiz_yazdırma = "Monthly Analysis Print";
        public static string Yıllık_Analiz = "Yearly Analysis";
        public static string Yıllık_Analiz_yazdırma = "Yearly Analysis Print";
        public static string SatışGörevli_analiz = "Salesman Analysis";
        public static string SatışGörevli_Yazdırma = "Salesman Analysis Print";
        #endregion
        #region Stok ve Ürün Detay
        public static string Stok_Takip_Ekranı = "Stock Screen";
        public static string Stok_Ekle = "Add Stock";
        public static string Stok_Güncelle = "Edit Stock";
        public static string Aktif_Stok_Hareketi = "Active Stock Movement";
        public static string Stok_Yazdırma = "Stock Print";

        public static string Ürün_detay_ekranı = "Product Screen";
        public static string Üründetay_Ekle = "Product Add";
        public static string ÜrünDetay_Güncelle = "Product Update";
        public static string ÜrünDetay_Sil = "Product Delete";
        public static string ÜrünDetay_yazdırma = "Product Print";
        #endregion
        #region User 
        public static string Kullanıcıları_Görüntül = "User Screen";
        public static string Kullanıcı_Ekle = "Add User";
        public static string Kullanıcı_Güncelle = "Edit User";
        public static string Kullanıcı_Sil = "Delete User";
        public static string Kullanıcı_yazdırma = "User Print";
        #endregion
        #region Ek Kayıtlar 
        public static string Satış_görevli_görüntüle = "Salesman Screen";
        public static string Satış_görevli_Ekle = "Salesman Add";
        public static string Satış_görevli_güncelle = "Salesman Update";
        public static string Satış_görevli_sil = "Salesman Delete";
        public static string Satış_görevli_yazdırma = "Salesman Print";
        public static string Tür_görüntüle = "Type Screen";
        public static string Tür_Ekle = "Type Add";
        public static string Tür_Güncelle = "Type Update";
        public static string Tür_Sil = "Type Delete";
        public static string Tür_Yazdırma = "Type Print";
        public static string Firma_görüntüle = "Company Screen";
        public static string Firma_ekle = "Company Add";
        public static string Firma_güncelle = "Company Update";
        public static string Firma_Sil = "Company Delete";
        public static string Firma_yazdırma = "Company Print";
        public static string Müşteri_görüntüle = "Costumer Screen";
        public static string Müşteri_ekle = "Costumer Add";
        public static string Müşteri_Güncelle = "Costumer Update";
        public static string Müşteri_sil = "Costumer Delete";
        public static string Müşteri_yazdırma = "Costumer Print";
        #endregion
        #region Utils 
        public static string Dosya_Yolu_Düzenle = "Edit File Path";
        public static string Dosya_yolu_görüntüle = "File Path Screen";       
        public static string Hedef_ekranı = "Target Screen";
        public static string Hedef_Düzenle = "Tarket Edit";
        public static string İşlem_Kayıt_Görüntüle = "Log Screen";
        #endregion        
        #endregion
    }
}
