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
using System.Threading;
using StarNote.Utils;

namespace StarNote.ViewModel 
{
    public class UsersVM : BaseModel
    {
        BaseDa dataacces;
        bool isDataValid = false;
        public UsersVM()
        {
            dataacces = new BaseDa();
            Currentdata = new UsersModel();
            Savecommand = new RelayCommand(Save);
            Updatecommand = new RelayCommand(Update);
            Gobackcommand = new RelayCommand(GoBack);
            Savebtnvisibility = Visibility.Visible;
            Updatebtnvisibility = Visibility.Hidden;
            Tabledoubleclick = new RelayparameterCommand(fillcurrentdata, CanExecuteMyMethod);
            Deletecommand = new RelayparameterCommand(Delete, CanExecuteMyMethod);
            Newsavechange = new RelayCommand(Preparenewsave);
            Loaddata();
            Thread uservmthread = new Thread(DataValidChecker);
            uservmthread.Start();
        }
        private void DataValidChecker()
        {
            while (true)
            {
                if (MainWindow.ActivePage == MainWindow.AppPages.ProductUC || MainWindow.ActivePage == MainWindow.AppPages.ProductAddUC)
                {
                    if (!isDataValid)
                    {
                        Loaddata();
                        isDataValid = true;
                    }
                }
                else
                {
                    isDataValid = false;
                }
            }
        }

        #region Defines

        #region variable

        private Visibility updatebtnvisibility;

        public Visibility Updatebtnvisibility
        {
            get { return updatebtnvisibility; }
            set { updatebtnvisibility = value; RaisePropertyChanged("Updatebtnvisibility"); }
        }

        private Visibility savebtnvisibility;

        public Visibility Savebtnvisibility
        {
            get { return savebtnvisibility; }
            set { savebtnvisibility = value; RaisePropertyChanged("Savebtnvisibility"); }
        }

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

        #region commands
        private RelayCommand newsavechange;
        public RelayCommand Newsavechange
        {
            get { return newsavechange; }
            set { newsavechange = value; RaisePropertyChanged("Newsavechange"); }
        }

        private RelayparameterCommand deletecommand;
        public RelayparameterCommand Deletecommand
        {
            get { return deletecommand; }
            set { deletecommand = value; RaisePropertyChanged("Deletecommand"); }
        }


        private RelayparameterCommand tabledoubleclick;
        public RelayparameterCommand Tabledoubleclick
        {
            get { return tabledoubleclick; }
            set { tabledoubleclick = value; RaisePropertyChanged("Tabledoubleclick"); }
        }
        private bool CanExecuteMyMethod(object parameter)
        {
            return true;
        }

        private RelayCommand updatecommand;
        public RelayCommand Updatecommand
        {
            get { return updatecommand; }
            set { updatecommand = value; RaisePropertyChanged("Updatecommand"); }
        }

        private RelayCommand savecommand;
        public RelayCommand Savecommand
        {
            get { return savecommand; }
            set { savecommand = value; RaisePropertyChanged("Savecommand"); }
        }

        private RelayCommand gobackcommand;

        public RelayCommand Gobackcommand
        {
            get { return gobackcommand; }
            set { gobackcommand = value; RaisePropertyChanged("Gobackcommand"); }
        }
        #endregion

        #region routes
        private const string controller = "User";
        private const string getAll = "GetUserList";
        private const string add = "AddUser";
        private const string update = "UpdateUser";
        private const string delete = "DeleteUser";
        #endregion

        #endregion

        #region Method
        private void Preparenewsave()
        {
            if (UserUtils.Authority.Contains(UserUtils.Üründetay_Ekle))
            {
                Currentdata = new Model.UsersModel();
                Savebtnvisibility = Visibility.Visible;
                Updatebtnvisibility = Visibility.Hidden;
                MainWindow.ChangePage(MainWindow.AppPages.ProductAddUC);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void fillcurrentdata(object sender)
        {
            Currentdata = sender as UsersModel;
            Updatebtnvisibility = Visibility.Visible;
            Savebtnvisibility = Visibility.Hidden;
            MainWindow.ChangePage(MainWindow.AppPages.ProductAddUC);
        }

        public void Loaddata()
        {
            try
            {
                Userlist = new List<UsersModel>(dataacces.DoGet(Userlist, controller, getAll).ToList());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Tablo Doldurma Hatası", ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                bool isok = dataacces.DoPost(Currentdata, controller, add);
                if (isok)
                {
                    MainWindow.ChangePage(MainWindow.AppPages.ProductUC);
                    Loaddata();
                    LogVM.displaypopup("INFO", "Kayıt Tamamlandı");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Kaydetme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Kaydetme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Kaydetme Hatası", ex.Message);
            }

        }

        public void Update()
        {
            try
            {
                bool isok = dataacces.DoPost(Currentdata, controller, update);
                if (isok)
                {
                    MainWindow.ChangePage(MainWindow.AppPages.ProductUC);
                    Loaddata();
                    LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Güncelleme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Güncelleme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Güncelleme Hatası", ex.Message);
            }
        }

        public void GoBack()
        {
            MainWindow.ChangePage(MainWindow.AppPages.ProductUC);
        }

        private void Delete(object sender)
        {

            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_Sil))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Stok Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        fillcurrentdata(sender);
                        bool isok = dataacces.DoPost(Currentdata, controller, delete);
                        if (isok)
                        {
                            Loaddata();
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcı Silme Tamamlandı", "");
                        }
                        else
                        {
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Silme Hatası", "");
                        }

                    }
                    catch (Exception ex)
                    {
                        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcı Silme Hatası", ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        #endregion
    }
}
