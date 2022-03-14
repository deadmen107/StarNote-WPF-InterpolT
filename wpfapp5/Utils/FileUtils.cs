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
using System.Windows;
using DevExpress.Xpf.Grid.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using StarNote.Model;
using StarNote.ViewModel;
using StarNote.View;

namespace StarNote.Utils
{
    public class FileUtils
    {       
        //TokenModel tk = new TokenModel();
        private static string controller = "FileManagement/";
        private static string ftppassword = "5^k30nbC";

        public static string yüklendi = "YÜKLENDİ";
        public static string hazır = "HAZIR";
        public static string iptal = "İPTAL";

        public FileUtils()
        {          
            ServicePointManager
     .ServerCertificateValidationCallback +=
     (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public bool createStandartFile(string directory,string filename, OrderModel model,int format)
        {
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Local Dosya Oluşturuluyor", "");
            bool iscreated = false;
            try
            {
                ReportUC report;
                int count = 0;
                double toplampara = 0;
                double toplamsayfa = 0;
                double gelirvergi = 0;
                double stopaj = 0;
                switch (format)
                {
                    //Tercüme Raporu
                    case 0:
                        Report1 tercümerapor = new Report1();
                        tercümerapor.Parameters["dosyano"].Value = model.Costumerorder.Kayıtdetay + " esas";
                        tercümerapor.Parameters["talimatno"].Value = model.Costumerorder.Türdetay + "..............." + " talimat numaralı dosyası";
                        tercümerapor.Parameters["tarih"].Value = Convert.ToDateTime(model.Costumerorder.Randevutarihi).ToShortDateString();
                        tercümerapor.Parameters["tür"].Value = model.Costumerorder.Türdetay + " HAKİMLİĞİ'NE";
                        tercümerapor.Parameters["şehir"].Value = model.Costumerorder.Şehir;

                        foreach (var item in model.Joborder)
                        {
                            count++;
                            string kelimeno = "kelime" + count.ToString(), satırno = "satır" + count.ToString(), karakterno = "karakter" + count.ToString(), sayfano = "sayfa" + count.ToString(), ürünno = "ürün" + count.ToString();
                            tercümerapor.Parameters[kelimeno].Value = " : " + item.Kelimesayı + "  kelime";
                            tercümerapor.Parameters[satırno].Value = " : " + item.Satırsayı + "  satır";
                            tercümerapor.Parameters[karakterno].Value = " : " + item.Karaktersayı + "  karakter";
                            tercümerapor.Parameters[sayfano].Value = " ( " + item.Hesaplananadet +" SAYFA"+ " )";
                            tercümerapor.Parameters[ürünno].Value = item.Ürün;
                            
                                toplamsayfa += item.Hesaplananadet;
                            
                        }
                        toplampara = 90 * toplamsayfa;
                        tercümerapor.Parameters["toplampara"].Value = toplamsayfa.ToString() + " SAYFA " + " X " + "90" + " TL = " + toplampara.ToString() + " TL";
                        tercümerapor.Parameters["toplamsayfa"].Value = toplamsayfa.ToString() + " Sayfa";
                        //reportirsaliye.ExportOptions.PrintPreview.DefaultDirectory = System.Environment.CurrentDirectory;
                        tercümerapor.ExportOptions.PrintPreview.DefaultDirectory = directory;
                        tercümerapor.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                        tercümerapor.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                        tercümerapor.ExportOptions.PrintPreview.DefaultFileName = filename.Substring(0, filename.Length - 4);
                        tercümerapor.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                        report = new ReportUC(tercümerapor, model, filename);
                        report.Show();
                        break;
                    //Bildiri Ücret Raporu
                    case 1:
                        Repor2 bildiriücret = new Repor2();
                        bildiriücret.Parameters["Tarih"].Value = DateTime.Now.ToShortDateString();
                        bildiriücret.Parameters["Takipno"].Value = "MS............";
                        bildiriücret.Parameters["İsim"].Value = model.Costumerorder.İsim;
                        bildiriücret.Parameters["adres"].Value = model.Costumerorder.Adres + "  " + model.Costumerorder.İlçe + "  " + model.Costumerorder.Şehir;
                        //bildiriücret.Parameters["şehir"].Value = list[0].Şehir;
                        foreach (var item in model.Joborder)
                        {
                            count++;
                            string dosyano = "dosyano" + count.ToString(), hizmetno = "hizmet" + count.ToString(), sayfano = "sayfa" + count.ToString(), tutar = "tutar" + count.ToString();
                            bildiriücret.Parameters[dosyano].Value = item.Joborder;
                            bildiriücret.Parameters[hizmetno].Value = item.Ürün;
                            bildiriücret.Parameters[sayfano].Value = item.Miktar + " Adet";
                            bildiriücret.Parameters[tutar].Value = item.Ücret + " TL";

                            toplampara += item.Ücret;
                            toplamsayfa += item.Miktar;
                        }
                        bildiriücret.Parameters["toplamtutar"].Value = toplampara.ToString() + " TL";
                        bildiriücret.Parameters["toplamsayfa"].Value = toplamsayfa.ToString() + " Adet";
                        bildiriücret.Parameters["gelirvergi"].Value = (toplampara * 0.18).ToString() + " TL";
                        bildiriücret.Parameters["stopaj"].Value = (toplampara * 0.2).ToString() + " TL";
                        bildiriücret.Parameters["kesintitoplam"].Value = ((toplampara * 0.2) + (toplampara * 0.18)).ToString() + " TL";
                        bildiriücret.Parameters["nettutar"].Value = (toplampara + ((toplampara * 0.2) + (toplampara * 0.18))).ToString() + " TL";
                        bildiriücret.Parameters["ünvan"].Value = "Uzman Yeminli Tercüman";
                        bildiriücret.Parameters["isimfirma"].Value = "MUSTAFA ŞAN";
                        bildiriücret.Parameters["adresfirma"].Value = "";
                        //reportirsaliye.ExportOptions.PrintPreview.DefaultDirectory = System.Environment.CurrentDirectory;
                        bildiriücret.ExportOptions.PrintPreview.DefaultDirectory = directory;
                        bildiriücret.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                        bildiriücret.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                        bildiriücret.ExportOptions.PrintPreview.DefaultFileName = filename.Substring(0, filename.Length - 4);
                        bildiriücret.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                        report = new ReportUC(bildiriücret, model, filename);
                        report.Show();
                        break;
                }

                iscreated = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Local Dosya Oluşturuldu","Dosya Yolu = "+ directory+"\\"+filename);
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Local Dosya Oluşturma Hatası", ex.Message);
            }
            return iscreated;
        }

        public bool filltable(FilemanagementModel currentdata)
        {
            //tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            bool isadded = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["baseURL"].ToString() +controller+ "AddFile");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + WebapiUtils.access_token);
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(currentdata);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                isadded = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Yönetim tablo ekleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yönetim tablo ekleme Api Hatası", ex.Message);
            }
            return isadded;
        }

        public bool deletefile(string path)
        {
            bool isdeleted = false;
            //string pat1h = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+currentdata.Firmaadı+"\\"+currentdata.Id + "-" + currentdata.İsim + ".pdf";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                fi.Delete();
                isdeleted = true;
            }
            return isdeleted;
        }

