using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StarNote.Command;
using StarNote.Model;
using StarNote.Utils;
using StarNote.View;
using StarNote.Service;

namespace StarNote.ViewModel
{
    public class HedefVM : BaseModel
    {
        Hedefler hedeflersetting = new Hedefler();
        public HedefVM()
        {
            if (RefreshViews.appstatus)
                loaddata();
            currentdata = new HedefModel();
          
        }

        #region Defines
        private List<HedefModel> hedeflerlist;
        public List<HedefModel> Hedeflerlist
        {
            get { return hedeflerlist; }
            set { hedeflerlist = value; RaisePropertyChanged("Hedeflerlist"); }
        }

        private HedefModel currentdata;
        public HedefModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }
        
        #endregion

        #region method
        private List<HedefModel> filllist()
        {
            List<HedefModel> list = new List<HedefModel>();
            list.Add(new HedefModel { Id = 1, Hedefname = "Günlük Kredi kart Satın alımı", Hedef = hedeflersetting.DailyPurchaseKREDİ_KARTI });
            list.Add(new HedefModel { Id = 2, Hedefname = "Günlük Çek Satın alımı", Hedef = hedeflersetting.DailyPurchaseÇEK });
            list.Add(new HedefModel { Id = 3, Hedefname = "Günlük Senet  Satın alımı", Hedef = hedeflersetting.DailyPurchaseSENET });
            list.Add(new HedefModel { Id = 4, Hedefname = "Günlük Nakit Satın alımı", Hedef = hedeflersetting.DailyPurchaseNAKİT });
            list.Add(new HedefModel { Id = 5, Hedefname = "Günlük Kredi kart Satış", Hedef = hedeflersetting.DailySalesKREDİ_KARTI });
            list.Add(new HedefModel { Id = 6, Hedefname = "Günlük Çek Satış", Hedef = hedeflersetting.DailySalesÇEK });
            list.Add(new HedefModel { Id = 7, Hedefname = "Günlük Senet Satış", Hedef = hedeflersetting.DailySalesSENET });
            list.Add(new HedefModel { Id = 8, Hedefname = "Günlük Nakit Satış", Hedef = hedeflersetting.DailySalesNAKİT });
            list.Add(new HedefModel { Id = 9, Hedefname = "Aylık Satın Alma", Hedef = hedeflersetting.MonthlyAnalysisHARCAMA });
            list.Add(new HedefModel { Id = 10, Hedefname = "Aylık Satış", Hedef = hedeflersetting.MonthlyAnalysisKAZANÇ });
            list.Add(new HedefModel { Id = 11, Hedefname = "Aylık Net Gelir ", Hedef = hedeflersetting.MonthlyAnalysisNET_DEĞER });
            list.Add(new HedefModel { Id = 12, Hedefname = "Yıllık Satın Alma", Hedef = hedeflersetting.YearlyAnalysisHARCAMA });
            list.Add(new HedefModel { Id = 13, Hedefname = "Yıllık Satış", Hedef = hedeflersetting.YearlyAnalysisKAZANÇ });
            list.Add(new HedefModel { Id = 14, Hedefname = "Yıllık Net Gelir", Hedef = hedeflersetting.YearlyAnalysisNET_DEĞER });
            return list;
        }

        public void loaddata()
        {
            try
            {
                Hedeflerlist = new List<HedefModel>(filllist());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hedefler Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hedefler Tablo doldurma Hatası", ex.Message);
            }
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                int selectedvar = currentdata.Id;               
                switch (selectedvar)
                {
                    case 1: hedeflersetting.DailyPurchaseKREDİ_KARTI = currentdata.Hedef; break;
                    case 2: hedeflersetting.DailyPurchaseÇEK = currentdata.Hedef; break;
                    case 3: hedeflersetting.DailyPurchaseSENET = currentdata.Hedef; break;
                    case 4: hedeflersetting.DailyPurchaseNAKİT = currentdata.Hedef; break;
                    case 5: hedeflersetting.DailySalesKREDİ_KARTI = currentdata.Hedef; break;
                    case 6: hedeflersetting.DailySalesÇEK = currentdata.Hedef; break;
                    case 7: hedeflersetting.DailySalesSENET = currentdata.Hedef; break;
                    case 8: hedeflersetting.DailySalesNAKİT = currentdata.Hedef; break;
                    case 9: hedeflersetting.MonthlyAnalysisHARCAMA = currentdata.Hedef; break;
                    case 10: hedeflersetting.MonthlyAnalysisKAZANÇ = currentdata.Hedef; break;
                    case 11: hedeflersetting.MonthlyAnalysisNET_DEĞER = currentdata.Hedef; break;
                    case 12: hedeflersetting.YearlyAnalysisHARCAMA = currentdata.Hedef; break;
                    case 13: hedeflersetting.YearlyAnalysisKAZANÇ = currentdata.Hedef; break;
                    case 14: hedeflersetting.YearlyAnalysisNET_DEĞER = currentdata.Hedef; break;

                }
                hedeflersetting.Save();
                loaddata();
                isok = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Hedefler Tablo Güncelleme Yapıldı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Hedefler Tablo Güncelleme Yapıldı", ex.Message);
            }
            return isok;
        }
        #endregion
    }
}
