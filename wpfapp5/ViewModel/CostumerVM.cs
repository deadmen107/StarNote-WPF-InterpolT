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
    public class CostumerVM : BaseModel
    {
        CostumerDA dataaccess;
        public CostumerVM()
        {
            dataaccess = new CostumerDA();           
            currentdata = new CostumerModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
        private List<CostumerModel> costumerlist;
        public List<CostumerModel> Costumerlist
        {
            get { return costumerlist; }
            set { costumerlist = value; RaisePropertyChanged("Costumerlist"); }
        }
      
        private CostumerModel currentdata;
        public CostumerModel Currentdata
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
                RefreshViews.Loadcustomer = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Kaydetme Hatası", ex.Message);
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
                RefreshViews.Loadcustomer = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Güncelleme Hatası", ex.Message);
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
                RefreshViews.Loadcustomer = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Silme Hatası", ex.Message);
            }
            return isok;
        }
        public void Loaddata()
        {
            try
            {
                Costumerlist = new List<CostumerModel>(dataaccess.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Tablo Doldurma Hatası", ex.Message);
            }
        }
        #endregion
    }
}
