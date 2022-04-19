using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using StarNote.Command;
using StarNote.Utils;

namespace StarNote.ViewModel
{
    public class MontlyAnalysisVM : BaseModel
    {
        BaseDa dataaccess;
        Hedefler hedefler;

        public MontlyAnalysisVM()
        {
            dataaccess = new BaseDa();
            hedefler = new Hedefler();
            DeleteThanksCommand = new RelayCommand<object>((parms) => DeleteThanks(parms), parms => CanDeleteThanks());
            Doreportcommand = new RelayCommand(DoReport);
            Selectionchangedtabindex = new RelayCommand(Loaddata);
            Startdate = new DateTime(DateTime.Now.Year-1, DateTime.Now.Month, 1);
            Enddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1);
            Loaddata();
        }


        #region Defines

        #region Commands

        private RelayCommand selectionchangedtabindex;
        public RelayCommand Selectionchangedtabindex
        {
            get { return selectionchangedtabindex; }
            set { selectionchangedtabindex = value; RaisePropertyChanged("Selectionchangedtabindex"); }
        }



        

public RelayCommand<object> DeleteThanksCommand { get; private set; }

        private RelayCommand doreportcommand;
        public RelayCommand Doreportcommand
        {
            get { return doreportcommand; }
            set { doreportcommand = value; RaisePropertyChanged("Doreportcommand"); }
        }

        #endregion

        #region UI Defines

        private int titleindex;
        public int Titleindex
        {
            get { return titleindex; }
            set { titleindex = value; RaisePropertyChanged("Titleindex"); }
        }

        private int subtitleindex;
        public int Subtitleindex
        {
            get { return subtitleindex; }
            set { subtitleindex = value; RaisePropertyChanged("Subtitleindex"); }
        }

        private DateTime startdate;
        public DateTime Startdate
        {
            get { return startdate; }
            set { startdate = value; RaisePropertyChanged("Startdate"); }
        }

        private DateTime enddate;
        public DateTime Enddate
        {
            get { return enddate; }
            set { enddate = value; RaisePropertyChanged("Enddate"); }
        }

        private int totalprocesscount;
        public int Totalprocesscount
        {
            get { return totalprocesscount; }
            set { totalprocesscount = value; RaisePropertyChanged("Totalprocesscount"); }
        }

        private int totalgivenfileordercount;
        public int Totalgivenfileordercount
        {
            get { return totalgivenfileordercount; }
            set { totalgivenfileordercount = value; RaisePropertyChanged("Totalgivenfileordercount"); }
        }

        private double potansialworth;
        public double Potansialworth
        {
            get { return potansialworth; }
            set { potansialworth = value; RaisePropertyChanged("Potansialworth"); }
        }

        private double realworth;
        public double Realworth
        {
            get { return realworth; }
            set { realworth = value; RaisePropertyChanged("Realworth"); }
        }

        private double networth;
        public double Networth
        {
            get { return networth; }
            set { networth = value; RaisePropertyChanged("Networth"); }
        }

        private double minusworth;
        public double Minusworth
        {
            get { return minusworth; }
            set { minusworth = value; RaisePropertyChanged("Minusworth"); }
        }

        private string networthgauge;
        public string Networthgauge
        {
            get { return networthgauge; }
            set { networthgauge = value; RaisePropertyChanged("Networthgauge"); }
        }

        private string minusworthgauge;
        public string Minusworthgauge
        {
            get { return minusworthgauge; }
            set { minusworthgauge = value; RaisePropertyChanged("Minusworthgauge"); }
        }

        private List<AnalysisMontlyModel> griddataworths;
        public List<AnalysisMontlyModel> Griddataworths
        {
            get { return griddataworths; }
            set { griddataworths = value; RaisePropertyChanged("Griddataworths"); }
        }

        private List<AnalysisMontlyModel> gridatasubproducts;
        public List<AnalysisMontlyModel> Gridatasubproducts
        {
            get { return gridatasubproducts; }
            set { gridatasubproducts = value; RaisePropertyChanged("Gridatasubproducts"); }
        }


