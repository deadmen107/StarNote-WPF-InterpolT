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
    public class ProductVM : BaseModel
    {
        ProductDA productDA;
        public ProductVM()
        {
            productDA = new ProductDA();           
            currentdata = new ParameterModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
        private List<ParameterModel> productlist;
        public List<ParameterModel> Productlist
        {
            get { return productlist; }
            set { productlist = value; RaisePropertyChanged("Productlist"); }
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
                Productlist = new List<ParameterModel>(productDA.GetAll().OrderBy(x=>x.Parameter).ToList());
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
                isok = productDA.Add(currentdata);
                Loaddata();
                RefreshViews.ürün2source = true;
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
                isok = productDA.Update(currentdata);                
                Loaddata();
                RefreshViews.ürün2source = true;
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
                isok = productDA.Delete(currentdata);                
                Loaddata();
                RefreshViews.ürün2source = true;
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
