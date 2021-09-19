using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StarNote.Model;
using StarNote.Command;
using StarNote.DataAccess;
using DevExpress.Xpf.WindowsUI;
using System.Windows;
using StarNote.Service;

namespace StarNote.ViewModel
{
    public class StokVM : BaseModel
    {
        StokDA stokdataaccess;
        public StokVM()
        {
            stokdataaccess = new StokDA();
            currentdata = new StokModel();           
            loaddata();
            Loadsources();
         
        }

        #region Defines
        private List<StokModel> stoklist;
        public List<StokModel> Stoklist
        {
            get { return stoklist; }
            set { stoklist = value; RaisePropertyChanged("Stoklist"); }
        }

        private StokModel currentdata;
        public StokModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }

        private RelayCommand savecommand;
        public RelayCommand Savecommand
        {
            get { return savecommand; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; RaisePropertyChanged("Message"); }
        }

        private RelayCommand updatecommand;
        public RelayCommand Updatecommand
        {
            get { return updatecommand; }
            set { updatecommand = value; }
        }
        private List<string> birimsourcelist;
        public List<string> Birimsourcelist
        {
            get { return birimsourcelist; }
            set { birimsourcelist = value; RaisePropertyChanged("Birimsourcelist"); }
        }

        private List<string> kdvsourcelist;
        public List<string> Kdvsourcelist
        {
            get { return kdvsourcelist; }
            set { kdvsourcelist = value; RaisePropertyChanged("Kdvsourcelist"); }
        }
        #endregion

        #region Method
        public void loaddata()
        {
            try
            {
                Stoklist = new List<StokModel>(stokdataaccess.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Stok Tablo Doldurma Hatası", ex.Message);
            }
        }
             
        public bool Save()
        {
            bool isok = false;
            try
            {
                currentdata.Birim = "SAYFA";
                isok = stokdataaccess.Add(currentdata);              
                loaddata();
                RefreshViews.Ürünsource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Stok Kaydetme Hatası", ex.Message);
            }
            return isok;
        }
     
        public bool Update()
        {
            bool isok = false;
            try
            {
                Currentdata.Birim = "SAYFA";
                isok = stokdataaccess.Update(currentdata);            
                loaddata();
                RefreshViews.Ürünsource = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Stok Güncelleme Hatası", ex.Message);
            }
            return isok;
        }
        
        public void Loadsources()
        {
            try
            {
                var tuplearray = stokdataaccess.Sourcelistfill();
                Birimsourcelist = new List<string>(tuplearray.Item1);
                Kdvsourcelist = new List<string>(tuplearray.Item2);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok Combobox Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Stok Combobox Doldurma Hatası", ex.Message);
            }
        }

        #endregion

    }
}
