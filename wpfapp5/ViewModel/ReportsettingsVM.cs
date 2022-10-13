using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarNote.ViewModel
{
    public class ReportsettingsVM : BaseModel
    {
        private const string Controller = "ReportSettings";
        private const string GetAlluri = "GetAll";
        private const string Adduri = "Add";
        private const string Updateuri = "Update";
        private const string Deleteuri = "Delete";
        BaseDa Dataaccess;


        public ReportsettingsVM()
        {
            Dataaccess = new BaseDa();
            if (RefreshViews.appstatus)
            {
                Loaddata();
            }

            Reportlist = new List<ReportsettingComboboxModel>
            {
                new ReportsettingComboboxModel{Key = 0 , Name = "AnalysisReport"},
                new ReportsettingComboboxModel{Key = 1 , Name = "ParsedAnalysisReport"},
            };

            Reporttypelist = new List<ReportsettingComboboxModel>
            {
                new ReportsettingComboboxModel{Key=0,Name="DailyReport"},
                new ReportsettingComboboxModel{Key=1,Name="DailyWithoutWeekend"},
                new ReportsettingComboboxModel{Key=2,Name="Daily1by1WithoutWeekend"},
                new ReportsettingComboboxModel{Key=3,Name="WeekStartEndWithoutWeekend"},
                new ReportsettingComboboxModel{Key=4,Name="WeekStart"},
                new ReportsettingComboboxModel{Key=5,Name="WeekEnd"},
            };
        }

        #region defines
        private ReportsettingModel currentdata;
        public ReportsettingModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        private List<ReportsettingModel> list;
        public List<ReportsettingModel> List
        {
            get { return list; }
            set { list = value; RaisePropertyChanged("List"); }
        }

        private List<ReportsettingComboboxModel> reporttypelist;

        public List<ReportsettingComboboxModel> Reporttypelist
        {
            get { return reporttypelist; }
            set { reporttypelist = value; RaisePropertyChanged("Reporttypelist"); }
        }


        private List<ReportsettingComboboxModel> reportlist;
        public List<ReportsettingComboboxModel> Reportlist
        {
            get { return reportlist; }
            set { reportlist = value; RaisePropertyChanged("Reportlist"); }
        }

        #endregion

        #region method
        public void Loaddata()
        {
            try
            {
                
                List = Dataaccess.DoGet(List, Controller, GetAlluri);
                foreach (var item in List)
                {
                    item.Reportname = reportlist.FirstOrDefault(u => u.Key == item.Reportid).Name;
                    item.Reporttypename = reporttypelist.FirstOrDefault(u => u.Key == item.Reporttype).Name;
                }
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor Ayarları Tablo dolduruldu", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor Ayarları Tablo doldurma Hatası", ex.Message);
            }

        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                isok = Dataaccess.DoPost(Currentdata, Controller, Adduri);
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor Ayarları Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor Ayarları Kaydetme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = Dataaccess.DoPost(Currentdata, Controller, Updateuri);
                Loaddata();
                RefreshViews.Loadcompany = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor Ayarları Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor Ayarları Güncelleme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = Dataaccess.DoPost(Currentdata, Controller, Deleteuri);
                Loaddata();
                RefreshViews.Loadcompany = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor Ayarları Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor Ayarları Silme Hatası", ex.Message);
            }
            return isok;
        }
        #endregion

    }
}

