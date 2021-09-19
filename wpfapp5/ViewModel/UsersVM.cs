using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Model;
using StarNote.DataAccess;
using StarNote.Command;
using DevExpress.Xpf.WindowsUI;
using System.Windows;
using DevExpress.Xpf.Core;
using StarNote.View;

namespace StarNote.ViewModel 
{
    public class UsersVM : BaseModel
    {
        UsersDA usersDA;       
        public UsersVM()
        {
            usersDA = new UsersDA();          
            currentdata = new UsersModel();         
            Loaddata();         
        }
        #region Defines
        private List<UsersModel> userlist;
        public List<UsersModel> Userlist
        {
            get { return userlist; }
            set { userlist = value; RaisePropertyChanged("Userlist"); }
        }     
      
        private string passwordre;
        public string Passwordre
        {
            get { return passwordre; }
            set { passwordre = value; RaisePropertyChanged("Passwordre"); }
        }

        private UsersModel currentdata;
        public UsersModel Currentdata
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
                Userlist = new List<UsersModel>(usersDA.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Tablo Doldurma Hatası", ex.Message);
            }
        }
        
        public bool Save()
        {
            bool isok = false;
            try
            {
                currentdata.Kayıttarihi = System.DateTime.Now.ToString();
                if (passwordre.ToString() == currentdata.Şifre.ToString())
                {
                    isok = usersDA.Add(currentdata);
                    Loaddata();
                }
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
                isok = usersDA.Update(currentdata);               
                Loaddata();
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
                isok = usersDA.Delete(currentdata);               
                Loaddata();
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Silme Hatası", ex.Message);
            }
            return isok;
        }
        #endregion
    }
}
