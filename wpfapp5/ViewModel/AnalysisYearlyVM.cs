using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using StarNote.Utils;
namespace StarNote.ViewModel
{
    public class AnalysisYearlyVM : BaseModel
    {
        AnalysisYearlyDA analysisYearlyDA;
        Hedefler hedefler;
        public AnalysisYearlyVM()
        {
            analysisYearlyDA = new AnalysisYearlyDA();
            hedefler = new Hedefler();
            if (RefreshViews.appstatus)
                loaddata(DateTime.Now.ToShortDateString());
        }

        #region Defines
        private AnalysisYearlyModel currentdata;
        public AnalysisYearlyModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        private List<AnalysisYearlyModel> yearlyanalysis;
        public List<AnalysisYearlyModel> Yearlyanalysis
        {
            get { return yearlyanalysis; }
            set { yearlyanalysis = value; RaisePropertyChanged("Yearlyanalysis"); }
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
                Yearlyanalysis = new List<AnalysisYearlyModel>(analysisYearlyDA.FillYearlyAnalysis(date));
                string sales = analysisYearlyDA.Fillyearlygaugesales(date);
                string purchase = analysisYearlyDA.Fillyearlygaugepurchase(date);
                if (sales.Trim() == string.Empty)
                    sales = "0";
                if (purchase.Trim() == string.Empty)
                    purchase = "0";
                Textsales = sales + " TL";
                Textpurchase = purchase + " TL";
                Textnet = analysisYearlyDA.Fillyearlygaugenet(date) + " TL ";
                double yüzdedegersales = Math.Round(((100 * Convert.ToDouble(sales, System.Globalization.CultureInfo.InvariantCulture)) / hedefler.YearlyAnalysisKAZANÇ), 0);
                if (yüzdedegersales > 100.0)
                    Gaugesales = "100";
                else
                    Gaugesales = yüzdedegersales.ToString();
                double yüzdedegerpurchase = Math.Round(((100 * Convert.ToDouble(purchase, System.Globalization.CultureInfo.InvariantCulture)) / hedefler.YearlyAnalysisHARCAMA), 0);
                if (yüzdedegerpurchase > 100.0)
                    Gaugepurchase = "100";
                else
                    Gaugepurchase = yüzdedegerpurchase.ToString();
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Yıllık Analiz Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Yıllık Analiz Tablo doldurma Hatası", ex.Message);
            }
        }
        #endregion

    }
}