        public bool SaveFile(string folderdesktoppath,string directory, string filenameforftp)
        {
            bool isadded = false;
            string path = ConfigurationManager.AppSettings["ftpserver"].ToString() +directory+"/"+filenameforftp;
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yükleme başladı", "");

            if (FtpDirectoryExists(directory))
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yolu mevcut yükleme başladı", "");
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("u0584616", ftppassword);
                client.UploadFile(path, folderdesktoppath);
                isadded = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yolu yüklendi", "");
            }
            else
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yolu eksik tekrar kontrol başladı", "");
                string[] paths = directory.Split('/');
                if (!FtpDirectoryExists(paths[0]))
                {
                    Makefolder(paths[0]);
                    Makefolder(paths[0] + "/" + paths[1]);
                    WebClient client = new WebClient();
                    client.Credentials = new NetworkCredential("u0584616", ftppassword);
                    client.UploadFile(path, folderdesktoppath);
                    isadded = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yolu yüklendi", "");
                }
                else
                {
                    Makefolder(paths[0] + "/" + paths[1]);
                    WebClient client = new WebClient();
                    client.Credentials = new NetworkCredential("u0584616", ftppassword);
                    client.UploadFile(path, folderdesktoppath);
                    isadded = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya yolu yüklendi", "");
                }
            }

