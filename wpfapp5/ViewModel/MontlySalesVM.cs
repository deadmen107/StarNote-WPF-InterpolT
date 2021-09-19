using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StarNote.Model;
using StarNote.Command;
using DevExpress.Charts;
using StarNote.DataAccess;
using StarNote.Service;
using DevExpress.Xpf.WindowsUI;
using System.Windows;

namespace StarNote.ViewModel
{
    public class MontlySalesVM : BaseModel
    {
        MontlyAccountingDA montlyAccountingDA;
        public MontlySalesVM()
        {
            montlyAccountingDA = new MontlyAccountingDA();
            if (RefreshViews.appstatus)
                loaddata(DateTime.Now.ToShortDateString());
        }

        #region defines
        private List<MontlyAccountingModel> montlysaleslistsales;
        public List<MontlyAccountingModel> Montlysaleslistsales
        {
            get { return montlysaleslistsales; }
            set { montlysaleslistsales = value; RaisePropertyChanged("Montlysaleslistsales"); }
        }

        private List<DataPoint> datasaleschart;
        public List<DataPoint> Datasaleschart
        {
            get { return datasaleschart; }
            set { datasaleschart = value; RaisePropertyChanged("Datasaleschart"); }
        }


        private List<DataPoint> datasalespie;
        public List<DataPoint> Datasalespie
        {
            get { return datasalespie; }
            set { datasalespie = value; RaisePropertyChanged("Datasalespie"); }
        }
        #endregion

        #region Method
        public void loaddata(string date)
        {
            try
            {
                Datasalespie = new List<DataPoint>(montlyAccountingDA.loadpiessales(date));
                Datasaleschart = new List<DataPoint>(montlyAccountingDA.loadchartssales(date));
                Montlysaleslistsales = new List<MontlyAccountingModel>(montlyAccountingDA.Montlysalesfillsales(date));
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Satış Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Satış Tablo Doldurma Hatası", ex.Message);
            }
        }
        #endregion


    }  
}
