using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using System.Collections.ObjectModel;
using StarNote.DataAccess;
using StarNote.Service;
using StarNote.Utils;
using DevExpress.Xpf.WindowsUI;
using System.Windows;

namespace StarNote.ViewModel
{
    public class DailySalesVM : BaseModel
    {
        Hedefler hedefler;
        DailyAccountingDA dailysalesDA;
        public DailySalesVM()
        {
            dailysalesDA = new DailyAccountingDA();
            hedefler = new Hedefler();
            if (RefreshViews.appstatus)
                loaddata(DateTime.Now.ToShortDateString());
        }

        #region Defines

        private string gaugekredikart;
        public string Gaugekredikart
        {
            get { return gaugekredikart; }
            set { gaugekredikart = value; RaisePropertyChanged("Gaugekredikart"); }
        }

        private string gaugeçek;
        public string Gaugeçek
        {
            get { return gaugeçek; }
            set { gaugeçek = value; RaisePropertyChanged("Gaugeçek"); }
        }

        private string gaugesenet;
        public string Gaugesenet
        {
            get { return gaugesenet; }
            set { gaugesenet = value; RaisePropertyChanged("Gaugesenet"); }
        }

        private string gaugenakit;
        public string Gaugenakit
        {
            get { return gaugenakit; }
            set { gaugenakit = value; RaisePropertyChanged("Gaugenakit"); }
        }

        private List<DailyAccountingModel> dailysaleslistsales;
        public List<DailyAccountingModel> Dailysaleslistsales
        {
            get { return dailysaleslistsales; }
            set { dailysaleslistsales = value; RaisePropertyChanged("Dailysaleslistsales"); }
        }

        #endregion

        #region method

        public Tuple<string, string> caountgaugevalues()
        {
            return Tuple.Create("", "");
        }

        public void loaddata(string date)
        {
            try
            {

                hedefler = new Hedefler();
                Dailysaleslistsales = new List<DailyAccountingModel>(dailysalesDA.dailysalesfill(date));
                List<GaugeModel> gaugelist = new List<GaugeModel>();
                gaugelist = new List<GaugeModel>(dailysalesDA.dailygaugesalesfill(date));
                foreach (var item in gaugelist)
                {
                    double yüzdedeger;
                    if (item.Gaugevalue == null || item.Gaugevalue.Trim() == string.Empty)
                    {
                        item.Gaugevalue = "0";
                    }
                    switch (item.Gaugename)
                    {
                        case "KREDI KARTI":

                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailySalesKREDİ_KARTI), 0);
                            if (yüzdedeger > 100.0)
                                Gaugekredikart = "100";
                            else
                                Gaugekredikart = yüzdedeger.ToString();
                            break;
                        case "ÇEK":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailySalesÇEK), 0);
                            if (yüzdedeger > 100.0)
                                Gaugeçek = "100";
                            else
                                Gaugeçek = yüzdedeger.ToString();
                            break;
                        case "SENET":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailySalesSENET), 0);
                            if (yüzdedeger > 100.0)
                                Gaugesenet = "100";
                            else
                                Gaugesenet = yüzdedeger.ToString();
                            break;
                        case "NAKİT":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailySalesNAKİT), 0);
                            if (yüzdedeger > 100.0)
                                Gaugenakit = "100";
                            else
                                Gaugenakit = yüzdedeger.ToString();
                            break;
                    }
                }
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satış Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satış Tablo doldurma Hatası", ex.Message);
            }
        }

        #endregion

    }
}
