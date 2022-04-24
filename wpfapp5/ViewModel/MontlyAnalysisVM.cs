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
using System.Windows.Controls;
using StarNote.View;
using DevExpress.XtraPrinting;
using System.Windows;
using System.Drawing;

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
            Networkthbtnvisibility = Visibility.Visible;
            Salesbtnvisibility = Visibility.Visible;
            Purchasebtnvisibility = Visibility.Visible;
            Isbtnenable = true;
            Subtabindexchangedcommand = new RelayparameterCommand(BottomSelectionChanged, CanExecuteMyMethod);
            Tabindexchangedcommand = new RelayparameterCommand(TopSelectionChanged,CanExecuteMyMethod);
            Doreportcommand = new RelayparameterCommand(DoReport, CanExecuteMyMethod);
            Selectionchangedtabindex = new RelayCommand(datechanged);
            Languagechange = new RelayCommand(filllanguagechart);
            Documentchange = new RelayCommand(fillDocumentchart);
            Startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1);
            Enddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1);
            Titleindex = 0;
            Subtitleindex = 0;
            Setbtncolors();
            Changetitle();
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

        private RelayparameterCommand subtabindexchangedcommand;
        public RelayparameterCommand Subtabindexchangedcommand
        {
            get { return subtabindexchangedcommand; }
            set { subtabindexchangedcommand = value; RaisePropertyChanged("Subtabindexchangedcommand"); }
        }

        private RelayparameterCommand tabindexchangedcommand;
        public RelayparameterCommand Tabindexchangedcommand
        {
            get { return tabindexchangedcommand; }
            set { tabindexchangedcommand = value; RaisePropertyChanged("Tabindexchangedcommand"); }
        }

        private RelayparameterCommand doreportcommand;
        public RelayparameterCommand Doreportcommand
        {
            get { return doreportcommand; }
            set { doreportcommand = value; RaisePropertyChanged("Doreportcommand"); }
        }

        private RelayCommand languagechange;
        public RelayCommand Languagechange
        {
            get { return languagechange; }
            set { languagechange = value; RaisePropertyChanged("Languagechange"); }
        }

        private RelayCommand documentchange;
        public RelayCommand Documentchange
        {
            get { return documentchange; }
            set { documentchange = value; RaisePropertyChanged("Documentchange"); }
        }

        private bool CanExecuteMyMethod(object parameter)
        {
            return true;
        }

        #endregion

        #region Colors

        private Brush btnbrushgenel;
        public Brush Btnbrushgenel
        {
            get { return btnbrushgenel; }
            set { btnbrushgenel = value; RaisePropertyChanged("Btnbrushgenel"); }
        }

        private Brush btnbrushadliye;
        public Brush Btnbrushadliye
        {
            get { return btnbrushadliye; }
            set { btnbrushadliye = value; RaisePropertyChanged("Btnbrushadliye"); }
        }

        private Brush btnbrushözel;
        public Brush Btnbrushözel
        {
            get { return btnbrushözel; }
            set { btnbrushözel = value; RaisePropertyChanged("Btnbrushözel"); }
        }

        private Brush btnbrushfirma;
        public Brush Btnbrushfirma
        {
            get { return btnbrushfirma; }
            set { btnbrushfirma = value; RaisePropertyChanged("Btnbrushfirma"); }
        }

        private Brush btnbrushdiger;
        public Brush Btnbrushdiger
        {
            get { return btnbrushdiger; }
            set { btnbrushdiger = value; RaisePropertyChanged("Btnbrushdiger"); }
        }

        private Brush btnbrushNet;
        public Brush BtnbrushNet
        {
            get { return btnbrushNet; }
            set { btnbrushNet = value; RaisePropertyChanged("BtnbrushNet"); }
        }

        private Brush btnbrushGelir;
        public Brush BtnbrushGelir
        {
            get { return btnbrushGelir; }
            set { btnbrushGelir = value; RaisePropertyChanged("BtnbrushGelir"); }
        }

        private Brush btnBrushGider;
        public Brush BtnbrushGider
        {
            get { return btnBrushGider; }
            set { btnBrushGider = value; RaisePropertyChanged("BtnbrushGider"); }
        }

        #endregion

        #region UI Defines        

        private string languagename;
        public string Languagename
        {
            get { return languagename; }
            set { languagename = value; RaisePropertyChanged("Languagenames"); }
        }

        private string documentname;
        public string Documentname
        {
            get { return documentname; }
            set { documentname = value; RaisePropertyChanged("Languagenames"); }
        }


        private List<string> languagenames;
        public List<string> Languagenames
        {
            get { return languagenames; }
            set { languagenames = value; RaisePropertyChanged("Languagenames"); }
        }

        private List<string> documentnames;
        public List<string> Documentnames
        {
            get { return documentnames; }
            set { documentnames = value; RaisePropertyChanged("Documentnames"); }
        }

        private List<DataPoint> languagechart;
        public List<DataPoint> Languagechart
        {
            get { return languagechart; }
            set { languagechart = value; RaisePropertyChanged("Languagechart"); }
        }


        private List<DataPoint> documentchart;
        public List<DataPoint> Documentchart
        {
            get { return documentchart; }
            set { documentchart = value; RaisePropertyChanged("Documentchart"); }
        }



        private List<Analysissubgridmodel> languagedata;
        public List<Analysissubgridmodel> Languagedata
        {
            get { return languagedata; }
            set { languagedata = value; RaisePropertyChanged("Languagedata"); }
        }

        private List<Analysissubgridmodel> documentdata;
        public List<Analysissubgridmodel> Documentdata
        {
            get { return documentdata; }
            set { documentdata = value; RaisePropertyChanged("Documentdata"); }
        }


        private string titlename;
        public string Titlename
        {
            get { return titlename; }
            set { titlename = value; RaisePropertyChanged("Titlename"); }
        }


        private Visibility networkthbtnvisibility;
        public Visibility Networkthbtnvisibility
        {
            get { return networkthbtnvisibility; }
            set { networkthbtnvisibility = value; RaisePropertyChanged("Networkthbtnvisibility"); }
        }

        private Visibility salesbtnvisibility;
        public Visibility Salesbtnvisibility
        {
            get { return salesbtnvisibility; }
            set { salesbtnvisibility = value; RaisePropertyChanged("Salesbtnvisibility"); }
        }

        private Visibility purchasebtnvisibility;
        public Visibility Purchasebtnvisibility
        {
            get { return purchasebtnvisibility; }
            set { purchasebtnvisibility = value; RaisePropertyChanged("Purchasebtnvisibility"); }
        }

        private bool isbtnenable;
        public bool Isbtnenable
        {
            get { return isbtnenable; }
            set { isbtnenable = value; RaisePropertyChanged("Isbtnenable"); }
        }

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

        private List<AnalysisreportModel> reportdata;
        public List<AnalysisreportModel> Reportdata
        {
            get { return reportdata; }
            set { reportdata = value; RaisePropertyChanged("Reportdata"); }
        }

        #endregion

        #endregion

        #region Methods

        #region UI Methods

        private void datechanged()
        {
            Loaddata();
        }

        private void Setbtncolors()
        {
            List<Brush> Topbtns = new List<Brush>
            {
               Btnbrushgenel, Btnbrushadliye, Btnbrushözel, Btnbrushfirma, Btnbrushdiger
            };
            List<Brush> Bottombtns = new List<Brush>
            {
               BtnbrushNet, BtnbrushGelir, BtnbrushGider
            };

            for (int i = 0; i < Topbtns.Count; i++)
                Topbtns[i] = Brushes.DarkCyan;
            for (int i = 0; i < Bottombtns.Count; i++)
                Bottombtns[i] = Brushes.DarkCyan;

            Topbtns[Titleindex] = Brushes.Bisque;
            Bottombtns[Subtitleindex] = Brushes.Bisque;

        }

        private void Changebtnvisibility()
        {
            Networkthbtnvisibility = Visibility.Visible;
            Salesbtnvisibility = Visibility.Visible;
            Purchasebtnvisibility = Visibility.Visible;
            if (Titleindex == 1 || Titleindex == 2 || Titleindex == 3)
                Purchasebtnvisibility = Visibility.Hidden;
        }

        private void Changetitle()
        {
            string[] titlenames = { "Genel Analiz", "Adliye Analiz", "Özel Analiz", "Firma Analiz", "Diğer Analiz" };
            string[] subtitlenames = {"Net İşlemler Raporu", "Gelir İşlemler Raporu", "Gider İşlemler Raporu"};
            Titlename = titlenames[Titleindex] + " " + subtitlenames[Subtitleindex];
        }

        public void TopSelectionChanged(object sender)
        {
            var newindex = Convert.ToInt16(sender);
            if (newindex == Titleindex)
                return;
            Titleindex = newindex;
            Setbtncolors();
            Changetitle();
            Loaddata();
        }

        public void BottomSelectionChanged(object sender)
        {
            var newindex = Convert.ToInt16(sender);
            if (newindex == Subtitleindex)
                return;
            Subtitleindex = newindex;
            Setbtncolors();
            Changetitle();
            Loaddata();
        }

        public async Task Loaddata()
        {
            if (GlobalStore.MaindataCostumer == null || GlobalStore.MaindataCostumer.Count == 0)
                return;
            if (GlobalStore.MaindataJoborder == null || GlobalStore.MaindataJoborder.Count == 0)
                return;
            isbtnenable = false;
            await Task.Run(async () =>
            {
                ManageBigData(Titleindex, Startdate, Enddate);
                ManagePartialData(subtitleindex);
                isbtnenable = true;
            });
        }

        private bool IsBetween(DateTime value, DateTime min, DateTime max)
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
        }

        private void ManageBigData(int titleindex,DateTime startdate, DateTime enddate)
        {           
            Recorddatacostumer = new List<CostumerOrderModel>();
            Recorddatajoborder = new List<JobOrderModel>();
            
            foreach (var item in GlobalStore.Maindataorder)
            {
                if (IsBetween(Convert.ToDateTime(item.Costumerorder.Kayıttarihi).Date,startdate.Date,enddate.Date))
                {
                    if (item.Costumerorder.Satışyöntemi == "GIDER")
                    {
                        if(item.Costumerorder.Ücret>0)
                        item.Costumerorder.Ücret = item.Costumerorder.Ücret * -1;
                        if (item.Costumerorder.Beklenentutar > 0)
                            item.Costumerorder.Beklenentutar = item.Costumerorder.Beklenentutar * -1;
                    }
                    Recorddatacostumer.Add(item.Costumerorder);
                    Recorddatajoborder.AddRange(item.Joborder);
                }
            }
            switch (titleindex)
            {
                case 0:  //Genel
                   
                    break;
                case 1: //Adliye                    
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür != "ÖZEL MÜŞTERİLER" && u.Tür != "ŞİRKETLER" && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 2: //Özel               
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür == "ÖZEL MÜŞTERİLER"  && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 3: //Firma                    
                    Recorddatacostumer = Recorddatacostumer.Where(u => u.Tür == "ŞİRKETLER" && u.Savetype == 0).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
                case 4:  //Özel İşlemler                  
                    Recorddatacostumer = Recorddatacostumer.Where(u =>  u.Savetype == 1).ToList();
                    Recorddatajoborder = Recorddatajoborder;
                    break;
            }
        }

        private void ManagePartialData(int subtitleindex)
        {
            Fillwidget();
            fillcharttable();
            Filllanguagedata();
            filllanguagechart();
            Filldocumentdata();
            fillDocumentchart();
        }

        private void fillcharttable()
        {
            Datachart = (from s in Calcdataforreport()
                         group s by Convert.ToDateTime(s.Kayıttarihi).Date into g
                         select new DataPoint
                         {
                             Argument = g.Key.ToShortDateString(),
                             Value = g.Sum(x => x.Ücret)
                         }).ToList();
        }

        private void Fillwidget()
        {
            TimeSpan t = Enddate - Startdate;          
            switch (Subtitleindex)
            {
                case 0:
                    Potansialworth = Recorddatacostumer.Select(u => u.Beklenentutar).Sum();
                    Networth = Recorddatacostumer.Select(u => u.Ücret).Sum();
                    Realworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
                    Minusworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
                    Totalgivenfileordercount = (from s in Recorddatacostumer
                                                join c in Recorddatajoborder on s.Id equals c.Üstid
                                                select c.Joborder).Count();
                    Totalprocesscount = Recorddatacostumer.Count();
                    Networthgauge = (Math.Round(100 * Realworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)),0)).ToString();
                    Minusworthgauge = (Math.Round(100 * minusworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)), 0)).ToString();
                    break;
                case 1:
                    Potansialworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Beklenentutar).Sum();
                    Networth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
                    Realworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Select(u => u.Ücret).Sum();
                    Minusworth = 0;
                    Totalgivenfileordercount = (from s in Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR")
                                                join c in Recorddatajoborder on s.Id equals c.Üstid
                                                select c.Joborder).Count();
                    Totalprocesscount = Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").Count();
                    Networthgauge = (Math.Round(100 * Realworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)), 0)).ToString();
                    Minusworthgauge = (Math.Round(100 * minusworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)), 0)).ToString();
                    break;
                case 2:
                    Potansialworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Beklenentutar).Sum();
                    Networth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
                    Realworth = 0;
                    Minusworth = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Select(u => u.Ücret).Sum();
                    Totalgivenfileordercount = (from s in Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER")
                                                join c in Recorddatajoborder on s.Id equals c.Üstid
                                                select c.Joborder).Count();
                    Totalprocesscount = Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").Count();
                    Networthgauge = (Math.Round(100 * Realworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)), 0)).ToString();
                    Minusworthgauge = (Math.Round(100 * minusworth / (hedefler.MonthlyAnalysisKAZANÇ * (t.TotalDays / 30)), 0)).ToString();
                    break;               
            }
           
        }

        private void Filllanguagedata()
        {
            Languagedata = new List<Analysissubgridmodel>();
            Languagenames = new List<string>();
            foreach (var order in Calcdataforreport())
                foreach (var item in Recorddatajoborder.Where(u => u.Üstid == order.Id).ToList())
                {
                    var duplicatedata = Languagedata.FirstOrDefault(u => u.Name == item.Ürün + "->" + item.Ürün2);
                    if (duplicatedata == null)
                        Languagedata.Add(new Analysissubgridmodel { Name = item.Ürün + "->" + item.Ürün2, Count = 1, Potansialworth = item.Ücret });
                    else
                    {
                        duplicatedata.Count += 1;
                        duplicatedata.Potansialworth += item.Ücret;
                    }
                    Languagenames.Add(item.Ürün + "->" + item.Ürün2);
                }
            Languagedata = Languagedata.OrderByDescending(u => u.Count).ToList();
            Languagenames = Languagenames.Distinct().OrderBy(u=>u).ToList();
        
        }

        private void Filldocumentdata()
        {
            Documentdata = new List<Analysissubgridmodel>();
            Documentnames = new List<string>();
            foreach (var order in Calcdataforreport())
                foreach (var item in Recorddatajoborder.Where(u => u.Üstid == order.Id).ToList())
                {
                    var duplicatedata = Documentdata.FirstOrDefault(u => u.Name == item.Ürün2detay);
                    if (duplicatedata == null)
                        Documentdata.Add(new Analysissubgridmodel { Name = item.Ürün2detay, Count = 1, Potansialworth = item.Ücret });
                    else
                    {
                        duplicatedata.Count += 1;
                        duplicatedata.Potansialworth += item.Ücret;
                    }
                    Documentnames.Add(item.Ürün2detay);
                }
            Documentdata = Documentdata.OrderByDescending(u => u.Count).ToList();
            Documentnames = Documentnames.Distinct().OrderBy(u => u).ToList();

        }

        private void fillDocumentchart()
        {
            try
            {
                List<DataPoint> MainData = new List<DataPoint>();
                if (string.IsNullOrWhiteSpace(Documentname))
                    return;
                foreach (var order in Calcdataforreport())
                {
                    List<DataPoint> data = new List<DataPoint>();
                    foreach (var item in Recorddatajoborder.Where(u => u.Ürün2detay == Documentname && u.Üstid == order.Id).ToList())
                    {
                        data.Add(new DataPoint { Argument = Convert.ToDateTime(order.Kayıttarihi).Date.ToShortDateString(), Value = item.Ücret });
                    }
                    if (data.Count != 0)
                        MainData.Add(new DataPoint { Argument = data.First().Argument, Value = data.Sum(u => u.Value) });
                }
                Documentchart = MainData.GroupBy(x => x.Argument)
                                .Select(x => new DataPoint
                                {
                                    Argument = x.Key,
                                    Value = x.Sum(y => y.Value)
                                })
                                .ToList();
            }
            catch (Exception ex)
            {

                LogVM.displaypopup("ERROR", ex.Message);
            }
        }

        private void filllanguagechart()
        {
            try
            {
                string[] parsedstr = { };
                string[] separatingStrings = { "->" };
                List<DataPoint> MainData = new List<DataPoint>();
                if (string.IsNullOrWhiteSpace(languagename))
                    return;                
                parsedstr = Languagename.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (var order in Calcdataforreport())
                {
                    List<DataPoint> data = new List<DataPoint>();
                    foreach (var item in Recorddatajoborder.Where(u => u.Ürün2.ToString() == parsedstr[1] && u.Ürün.ToString() == parsedstr[0] && u.Üstid == order.Id).ToList())
                    {
                        data.Add(new DataPoint { Argument = Convert.ToDateTime(order.Kayıttarihi).Date.ToShortDateString(), Value = item.Ücret });
                    }
                    if (data.Count != 0)
                        MainData.Add(new DataPoint { Argument = data.First().Argument, Value = data.Sum(u => u.Value) });
                }
                Languagechart = MainData.GroupBy(x => x.Argument)
                                .Select(x => new DataPoint
                                {
                                    Argument = x.Key,
                                    Value = x.Sum(y => y.Value)
                                })
                                .ToList();
            }
            catch (Exception ex)
            {

                LogVM.displaypopup("ERROR", ex.Message);
            }
        }
        #endregion

        #region Report Methods

        private List<CostumerOrderModel> Calcdataforreport()
        {
            switch (Subtitleindex)
            {
                case 0:
                    return Recorddatacostumer;                   
                case 1:
                    return  Recorddatacostumer.Where(u => u.Satışyöntemi == "GELIR").ToList();                   
                case 2:
                    return Recorddatacostumer.Where(u => u.Satışyöntemi == "GIDER").ToList();                    
            }
            return new List<CostumerOrderModel>();
        }

        public void DoReport(object sender)
        {
            MessageBoxResult result = MessageBox.Show("Rapor Oluşturmak İstediğinize emin misiniz?", "Rapor Oluşturma", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                return;
            Reportdata = new List<AnalysisreportModel>();
            switch (sender.ToString())
            {
                case "0":  //potansiyel kazanç
                    foreach (var item in Calcdataforreport())
                    {
                        Reportdata.Add(new AnalysisreportModel
                        {
                            Id = item.Id,
                            Customername = item.İsim,
                            Processtype = item.Tür,
                            Price=item.Beklenentutar,
                            Dateregister = item.Kayıttarihi,
                            Status=item.Durum
                        });
                    }
                    Reportdata.Add(new AnalysisreportModel {Status="TOPLAM=",Price = Reportdata.Select(u=>u.Price).Sum() });
                    break;
                case "1":  //gerçek kazanc
                    foreach (var item in Calcdataforreport().Where(u => u.Satışyöntemi == "GELIR"))
                    {
                        Reportdata.Add(new AnalysisreportModel
                        {
                            Id = item.Id,
                            Customername = item.İsim,
                            Processtype = item.Tür,
                            Price = item.Ücret,
                            Dateregister = item.Kayıttarihi,
                            Status = item.Durum
                        });
                    }
                    Reportdata.Add(new AnalysisreportModel { Status = "TOPLAM=", Price = Reportdata.Select(u => u.Price).Sum() });
                    break;
                case "2":   // total process count
                    int i = 1;
                    foreach (var item in Calcdataforreport())
                    {
                        Reportdata.Add(new AnalysisreportModel
                        {
                            Id = item.Id,
                            Customername = item.İsim,
                            Processtype = item.Tür,
                            Price = i,
                            Dateregister = item.Kayıttarihi,
                            Status = item.Durum
                        });
                        i++;
                    }                  
                    break;
                case "3":  //net kazanç
                    foreach (var item in Calcdataforreport())
                    {
                        Reportdata.Add(new AnalysisreportModel
                        {
                            Id = item.Id,
                            Customername = item.İsim,
                            Processtype = item.Tür,
                            Price = item.Ücret,
                            Dateregister = item.Kayıttarihi,
                            Status = item.Durum
                        });
                    }
                    Reportdata.Add(new AnalysisreportModel { Status = "TOPLAM=", Price = Reportdata.Select(u => u.Price).Sum() });
                    break;
                case "4":  // harcama
                    foreach (var item in Calcdataforreport().Where(u => u.Satışyöntemi == "GIDER"))
                    {
                        Reportdata.Add(new AnalysisreportModel
                        {
                            Id = item.Id,
                            Customername = item.İsim,
                            Processtype = item.Tür,
                            Price = item.Ücret,
                            Dateregister = item.Kayıttarihi,
                            Status = item.Durum
                        });
                    }
                    Reportdata.Add(new AnalysisreportModel { Status = "TOPLAM=", Price = Reportdata.Select(u => u.Price).Sum() });
                    break;
                case "5":  //dosya numaları
                    int j = 1;
                    foreach (var item in Calcdataforreport())
                    {
                        foreach (var joborder in Recorddatajoborder.Where(u => u.Üstid == item.Id))
                        {
                            Reportdata.Add(new AnalysisreportModel
                            {
                                Id = joborder.Id,
                                Customername = item.İsim,
                                Processtype = item.Tür,
                                Price =j,
                                Dateregister = item.Kayıttarihi,
                                Status = joborder.Joborder
                            });
                            j++;
                        }
                    }
                    break;               
            }

            switch (sender.ToString())
            {
                case "2":
                    AnalysisReport2 reportAnalysis2 = new AnalysisReport2();
                    reportAnalysis2.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                    reportAnalysis2.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                    reportAnalysis2.DataSource = Reportdata;
                    reportAnalysis2.ExportToPdf("müşteriler.pdf");
                    reportAnalysis2.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                    ReportUC report2 = new ReportUC(reportAnalysis2, new OrderModel(), "Repor2");
                    report2.Show();
                    break;
                case "5":
                    AnalysisReport3 reportAnalysis3 = new AnalysisReport3();
                    reportAnalysis3.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                    reportAnalysis3.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                    reportAnalysis3.DataSource = Reportdata;
                    reportAnalysis3.ExportToPdf("tercümeler.pdf");
                    reportAnalysis3.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                    ReportUC report3 = new ReportUC(reportAnalysis3, new OrderModel(), "Repor3");
                    report3.Show();
                    break;
                default:
                    AnalysisReport reportAnalysis = new AnalysisReport();
                    reportAnalysis.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath;
                    reportAnalysis.ExportOptions.PrintPreview.ShowOptionsBeforeExport = false;
                    reportAnalysis.DataSource = Reportdata;
                    reportAnalysis.ExportToPdf("analiz.pdf");
                    reportAnalysis.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None;
                    ReportUC report = new ReportUC(reportAnalysis, new OrderModel(), "Repor1");
                    report.Show();
                    break;
            }
          
            //System.Windows.Forms.MessageBox.Show(sender.ToString());

        }

        #endregion

        #endregion


    }
}
