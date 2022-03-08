using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Utils;
using StarNote.Model;
using StarNote.Command;
using DevExpress.Xpf.WindowsUI;
using System.Windows;
using StarNote.Service;

namespace StarNote.ViewModel
{
    public  class PrintingVM : BaseModel
    {

        PrintingRoute printingRoute = new PrintingRoute();
        public PrintingVM()
        {
            if (RefreshViews.appstatus)
                loaddata();
            currentdata = new PrintingModel();
           
        }

        #region Defines
        private List<PrintingModel> printlist;
        public List<PrintingModel> Printlist
        {
            get { return printlist; }
            set { printlist = value; RaisePropertyChanged("Printlist"); }
        }

        private PrintingModel currentdata;
        public PrintingModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }
        
        #endregion

        #region Method
        private List<PrintingModel> filllist()
        {
            List<PrintingModel> list = new List<PrintingModel>();
            list.Add(new PrintingModel { Id = 1, Rapor = "Adliye Kayıtları", Dosyayolu = printingRoute.Adliye });
            list.Add(new PrintingModel { Id = 2, Rapor = "Özel Müşteri Kayıtları", Dosyayolu = printingRoute.Özel });
            list.Add(new PrintingModel { Id = 3, Rapor = "Firma Kayıtları", Dosyayolu = printingRoute.Firma });
            list.Add(new PrintingModel { Id = 4, Rapor = "Harcama Kayıtları", Dosyayolu = printingRoute.Harcama });
            list.Add(new PrintingModel { Id = 5, Rapor = "Dosyalar", Dosyayolu = printingRoute.Dosyalar });
            list.Add(new PrintingModel { Id = 6, Rapor = "Diller", Dosyayolu = printingRoute.Diller });
            list.Add(new PrintingModel { Id = 7, Rapor = "Hatırlatmalar", Dosyayolu = printingRoute.Hatırlatmalar });
            list.Add(new PrintingModel { Id = 8, Rapor = "Eski Hatırlatmalar", Dosyayolu = printingRoute.Eskihatırlatmalar });
            list.Add(new PrintingModel { Id = 9, Rapor = "Günlük Giderler", Dosyayolu = printingRoute.günlükgider });
            list.Add(new PrintingModel { Id = 10, Rapor = "Günlük Gelirler", Dosyayolu = printingRoute.günlükgelir });
            list.Add(new PrintingModel { Id = 11, Rapor = "Aylık Giderler", Dosyayolu = printingRoute.aylıkgider });
            list.Add(new PrintingModel { Id = 12, Rapor = "Aylık Gelirler", Dosyayolu = printingRoute.aylıkgelir });
            list.Add(new PrintingModel { Id = 13, Rapor = "Aylık İş Analiz", Dosyayolu = printingRoute.aylıkişanaliz });
            list.Add(new PrintingModel { Id = 14, Rapor = "Yıllık İş Analiz", Dosyayolu = printingRoute.yıllıkizanaliz });
            list.Add(new PrintingModel { Id = 15, Rapor = "Terüman Analiz", Dosyayolu = printingRoute.tercümananaliz });
            list.Add(new PrintingModel { Id = 16, Rapor = "Tanımlı Tercümanlar", Dosyayolu = printingRoute.tercümanlar });
            list.Add(new PrintingModel { Id = 17, Rapor = "Tanımlı Adliyeler", Dosyayolu = printingRoute.adliyeler });
            list.Add(new PrintingModel { Id = 18, Rapor = "Tanımlı Mahkemeler", Dosyayolu = printingRoute.mahkemeler });
            list.Add(new PrintingModel { Id = 19, Rapor = "Tanımlı Şirketler", Dosyayolu = printingRoute.tanımlısirketler });
            list.Add(new PrintingModel { Id = 20, Rapor = "Tanımlı Tanımlı Müşteriler", Dosyayolu = printingRoute.tanımlımüsteriter });
            list.Add(new PrintingModel { Id = 21, Rapor = "Tanımlı Belgeler", Dosyayolu = printingRoute.belgeler });
            list.Add(new PrintingModel { Id = 22, Rapor = "Tanımlı Kullanıcılar", Dosyayolu = printingRoute.kullanıcılar });
            list.Add(new PrintingModel { Id = 23, Rapor = "Dosya İndirme", Dosyayolu = printingRoute.Filemanagement });
            return list;
        }

        public void loaddata()
        {
            try
            {
                Printlist = new List<PrintingModel>(filllist());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Yazdırma Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Yazdırma Tablo Doldurma Hatası", ex.Message);
            }
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                int selectedvar = currentdata.Id;
                //System.Windows.MessageBox.Show(selectedvar.ToString());
                switch (selectedvar)
                {
                    case 1: printingRoute.Adliye = currentdata.Dosyayolu; break;
                    case 2: printingRoute.Özel = currentdata.Dosyayolu; break;
                    case 3: printingRoute.Firma = currentdata.Dosyayolu; break;
                    case 4: printingRoute.Harcama = currentdata.Dosyayolu; break;
                    case 5: printingRoute.Dosyalar = currentdata.Dosyayolu; break;
                    case 6: printingRoute.Diller = currentdata.Dosyayolu; break;
                    case 7: printingRoute.Hatırlatmalar = currentdata.Dosyayolu; break;
                    case 8: printingRoute.Eskihatırlatmalar = currentdata.Dosyayolu; break;
                    case 9: printingRoute.günlükgider = currentdata.Dosyayolu; break;
                    case 10: printingRoute.günlükgelir = currentdata.Dosyayolu; break;
                    case 11: printingRoute.aylıkgider = currentdata.Dosyayolu; break;
                    case 12: printingRoute.aylıkgelir = currentdata.Dosyayolu; break;
                    case 13: printingRoute.aylıkişanaliz = currentdata.Dosyayolu; break;
                    case 14: printingRoute.yıllıkizanaliz = currentdata.Dosyayolu; break;
                    case 15: printingRoute.tercümananaliz = currentdata.Dosyayolu; break;
                    case 16: printingRoute.tercümanlar = currentdata.Dosyayolu; break;
                    case 17: printingRoute.adliyeler = currentdata.Dosyayolu; break;
                    case 18: printingRoute.mahkemeler = currentdata.Dosyayolu; break;
                    case 19: printingRoute.tanımlısirketler = currentdata.Dosyayolu; break;
                    case 20: printingRoute.tanımlımüsteriter = currentdata.Dosyayolu; break;
                    case 21: printingRoute.belgeler = currentdata.Dosyayolu; break;
                    case 22: printingRoute.kullanıcılar = currentdata.Dosyayolu; break;
                    case 23: printingRoute.Filemanagement = currentdata.Dosyayolu; break;
                }
                printingRoute.Save();
                //printingRoute.Reload();
                loaddata();
                isok = true;               
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Yeni Dosya Yolu Oluşturuldu", "");

            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Yeni Dosya Yolu Güncelleme Hatası", ex.Message);
            }
            return isok;
        }
        #endregion




    }
}
    