        private List<AnalysisMontlyModel> griddataproducts;
        public List<AnalysisMontlyModel> Griddataproducts
        {
            get { return griddataproducts; }
            set { griddataproducts = value; RaisePropertyChanged("Griddataproducts"); }
        }

        private List<DataPoint> datachart;
        public List<DataPoint> Datachart
        {
            get { return datachart; }
            set { datachart = value; RaisePropertyChanged("Datachart"); }
        }

        private List<OrderModel> recorddataorder;
        public List<OrderModel> Recorddataorder
        {
            get { return recorddataorder; }
            set { recorddataorder = value; RaisePropertyChanged("Griddata"); }
        }

        private List<CostumerOrderModel> recorddatacostumer;
        public List<CostumerOrderModel> Recorddatacostumer
        {
            get { return recorddatacostumer; }
            set { recorddatacostumer = value; RaisePropertyChanged("Recorddatacostumer"); }
        }

        private List<JobOrderModel> recorddatajoborder;
        public List<JobOrderModel> Recorddatajoborder
        {
            get { return recorddatajoborder; }
            set { recorddatajoborder = value; RaisePropertyChanged("Recorddatajoborder"); }
        }

        #endregion

        #region Report Defines

        #endregion

        #endregion

        #region Methods

        #region UI Methods

        public void Loaddata()
        {
            ManageBigData(Titleindex, Startdate, Enddate);
            ManagePartialData(subtitleindex);

        }

