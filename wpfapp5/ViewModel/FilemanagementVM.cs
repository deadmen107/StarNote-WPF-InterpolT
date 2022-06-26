using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using StarNote.Command;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using StarNote.Utils;

namespace StarNote.ViewModel
{
    public class FilemanagementVM : BaseModel
    {

        BaseDa dataacces;
        bool isDataValid = false;
        public FilemanagementVM()
        {

            dataacces = new BaseDa();
            Currentdata = new FilemanagementModel();
            Savecommand = new RelayCommand(Save);
            Updatecommand = new RelayCommand(Update);
            Gobackcommand = new RelayCommand(GoBack);
            Savebtnvisibility = Visibility.Visible;
            Updatebtnvisibility = Visibility.Hidden;
            Tabledoubleclick = new RelayparameterCommand(fillcurrentdata, CanExecuteMyMethod);
            Deletecommand = new RelayparameterCommand(DeleteFilefromftp, CanExecuteMyMethod);
            Deletecommand = new RelayparameterCommand(Downloadfile, CanExecuteMyMethod);

            Newsavechange = new RelayCommand(Preparenewsave);
            Loaddata();
            Thread filemanagementVM = new Thread(DataValidChecker);
            filemanagementVM.Start();
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

        private List<FilemanagementModel> filelist;
        public List<FilemanagementModel> Filelist
        {
            get { return filelist; }
            set { filelist = value; RaisePropertyChanged("Filelist"); }
        }

        private FilemanagementModel currentdata;
        public FilemanagementModel Currentdata
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

        private RelayparameterCommand downloadcommand;

        public RelayparameterCommand Downloadcommand
        {
            get { return downloadcommand; }
            set { downloadcommand = value; RaisePropertyChanged("Downloadcommand"); }
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
        private const string controller = "FileManagement";
        private const string getAll = "Getfilelist";
        private const string add = "Add";
        private const string update = "Update";
        private const string delete = "Delete";
        #endregion

        #endregion

        #region Method

        public void Downloadfile(object sender)
        {
            try
            {
                fillcurrentdata(sender);
                FileUtils fileUtils = new FileUtils();
                fileUtils.DownloadFile(currentdata);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya İndirme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya İndirme Hatası", ex.Message);
            }
           
        }

        public void DeleteFilefromftp(object sender)
        {
            try
            {
                FileUtils fileUtils = new FileUtils();
                if (fileUtils.DeleteFilefromtable(currentdata))
                {
                    Delete(sender);
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Api Dosya Silme Tamamlandı", "");
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Api Dosya Silme Hatası", ex.Message);
            }
        }

        public bool printirsaliye(FilemanagementModel model, string path)
        {
            bool isok = false;
            FileUtils fileUtils = new FileUtils();


            string filenameforftp = model.Dosyaadı;
            string folderdesktoppath = path;
            string folderpath = model.Türadı + "/" + model.Firmadı;
            try
            {
                if (fileUtils.SaveFile(folderdesktoppath, folderpath, filenameforftp))
                {

                    if (fileUtils.filltable(model))
                    {

                        LogVM.displaypopup("INFO", "Dosya Cloud Sisteme Yükledi");
                        isok = true;
                        //MessageBox.Show("Dosya Cloud Sisteme Yükledi", "Dosya Yükleme", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenmedi");
                    }
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenmedi");
                }
            }
            catch (Exception ex)
            {
                LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenemedi");
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main İrsaliye kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        private void Preparenewsave()
        {
            if (UserUtils.Authority.Contains(UserUtils.Üründetay_Ekle))
            {
                Currentdata = new Model.FilemanagementModel();
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
            Currentdata = sender as FilemanagementModel;
            Updatebtnvisibility = Visibility.Visible;
            Savebtnvisibility = Visibility.Hidden;
            MainWindow.ChangePage(MainWindow.AppPages.ProductAddUC);
        }

        public void Loaddata()
        {
            try
            {
                filelist = new List<FilemanagementModel>(dataacces.DoGet(filelist, controller, getAll).ToList());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Müşteriler Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Müşteriler Tablo Doldurma Hatası", ex.Message);
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
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Müşteriler Kaydetme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Kaydetme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Müşteriler Kaydetme Hatası", ex.Message);
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
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Müşteriler Güncelleme Tamamlandı", "");
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Güncelleme Başarısız");

                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Müşteriler Güncelleme Hatası", ex.Message);
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
                MessageBoxResult result = MessageBox.Show(msg, "Müşterile Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Müşteriler Silme Tamamlandı", "");
                        }
                        else
                        {
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Müşteriler Silme Hatası", "");
                        }

                    }
                    catch (Exception ex)
                    {
                        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Müşteriler Silme Hatası", ex.Message);
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
