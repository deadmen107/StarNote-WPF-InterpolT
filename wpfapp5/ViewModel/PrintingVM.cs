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
            list.Add(new PrintingModel { Id = 1, Rapor = "Genel Takip Ekranı", Dosyayolu = printingRoute.MainGrid });
            list.Add(new PrintingModel { Id = 2, Rapor = "Günlük Satın Alma", Dosyayolu = printingRoute.DailyPurchase });
            list.Add(new PrintingModel { Id = 3, Rapor = "Günlük Satış", Dosyayolu = printingRoute.DailySales });
            list.Add(new PrintingModel { Id = 4, Rapor = "Aylık Satın Alma", Dosyayolu = printingRoute.MontlyPurchase });
            list.Add(new PrintingModel { Id = 5, Rapor = "Aylık Satış", Dosyayolu = printingRoute.MontlySales });
            list.Add(new PrintingModel { Id = 6, Rapor = "Aylık Analiz", Dosyayolu = printingRoute.AnalysisMontly });
            list.Add(new PrintingModel { Id = 7, Rapor = "Yıllık Analiz", Dosyayolu = printingRoute.AnalysisYearly });
            list.Add(new PrintingModel { Id = 8, Rapor = "Personel Analiz", Dosyayolu = printingRoute.AnalysisSalesman });
            list.Add(new PrintingModel { Id = 9, Rapor = "Potansiyel Analiz", Dosyayolu = printingRoute.AnalysisPotansial });
            list.Add(new PrintingModel { Id = 10, Rapor = "Stok", Dosyayolu = printingRoute.Stok });
            list.Add(new PrintingModel { Id = 11, Rapor = "Tür", Dosyayolu = printingRoute.Tür });
            list.Add(new PrintingModel { Id = 12, Rapor = "Personel", Dosyayolu = printingRoute.Satış_Görevli });
            list.Add(new PrintingModel { Id = 13, Rapor = "Firmalar", Dosyayolu = printingRoute.Firmalar });
            list.Add(new PrintingModel { Id = 14, Rapor = "Kullanıcılar", Dosyayolu = printingRoute.Kullanıcılar });
            list.Add(new PrintingModel { Id = 15, Rapor = "Müşteriler", Dosyayolu = printingRoute.Müşteriler });
            list.Add(new PrintingModel { Id = 16, Rapor = "Dosya Takip", Dosyayolu = printingRoute.Dosya_Takip });
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
                    case 1: printingRoute.MainGrid = currentdata.Dosyayolu; break;
                    case 2: printingRoute.DailyPurchase = currentdata.Dosyayolu; break;
                    case 3: printingRoute.DailySales = currentdata.Dosyayolu; break;
                    case 4: printingRoute.MontlyPurchase = currentdata.Dosyayolu; break;
                    case 5: printingRoute.MontlySales = currentdata.Dosyayolu; break;
                    case 6: printingRoute.AnalysisMontly = currentdata.Dosyayolu; break;
                    case 7: printingRoute.AnalysisYearly = currentdata.Dosyayolu; break;
                    case 8: printingRoute.AnalysisSalesman = currentdata.Dosyayolu; break;
                    case 9: printingRoute.AnalysisPotansial = currentdata.Dosyayolu; break;
                    case 10: printingRoute.Stok = currentdata.Dosyayolu; break;
                    case 11: printingRoute.Tür = currentdata.Dosyayolu; break;
                    case 12: printingRoute.Satış_Görevli = currentdata.Dosyayolu; break;
                    case 13: printingRoute.Firmalar = currentdata.Dosyayolu; break;
                    case 14: printingRoute.Kullanıcılar = currentdata.Dosyayolu; break;
                    case 15: printingRoute.Müşteriler = currentdata.Dosyayolu; break;
                    case 16: printingRoute.Dosya_Takip = currentdata.Dosyayolu; break;

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
    

