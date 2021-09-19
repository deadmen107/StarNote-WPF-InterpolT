using StarNote.Command;
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
    
    public class CompanyVM : BaseModel
    {
        CompanyDA dataaccess;
        public CompanyVM()
        {
            dataaccess = new CompanyDA();       
            currentdata = new CompanyModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
        private List<CompanyModel> companylist;
        public List<CompanyModel> Companylist
        {
            get { return companylist; }
            set { companylist = value; RaisePropertyChanged("Companylist"); }
        }
        
        private CompanyModel currentdata;
        public CompanyModel Currentdata
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
                isok = dataaccess.Add(currentdata);
                Loaddata();
                RefreshViews.Loadcompany = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Kaydetme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = dataaccess.Update(currentdata);              
                Loaddata();
                RefreshViews.Loadcompany = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Güncelleme Hatası", ex.Message);
            }
            return isok;
        }
        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = dataaccess.Delete(currentdata);               
                Loaddata();
                RefreshViews.Loadcompany = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Silme Hatası", ex.Message);
            }
            return isok;
        }
        public void Loaddata()
        {
            try
            {
                Companylist = new List<CompanyModel>(dataaccess.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Tablo Doldurma Hatası", ex.Message);
            }
        }
        #endregion


    }
}
