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
    public class TypeDetailVM : BaseModel
    {
        TypeDetailDA typeDetailDA;
        public TypeDetailVM()
        {
            typeDetailDA = new TypeDetailDA();
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
        public void Loaddata()
        {
            try
            {
                Salesmanlist = new List<ParameterModel>(typeDetailDA.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür detay Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür detay Tablo Doldurma Hatası", ex.Message);
            }
        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                isok = typeDetailDA.Add(currentdata);
                Loaddata();
                RefreshViews.türdetaysource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür detay Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür detay Kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                isok = typeDetailDA.Update(currentdata);
                Loaddata();
                RefreshViews.türdetaysource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür detay Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür detay Güncelleme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Delete()
        {
            bool isok = false;
            try
            {
                isok = typeDetailDA.Delete(currentdata);
                Loaddata();
                RefreshViews.türdetaysource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür detay Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür detay Silme Hatası", ex.Message);
            }
            return isok;
        }
        #endregion
    }
}
