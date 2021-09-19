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
    public class TypeAddVM : BaseModel
    {

        TypeAddDA typeAddDA;
        public TypeAddVM()
        {
            typeAddDA = new TypeAddDA();           
            currentdata = new SalesmanAddModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
        private List<SalesmanAddModel> salesmanlist;
        public List<SalesmanAddModel> Salesmanlist
        {
            get { return salesmanlist; }
            set { salesmanlist = value; RaisePropertyChanged("Salesmanlist"); }
        }
               
        private SalesmanAddModel currentdata;
        public SalesmanAddModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }
        #endregion

        #region Method
        public void Loaddata()
        {
            try
            {
                Salesmanlist = new List<SalesmanAddModel>(typeAddDA.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür Tablo Doldurma Hatası", ex.Message);
            }
        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                isok = typeAddDA.Add(currentdata);
                Loaddata();
                RefreshViews.türsource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür Kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = typeAddDA.Update(currentdata);                
                Loaddata();
                RefreshViews.türsource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür Güncelleme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = typeAddDA.Delete(currentdata);               
                Loaddata();
                RefreshViews.türsource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür Silme Hatası", ex.Message);
            }
            return isok;
        }
        #endregion
    }
}
