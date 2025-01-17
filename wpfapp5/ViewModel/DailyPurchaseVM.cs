﻿using DevExpress.Xpf.WindowsUI;
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
    public class DailyPurchaseVM : BaseModel
    {
        Hedefler hedefler;
        DailyAccountingDA dailysalesDA;
        MainService mainda;
        public DailyPurchaseVM()
        {
            dailysalesDA = new DailyAccountingDA();
            mainda = new MainService();
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

        private List<string> ödemesourcelist;
        public List<string> Ödemesourcelist
        {
            get { return ödemesourcelist; }
            set { ödemesourcelist = value; RaisePropertyChanged("Ödemesourcelist"); }
        }


        private List<string> salesmansourcelist;
        public List<string> Salesmansourcelist
        {
            get { return salesmansourcelist; }
            set { salesmansourcelist = value; RaisePropertyChanged("Salesmansourcelist"); }
        }

        private List<string> birimsourcelist;
        public List<string> Birimsourcelist
        {
            get { return birimsourcelist; }
            set { birimsourcelist = value; RaisePropertyChanged("Birimsourcelist"); }
        }

        private OrderModel currentdata;
        public OrderModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        private List<DailyAccountingModel> dailysaleslistpurchase;
        public List<DailyAccountingModel> Dailysaleslistpurchase
        {
            get { return dailysaleslistpurchase; }
            set { dailysaleslistpurchase = value; RaisePropertyChanged("Dailysaleslistpurchase"); }
        }

        #endregion

        #region method
        private void fillgauges()
        {

        }

        public void fillcurrentdata(int ID)
        {
            Currentdata = dailysalesDA.Getselectedrecord(ID);
        }

        public void loaddata(string date)
        {
            try
            {
                hedefler = new Hedefler();                
                Dailysaleslistpurchase = new List<DailyAccountingModel>(dailysalesDA.dailypurchasefill(date));
                List<GaugeModel> gaugelist = new List<GaugeModel>();
                gaugelist = new List<GaugeModel>(dailysalesDA.dailygaugepurchasefill(date));
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

                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailyPurchaseKREDİ_KARTI), 0);
                            if (yüzdedeger > 100.0)
                                Gaugekredikart = "100";
                            else
                                Gaugekredikart = yüzdedeger.ToString();
                            break;
                        case "ÇEK":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailyPurchaseÇEK), 0);
                            if (yüzdedeger > 100.0)
                                Gaugeçek = "100";
                            else
                                Gaugeçek = yüzdedeger.ToString();
                            break;
                        case "SENET":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailyPurchaseSENET), 0);
                            if (yüzdedeger > 100.0)
                                Gaugesenet = "100";
                            else
                                Gaugesenet = yüzdedeger.ToString();
                            break;
                        case "NAKİT":
                            yüzdedeger = Math.Round(((100 * Convert.ToDouble(item.Gaugevalue)) / hedefler.DailyPurchaseNAKİT), 0);
                            if (yüzdedeger > 100.0)
                                Gaugenakit = "100";
                            else
                                Gaugenakit = yüzdedeger.ToString();
                            break;
                    }
                }
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Günlük Satın Alma Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Günlük Satın Alma Tablo doldurma Hatası", ex.Message);
            }       
        }
        
        #endregion
    }
}
