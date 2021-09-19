using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.DataAccess;
using System.Collections.ObjectModel;
using StarNote.Service;
using StarNote.Utils;
using DevExpress.Xpf.WindowsUI;
using System.Windows;

namespace StarNote.ViewModel
{
    public class AnalysisMontlyVM : BaseModel 
    {
        AnalysisMontlyDA analysisMontlyDA;
        Hedefler hedefler;
        public AnalysisMontlyVM()
        {
            analysisMontlyDA = new AnalysisMontlyDA();
            hedefler = new Hedefler();
            if (RefreshViews.appstatus)
                loaddata(DateTime.Now.ToShortDateString());
        }

        #region defines
        private AnalysisMontlyModel currentdata;
        public AnalysisMontlyModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        private List<AnalysisMontlyModel> montlyanalysis;
        public List<AnalysisMontlyModel> Montlyanalysis
        {
            get { return montlyanalysis; }
            set { montlyanalysis = value; RaisePropertyChanged("Montlyanalysis"); }
        }

        private string gaugesales;
        public string Gaugesales
        {
            get { return gaugesales; }
            set { gaugesales = value; RaisePropertyChanged("Gaugesales"); }
        }

        private string gaugepurchase;
        public string Gaugepurchase
        {
            get { return gaugepurchase; }
            set { gaugepurchase = value; RaisePropertyChanged("Gaugepurchase"); }
        }

        private string textnet;
        public string Textnet
        {
            get { return textnet; }
            set { textnet = value; RaisePropertyChanged("Textnet"); }
        }

        private string textsales;
        public string Textsales
        {
            get { return textsales; }
            set { textsales = value; RaisePropertyChanged("Textsales"); }
        }

        private string textpurchase;
        public string Textpurchase
        {
            get { return textpurchase; }
            set { textpurchase = value; RaisePropertyChanged("Textpurchase"); }
        }
        #endregion

        #region method
        public void loaddata(string date)
        {
            try
            {
                Montlyanalysis = new List<AnalysisMontlyModel>(analysisMontlyDA.FillMontlyAnalysis(date));
                string sales = analysisMontlyDA.Fillmontlygaugesales(date);
                string purchase = analysisMontlyDA.Fillmontlygaugepurchase(date);
                if (sales.Trim() == string.Empty)
                    sales = "0";
                if (purchase.Trim() == string.Empty)
                    purchase = "0";
                Textsales = sales + " TL";
                Textpurchase = purchase + " TL";
                Textnet = analysisMontlyDA.Fillmontlygaugenet(date) + " TL ";

                double yüzdedegersales = Math.Round(((100 * Convert.ToDouble(sales, System.Globalization.CultureInfo.InvariantCulture)) / hedefler.MonthlyAnalysisKAZANÇ), 0);
                if (yüzdedegersales > 100.0)
                    Gaugesales = "100";
                else
                    Gaugesales = yüzdedegersales.ToString().Replace('.', ',');
                double yüzdedegerpurchase = Math.Round(((100 * Convert.ToDouble(purchase, System.Globalization.CultureInfo.InvariantCulture)) / hedefler.MonthlyAnalysisHARCAMA), 0);
                if (yüzdedegerpurchase > 100.0)
                    Gaugepurchase = "100";
                else
                    Gaugepurchase = yüzdedegerpurchase.ToString().Replace('.', ',');
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Tablo doldurma Hatası", ex.Message);
            }

        }
        #endregion

    }
}