        private bool IsBetween(DateTime value, DateTime min, DateTime max)
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
        }

        private void ManageBigData(int titleindex,DateTime startdate, DateTime enddate)
        {
            Recorddataorder = new List<OrderModel>();
            Recorddatacostumer = new List<CostumerOrderModel>();
            Recorddatajoborder = new List<JobOrderModel>();
            
            foreach (var item in GlobalStore.Maindataorder)
            {
                if (IsBetween(Convert.ToDateTime(item.Costumerorder.Kayıttarihi).Date,startdate.Date,enddate.Date))
                {
                    Recorddataorder.Add(item);
                    Recorddatacostumer.Add(item.Costumerorder);
                    Recorddatajoborder.AddRange(item.Joborder);
                }
            }
            switch (titleindex)
            {
                case 0:  //Genel
                   
                    break;
                case 1: //Adliye
                    Recorddataorder = Recorddataorder.Where(u=>u.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && u.Costumerorder.Tür != "ŞİRKETLER" && u.Costumerorder.Savetype==0).ToList();
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür != "ÖZEL MÜŞTERİLER" && u.Tür != "ŞİRKETLER" && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 2: //Özel
                    Recorddataorder = Recorddataorder.Where(u => u.Costumerorder.Tür == "ÖZEL MÜŞTERİLER"  && u.Costumerorder.Savetype == 0).ToList();
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür == "ÖZEL MÜŞTERİLER"  && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 3: //Firma
                    Recorddataorder = Recorddataorder.Where(u =>  u.Costumerorder.Tür == "ŞİRKETLER" && u.Costumerorder.Savetype == 0).ToList();
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür == "ŞİRKETLER" && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 4:  //Özel İşlemler
                    Recorddataorder = Recorddataorder.Where(u => u.Costumerorder.Tür == "ŞİRKETLER" && u.Costumerorder.Savetype == 0).ToList();
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür == "ŞİRKETLER" && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
            }
        }

        private void ManagePartialData(int subtitleindex)
        {
            switch (subtitleindex)
            {
                case 0:   //NET
                    fillcharttable();
                    FillWidgetsNet();                    
                    break;
                case 1:   //GELİR
                    FillWidgetsSales();
                    break;
                case 2:  //GİDER
                    FillWidgetsPurchase();
                    break;
            }
        }

        private void fillcharttable()
        {
            Datachart = (from s in Recorddatacostumer
                         group s by Convert.ToDateTime(s.Kayıttarihi).Date into g
                                    select new DataPoint
                                    {
                                        Argument = g.Key.ToShortDateString(),
                                        Value = g.Sum(x => x.Ücret)
                                    }).ToList();
            //var item =   (from s in Recorddatacostumer
            //              group s by Convert.ToDateTime(s.Kayıttarihi).Date into g
            //              join c in Recorddatajoborder on g.FirstOrDefault().Id equals c.Üstid
            //              select new 
            //              {
            //                  Argument = g.Key.ToShortDateString(),
            //                  Price = g.FirstOrDefault().Ücret,
            //                  Value = c.Ürün2detay.ToList()
            //              }).ToList();
            //var item = (from s in Recorddatacostumer
            //            join c in Recorddatajoborder on s.Id equals c.Üstid
            //            group s by new { Convert.ToDateTime(s.Kayıttarihi).Date, c.Ürün2detay } into g
            //            select new
            //            {                            
            //                Id= g.Select(u=>u.Id).FirstOrDefault(),
            //                Price = g.Select(u => u.Ücret).FirstOrDefault(),
            //                Argument = g.Key.Date.ToShortDateString(),
            //                Value = g.Key.Ürün2detay,
            //            }).ToList();

            //var itemm = (from s in item
            //             group s by new { s.Argument , s.Id  } into g
            //             select new
            //             {
            //                 Argument = g.Key,
            //                 price = g.Sum(u=>u.Price),
            //                 Value = string.Join(",", g.Select(u => u.Value))
            //             }).ToList();

        }


        private void FillWidgetsNet()
        {
            Potansialworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Beklenentutar).Sum() - Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Beklenentutar).Sum();
            Networth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum() - Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
            Realworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
            Minusworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
            Totalgivenfileordercount = (from s in Recorddatacostumer
                                        join c in Recorddatajoborder on s.Id equals c.Üstid
                                        select c.Joborder).Count();
            Totalprocesscount = Recorddatacostumer.Count();
            TimeSpan t = Enddate - Startdate;           
            Networthgauge = (Math.Round(100 * Realworth / hedefler.MonthlyAnalysisKAZANÇ, 0)/ t.TotalDays / 30).ToString();
            Minusworthgauge = (Math.Round(100 * minusworth/ hedefler.MonthlyAnalysisKAZANÇ, 0) / t.TotalDays / 30).ToString();
        }

        private void FillWidgetsSales()
        {
            Potansialworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Beklenentutar).Sum();
            Networth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
            Realworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
            Minusworth = 0;
            Totalgivenfileordercount = (from s in Recorddatacostumer
                                        join c in Recorddatajoborder on s.Id equals c.Üstid
                                        select c.Joborder).Count();
            Totalprocesscount = Recorddatacostumer.Count();
            TimeSpan t = Enddate - Startdate;
            Networthgauge = (Math.Round(100 * Realworth / hedefler.MonthlyAnalysisKAZANÇ, 0) / t.TotalDays / 30).ToString();
            Minusworthgauge = (Math.Round(100 * minusworth / hedefler.MonthlyAnalysisKAZANÇ, 0) / t.TotalDays / 30).ToString();
        }

        private void FillWidgetsPurchase()
        {
            Potansialworth =  Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Beklenentutar).Sum();
            Networth =  Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
            Realworth = 0;
            Minusworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
            Totalgivenfileordercount = (from s in Recorddatacostumer
                                        join c in Recorddatajoborder on s.Id equals c.Üstid
                                        select c.Joborder).Count();
            Totalprocesscount = Recorddatacostumer.Count();
            TimeSpan t = Enddate - Startdate;
            Networthgauge = (Math.Round(100 * Realworth / hedefler.MonthlyAnalysisKAZANÇ, 0) / t.TotalDays / 30).ToString();
            Minusworthgauge = (Math.Round(100 * minusworth / hedefler.MonthlyAnalysisKAZANÇ, 0) / t.TotalDays / 30).ToString();
        }
        #endregion

        #region Report Methods

        public void DoReport(string tag)
        {
            
        }

        #endregion

        #endregion


    }
}
