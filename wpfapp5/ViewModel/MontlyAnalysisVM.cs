using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.DataAccess;
using StarNote.Model;
namespace StarNote.ViewModel
{
    public class MontlyAnalysisVM : BaseModel
    {
        BaseDa dataaccess;
        public MontlyAnalysisVM()
        {
            dataaccess = new BaseDa();
        }


        #region Defines

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

        private DateTime endtime;
        public DateTime Endtime
        {
            get { return endtime; }
            set { endtime = value; RaisePropertyChanged("Endtime"); }
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

        #endregion

        #region Report Methods

        #endregion

        #endregion


    }
}
