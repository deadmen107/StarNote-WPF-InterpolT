using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StarNote.Command;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;

namespace StarNote.ViewModel
{
    public class SalesmanAddVM : BaseModel
    {

        SalesmanAddDA salesmanAddDA;

        public SalesmanAddVM()
        {
            salesmanAddDA = new SalesmanAddDA();           
            currentdata = new ParameterModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }
        
        #region Defines
        private List<ParameterModel> salesmanlist;
        public List<ParameterModel> Salesmanlist
        {
            get { return salesmanlist; }
            set { salesmanlist = value; RaisePropertyChanged("Salesmanlist"); }
        }
        
        private ParameterModel currentdata;
        public ParameterModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        #endregion

        #region Method
        public bool Save()
        {
            bool isok = false;
            try
            {
                isok = salesmanAddDA.Add(currentdata);
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Kaydetme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = salesmanAddDA.Update(currentdata);               
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Güncelleme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = salesmanAddDA.Delete(currentdata);                
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Silme Hatası", ex.Message);
            }
            return isok;
        }
        public void Loaddata()
        {
            try
            {
                Salesmanlist = new List<ParameterModel>(salesmanAddDA.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Satış Görevli Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Satış Görevli Tablo Doldurma Hatası", ex.Message);
            }
        }
        #endregion


    }
}