            return isadded;
        }

        public string CheckIfFileExistsOnServer(string directory,string name)
        {
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya Kontrolü", name);

            string filename = Path.GetFileNameWithoutExtension(name);
            string fileextension = Path.GetExtension(name);
            int count = 1;
            while (true)
            {              
                try
                {
                    var request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ftpserver"].ToString() + directory + "/" + filename+fileextension);
                    request.Credentials = new NetworkCredential("u0584616", ftppassword);
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya  Mevcut yükleme yapılamaz ", "Aynı isimde dosya mevcut lütfen kayıtta değişiklik yapınız");
                    filename = filename + " "+ count;
                    count++;
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya Mevcut değil", name);
                        return filename+fileextension;
                        
                    }
                }             
            }          
        }

        private bool FtpDirectoryExists(string directory)
        {
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Klasör kontrolü başladı", directory);
            try
            {              
                List<string> directroys = new List<string>();
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ftpserver"].ToString()+directory);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential("u0584616", ftppassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();
                reader.Close();
                response.Close();
                directroys = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör mevcut", directory);
                return true;            
            }
            catch (WebException ex)
            {             
                 LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Klasör kontrol api hatası", ex.Message);                                 
            }
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör mevcut değil", directory);
            return false;
        }

        private bool Makefolder(string folder)
        {
            bool iscreated = false;
            try
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör oluşturma baslıyor", folder);
                WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["ftpserver"].ToString() + folder);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential("u0584616", ftppassword);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    iscreated = true;
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör Oluşturma tamamlandı", folder);
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör oluşturma hatası",folder +" --- " +ex.Message);
            }
            return iscreated;
            
        }

        public void DownloadFile(FilemanagementModel obj)
        {
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya indirme başladı", "");
            try
            {
                PrintingRoute route = new PrintingRoute();
                if (route.Filemanagement=="")
                {
                    LogVM.displaypopup("ERROR", "Geçerli Dosya Yolu Yok");
                    return;
                }
                string inputfilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+obj.Dosyaadı;
                string ftphost = ConfigurationManager.AppSettings["ftpserver"].ToString();
                string ftpfilepath = (obj.Mainid + "/" + obj.Klasörno+"/"+obj.Dosyaadı);

                string ftpfullpath = ftphost + ftpfilepath;

                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential("u0584616", ftppassword);
                    byte[] fileData = request.DownloadData(ftpfullpath);

                    using (FileStream file = File.Create(inputfilepath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya indirme tamamlandı", inputfilepath);
                    MessageBoxResult result = MessageBox.Show("Dosya İndirme Tamamlandı. Dosyayı Açmak İster misiniz?", "Dosya İndirme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(inputfilepath);
                    }
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya indirme tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.displaypopup("ERROR", "Dosya İndirme Hatası");
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör indirme hatası",  ex.Message);
            }
           
        }

        public bool DeleteFilefromtable(FilemanagementModel obj)
        {
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya Silme başladı", "");
            bool isdeleted = false;
            try
            {
                string ftphost = ConfigurationManager.AppSettings["ftpserver"].ToString();
                string ftpfilepath = (obj.Mainid + "/" + obj.Klasörno + "/" + obj.Dosyaadı);
                string ftpfullpath = ftphost + ftpfilepath;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                request.Credentials = new NetworkCredential("u0584616", ftppassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
                isdeleted = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "FTP Dosya Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Klasör indirme silme", ex.Message);
            }          
            return isdeleted;
        }
    }
}
