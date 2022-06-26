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
using StarNote.Utils;
using System.Threading;

namespace StarNote.ViewModel
{
    public class TypeVM : BaseModel
    {
        BaseDa dataacces;
        bool isDataValid = false;
        public TypeVM()
        {

            dataacces = new BaseDa();
            Currentdata = new ParameterModel();
            Savecommand = new RelayCommand(Save);
            Updatecommand = new RelayCommand(Update);
            Gobackcommand = new RelayCommand(GoBack);
            Savebtnvisibility = Visibility.Visible;
            Updatebtnvisibility = Visibility.Hidden;
            Tabledoubleclick = new RelayparameterCommand(fillcurrentdata, CanExecuteMyMethod);
            Deletecommand = new RelayparameterCommand(Delete, CanExecuteMyMethod);
            Newsavechange = new RelayCommand(Preparenewsave);
            Loaddata();
            Thread CompanyVMThread = new Thread(DataValidChecker);
            CompanyVMThread.Start();
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

        private List<ParameterModel> typelist;
        public List<ParameterModel> Typelist
        {
            get { return typelist; }
            set { typelist = value; RaisePropertyChanged("Typelist"); }
        }

        private ParameterModel currentdata;
        public ParameterModel Currentdata
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
        private const string controller = "Type";
        private const string getAll = "GetTürList";
        private const string add = "AddTür";
        private const string update = "UpdateTür";
        private const string delete = "DeleteTür";
        #endregion

        #endregion

        #region Method
        private void Preparenewsave()
        {
            if (UserUtils.Authority.Contains(UserUtils.Üründetay_Ekle))
            {
                Currentdata = new Model.ParameterModel();
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
            Currentdata = sender as ParameterModel;
            Updatebtnvisibility = Visibility.Visible;
            Savebtnvisibility = Visibility.Hidden;
            MainWindow.ChangePage(MainWindow.AppPages.ProductAddUC);
        }

        public void Loaddata()
        {
            try
            {
                Typelist = new List<ParameterModel>(dataacces.DoGet(Typelist, controller, getAll).ToList());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Tablo Doldurma Hatası", ex.Message);
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
                    RefreshViews.ürün2source = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Kaydetme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Kaydetme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Kaydetme Hatası", ex.Message);
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
                    RefreshViews.ürün2source = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Güncelleme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Güncelleme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Firma Güncelleme Hatası", ex.Message);
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
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        fillcurrentdata(sender);
                        bool isok = dataacces.DoPost(Currentdata, controller, delete);
                        if (isok)
                        {
                            Loaddata();
                            RefreshViews.ürün2source = true;
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Adliye Silme Tamamlandı", "");
                        }
                        else
                        {
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Adliye Silme Hatası", "");
                        }

                    }
                    catch (Exception ex)
                    {
                        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Adliye Silme Hatası", ex.Message);
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
