using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarNote.Command;
using StarNote.DataAccess;
using StarNote.Model;
using StarNote.Service;
using StarNote.Utils;

namespace StarNote.ViewModel
{
    public class FilemanagementVM : BaseModel
    {
        FilemanagementDA filemanagementDA;
        public FilemanagementVM()
        {
            filemanagementDA = new FilemanagementDA();
            currentdata = new FilemanagementModel();
            if (RefreshViews.appstatus)
                Loaddata();
        }

        #region Defines
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

        #region Method

        public void Loaddata()
        {
            try
            {
                Filelist = new List<FilemanagementModel>(filemanagementDA.GetAll());
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Takip Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Takip Tablo Doldurma Hatası", ex.Message);
            }
        }

        public bool Downloadfile()
        {
            bool isok = false;
            try
            {
                FileUtils fileUtils = new FileUtils();
                fileUtils.DownloadFile(currentdata);
                isok = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya İndirme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya İndirme Hatası", ex.Message);
            }
            return isok;
        }

        public bool DeleteFilefromftp()
        {
            bool isok = false;
            try
            {
                FileUtils fileUtils = new FileUtils();
                if (fileUtils.DeleteFilefromtable(currentdata))
                {
                    Delete();
                    isok = true;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Api Dosya Silme Tamamlandı", "");
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Api Dosya Silme Hatası", ex.Message);
            }
            return isok;

        }

        private bool Delete()
        {
            bool isok = false;
            try
            {
                isok = filemanagementDA.Delete(currentdata);
                Loaddata();
                isok = true;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tablo Dosya Silme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tablo Dosya Silme Hatası", ex.Message);
            }
            return isok;

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
        #endregion
    }
}
