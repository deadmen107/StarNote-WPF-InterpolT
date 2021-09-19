using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.DataAccess;
using StarNote.Service;
using DevExpress.Xpf.WindowsUI;
using System.Windows;

namespace StarNote.ViewModel
{
    public class MontlyPurchaseVM : BaseModel 
    {
        MontlyAccountingDA montlyAccountingDA;
        public MontlyPurchaseVM()
        {
            montlyAccountingDA = new MontlyAccountingDA();
            if (RefreshViews.appstatus)
                loaddata(DateTime.Now.ToShortDateString());
        }

        #region Defines
        private List<MontlyAccountingModel> montlysaleslistpurchase;
        public List<MontlyAccountingModel> Montlysaleslistpurchase
        {
            get { return montlysaleslistpurchase; }
            set { montlysaleslistpurchase = value; RaisePropertyChanged("Montlysaleslistpurchase"); }
        }

        private List<DataPoint> datapurchasechart;
        public List<DataPoint> Datapurchasechart
        {
            get { return datapurchasechart; }
            set { datapurchasechart = value; RaisePropertyChanged("Datapurchasechart"); }
        }

        private List<DataPoint> datapurchasepie;
        public List<DataPoint> Datapurchasepie
        {
            get { return datapurchasepie; }
            set { datapurchasepie = value; RaisePropertyChanged("Datapurchasepie"); }
        }
        #endregion

        #region method
        public void loaddata(string date)
        {
            try
            {
                Datapurchasepie = new List<DataPoint>(montlyAccountingDA.loadpiepurchase(date));
                Datapurchasechart = new List<DataPoint>(montlyAccountingDA.loadchartspurchase(date));
                Montlysaleslistpurchase = new List<MontlyAccountingModel>(montlyAccountingDA.Montlysalesfillpurchase(date));
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Satın Alma Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Satın Alma Tablo Doldurma Hatası", ex.Message);
            }
        }
        #endregion
    }
}
