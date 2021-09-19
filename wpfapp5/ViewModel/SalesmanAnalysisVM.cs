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
    public class SalesmanAnalysisVM : BaseModel
    {
        SalesmanAnalysisDA salesmanAnalysisDA;
        public SalesmanAnalysisVM()
        {
            salesmanAnalysisDA = new SalesmanAnalysisDA();
            if (RefreshViews.appstatus)
                Loaddata(DateTime.Now.ToShortDateString());
        }

        #region Defines
        private List<SalesmanAnalysisModel> salesmansaleslist;
        public List<SalesmanAnalysisModel> Salesmansaleslist
        {
            get { return salesmansaleslist; }
            set { salesmansaleslist = value; RaisePropertyChanged("Salesmansaleslist"); }
        }

        private List<SalesmanAnalysisModel> salesmanpurchaselist;
        public List<SalesmanAnalysisModel> Salesmanpurchaselist
        {
            get { return salesmanpurchaselist; }
            set { salesmanpurchaselist = value; RaisePropertyChanged("Salesmanpurchaselist"); }
        }
    
        private List<DataPoint> datapurchasepie;
        public List<DataPoint> Datapurchasepie
        {
            get { return datapurchasepie; }
            set { datapurchasepie = value; RaisePropertyChanged("Datapurchasepie"); }
        }

        private List<DataPoint> datasalespie;
        public List<DataPoint> Datasalespie
        {
            get { return datasalespie; }
            set { datasalespie = value; RaisePropertyChanged("Datasalespie"); }
        }

        #endregion

        #region Method
        public void Loaddata(string datefilter)
        {
            try
            {
                Datasalespie = new List<DataPoint>(salesmanAnalysisDA.loadpiessales(datefilter));
                Datapurchasepie = new List<DataPoint>(salesmanAnalysisDA.loadpiepurchase(datefilter));
                Salesmansaleslist = new List<SalesmanAnalysisModel>(salesmanAnalysisDA.fillsalesmansales(datefilter));
                Salesmanpurchaselist = new List<SalesmanAnalysisModel>(salesmanAnalysisDA.fillsalesmanpurchase(datefilter));
                //RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Analiz Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Analiz Tablo Doldurma Hatası", ex.Message);
            }

        }
        #endregion

        
    }
}
