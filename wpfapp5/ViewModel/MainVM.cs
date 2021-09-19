using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using StarNote.Model;
using StarNote.Command;
using StarNote.View;
using StarNote.Service;
using System.Globalization;
using StarNote.DataAccess;
using StarNote.Utils;
using System.Net;
using DevExpress.Xpf.WindowsUI;
using System.Windows;
using System.IO;

namespace StarNote.ViewModel
{
    public class MainVM : BaseModel
    {
        MainService ObjMainService;
 
        

        public MainVM()
        {          
            ObjMainService = new MainService();
            Currentdata = new MainModel();
            Currentstok = new StokModel();
            LoadData(100);        
            Count = new List<string>() { "10", "100", "1000" };          
            clearcommand = new RelayCommand(Clear);            
        }

        #region Defines

        public static int pagecount { get; set; }

        private string currentcount;
        public string Currentcount
        {
            get { return currentcount; }
            set { currentcount = value; RaisePropertyChanged("Currentcount"); }
        }

        private StokModel currentstok;
        public StokModel Currentstok
        {
            get { return currentstok; }
            set { currentstok = value; RaisePropertyChanged("Currentstok"); }
        }

        private LocalfileModel localfile;
        public LocalfileModel Localfile
        {
            get { return localfile; }
            set { localfile = value; RaisePropertyChanged("Localfile"); }
        }

        private List<string> joborderlist;
        public List<string> Joborderlist
        {
            get { return joborderlist; }
            set { joborderlist = value; RaisePropertyChanged("Joborderlist"); }
        }

        private List<string> companynamelist;
        public List<string> Companynamelist
        {
            get { return companynamelist; }
            set { companynamelist = value; RaisePropertyChanged("Companynamelist"); }
        }

        private List<string> costumernamelist;
        public List<string> Costumernamelist
        {
            get { return costumernamelist; }
            set { costumernamelist = value; RaisePropertyChanged("Costumernamelist"); }
        }

        private List<CostumerModel> costumerlist;
        public List<CostumerModel> Costumerlist
        {
            get { return costumerlist; }
            set { costumerlist = value; RaisePropertyChanged("Costumerlist"); }
        }

        private List<CompanyModel> companylist;
        public List<CompanyModel> Companylist
        {
            get { return companylist; }
            set { companylist = value; RaisePropertyChanged("Companylist"); }
        }

        private List<LocalfileModel> localfilelist;
        public List<LocalfileModel> Localfilelist
        {
            get { return localfilelist; }
            set { localfilelist = value; RaisePropertyChanged("Localfilelist"); }
        }


        private List<string> count;
        public List<string> Count
        {
            get { return count; }
            set { count = value; RaisePropertyChanged("Count"); }
        }

        private List<MainModel> mainlist;
        public List<MainModel> Mainlist
        {
            get { return mainlist; }
            set { mainlist = value; RaisePropertyChanged("Mainlist"); }

        }

        private List<MainModel> mainlistözel;
        public List<MainModel> Mainlistözel
        {
            get { return mainlistözel; }
            set { mainlistözel = value; RaisePropertyChanged("Mainlistözel"); }

        }

        private List<MainModel> mainlistfirma;
        public List<MainModel> Mainlistfirma
        {
            get { return mainlistfirma; }
            set { mainlistfirma = value; RaisePropertyChanged("Mainlistfirma"); }

        }

        private MainModel currentdata;
        public MainModel Currentdata
        {
            get { return currentdata; }
            set { currentdata = value; RaisePropertyChanged("Currentdata"); }
        }
        
        private RelayCommand clearcommand;
        public RelayCommand Clearcommand
        {
            get { return clearcommand; }

        }
        
        #region sourcelist

        private List<string> ürün2sourcelist;
        public List<string> Ürün2sourcelist
        {
            get { return ürün2sourcelist; }
            set { ürün2sourcelist = value; RaisePropertyChanged("Ürün2sourcelist"); }
        }

        private List<string> ürün2sourcelistall;
        public List<string> Ürün2sourcelistall
        {
            get { return ürün2sourcelistall; }
            set { ürün2sourcelistall = value; RaisePropertyChanged("Ürün2sourcelistall"); }
        }

        private List<string> salesmansourcelist;
        public List<string> Salesmansourcelist
        {
            get { return salesmansourcelist; }
            set { salesmansourcelist = value; RaisePropertyChanged("Salesmansourcelist"); }
        }

        private List<string> metodsourcelist;
        public List<string> Metodsourcelist
        {
            get { return metodsourcelist; }
            set { metodsourcelist = value; RaisePropertyChanged("Metodsourcelist"); }
        }

        private List<string> durumsourcelist;
        public List<string> Durumsourcelist
        {
            get { return durumsourcelist; }
            set { durumsourcelist = value; RaisePropertyChanged("Durumsourcelist"); }
        }

        private List<string> ödemesourcelist;
        public List<string> Ödemesourcelist
        {
            get { return ödemesourcelist; }
            set { ödemesourcelist = value; RaisePropertyChanged("Ödemesourcelist"); }
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

        private List<string> ürünsourcelist;
        public List<string> Ürünsourcelist
        {
            get { return ürünsourcelist; }
            set { ürünsourcelist = value; RaisePropertyChanged("Ürünsourcelist"); }
        }

        private List<string> türsourcelist;
        public List<string> Türsourcelist
        {
            get { return türsourcelist; }
            set { türsourcelist = value; RaisePropertyChanged("Türsourcelist"); }
        }

        private List<string> türsdetayourcelist;
        public List<string> Türsdetayourcelist
        {
            get { return türsdetayourcelist; }
            set { türsdetayourcelist = value; RaisePropertyChanged("Türsdetayourcelist"); }
        }
        #endregion

        #endregion

        #region Method
        public string filljoborder()
        {
            string joborder = string.Empty;
            
            joborder = ObjMainService.Getjoborder();
            return joborder;
        }
            
        public bool Createfile(List<MainModel> list,int format)
        {
            bool isok = false;

            //string filenameforftp = currentdata.İsim + " " + Convert.ToDateTime(currentdata.Kayıttarihi).ToString("dd.MM.yyyy") +" "+ Convert.ToDateTime(currentdata.Kayıttarihi).ToString("HH.mm") + ".pdf";
            string filenameforftp = list[0].Joborder + " " + list[0].İsim + " " + Convert.ToDateTime(list[0].Kayıttarihi).ToString("dd.MM.yyyy") + " " + Convert.ToDateTime(list[0].Kayıttarihi).ToString("HH.mm") + ".pdf";
            string folderdesktoppath = System.Environment.CurrentDirectory+"\\"+ filenameforftp;           
            string folderpath = list[0].Tür + "/" + list[0].Firmaadı;
            try
            {
                FileUtils fileUtils = new FileUtils();
                filenameforftp = fileUtils.CheckIfFileExistsOnServer(folderpath, filenameforftp);
                if (fileUtils.createStandartFile(System.Environment.CurrentDirectory, filenameforftp, list,format))
                {
                    isok = true;
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main İrsaliye kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        public bool Fileupload(FilemanagementModel model, string path)
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

        public void fillstok(string name)
        {
            try
            {
                Currentstok = ObjMainService.Getselectedstok(name);
               
                
            }
            catch (Exception)
            {

                
            }
           
        }

        private void Clear()
        {
            Currentdata = new MainModel();
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Kayıt Temizleme Tamamlandı", "");
        }     

        private void uploadfiles(bool issave)
        {
            int filemainid = ObjMainService.Getnewmainid();
            try
            {
                foreach (var localfile in Localfilelist)
                {
                    if (localfile.Durum == FileUtils.hazır)
                    {
                        string filename = Path.GetFileName(localfile.Dosya);
                        FilemanagementModel model = new FilemanagementModel();                        
                        model.Id = 0;
                        FileUtils fileUtils = new FileUtils();
                        string folderpath = currentdata.Tür + "/" + currentdata.Firmaadı;
                        model.Dosyaadı = fileUtils.CheckIfFileExistsOnServer(folderpath, filename);
                        //model.Dosyaadı = filename;
                        model.Firmadı = currentdata.Firmaadı;
                        model.Müşteriadı = currentdata.İsim;
                        model.Türadı = currentdata.Tür;
                        model.Kayıtdetay = currentdata.Kayıtdetay;
                        if (issave)
                            model.Mainid = filemainid;
                        else
                            model.Mainid = currentdata.Id;
                        model.Türdetay = currentdata.Türdetay;
                        model.İşemrino = currentdata.Joborder;                    
                        Fileupload(model, localfile.Dosya);
                    }
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Yeni kayıt dosya yükleme hatası", ex.Message);
            }          
        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                currentdata.Beklenentutar =(Convert.ToDouble(currentdata.Önerilentutar) - currentdata.Ücret).ToString();               
                currentdata.Kullanıcı = UserUtils.ActiveUser;
                if (Currentdata.Joborder == null)
                    Currentdata.Joborder = "";
                isok = ObjMainService.Add(currentdata);
                if (isok)
                {
                    uploadfiles(true);
                }              
                LoadData(1000);                
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Kaydetme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Kaydetme Hatası", ex.Message);
            }
            return isok;
        }

        public void Getselectedcompany(string Companyname)
        {           
            try
            {
                if (Companyname!=null&&Companyname!=string.Empty)
                {
                    CompanyModel companymodel = Companylist.Find(item => item.Companyname == Companyname);
                    Currentdata.Firmaadı = companymodel.Companyname;
                    Currentdata.Firmaadresi = companymodel.Companyadress;
                    Currentdata.Vergino = companymodel.Taxno;
                    Currentdata.Vergidairesi = companymodel.Taxname;
                }                         
            }
            catch (Exception)
            {
                
            }           
        }

        public void Getselectedcostumer(string Costumername)
        {
            try
            {
                if (Costumername != null && Costumername != string.Empty)
                {
                    CostumerModel costumerModel = Costumerlist.Find(item => item.İsim == Costumername);
                    Currentdata.İsim = costumerModel.İsim;
                    Currentdata.Tckimlik = costumerModel.Tckimlik;
                    Currentdata.Telefon = costumerModel.Telefon;
                    Currentdata.Eposta = costumerModel.Eposta;
                    Currentdata.Şehir = costumerModel.Şehir;
                    Currentdata.İlçe = costumerModel.İlçe;
                    Currentdata.Adres = costumerModel.Adres;
                }
            }
            catch (Exception)
            {
             
            }
        }

        public void Loadsources()
        {
            try
            {
                List<string> companies = new List<string>();
                List<string> costumers = new List<string>();
                if (RefreshViews.Loadcompany)
                {
                    Companylist = new List<CompanyModel>(ObjMainService.GetcompanySource());
                    foreach (var item in Companylist)
                    {
                        companies.Add((item.Companyname.ToString()));
                    }
                    Companynamelist = new List<string>(companies);
                    RefreshViews.Loadcompany = false;                   
                }
                if (RefreshViews.Loadcustomer)
                {
                    Costumerlist = new List<CostumerModel>(ObjMainService.GetcostumerSource());
                    foreach (var item in Costumerlist)
                    {
                        costumers.Add((item.İsim.ToString()));
                    }
                    Costumernamelist = new List<string>(costumers);
                    RefreshViews.Loadcustomer = false;
                }
                if (RefreshViews.Methodsource)
                {
                    Metodsourcelist = new List<string>(ObjMainService.methodsource());
                    RefreshViews.Methodsource = false;
                }
                if (RefreshViews.ödemeyöntemsource)
                {
                    Ödemesourcelist = new List<string>(ObjMainService.ödemeyöntemsource());
                    RefreshViews.ödemeyöntemsource = false;
                }
                if (RefreshViews.Durumsource)
                {
                    Durumsourcelist = new List<string>(ObjMainService.durumsource());
                    RefreshViews.Durumsource = false;
                }
                if (RefreshViews.Birimsource)
                {
                    Birimsourcelist = new List<string>(ObjMainService.birimsource());
                    RefreshViews.Birimsource = false;
                }
                if (RefreshViews.KDVsource)
                {
                    Kdvsourcelist = new List<string>(ObjMainService.kdvsource());
                    RefreshViews.KDVsource = false;
                }
                if (RefreshViews.Ürünsource)
                {
                    Ürünsourcelist = new List<string>(ObjMainService.ürünsource()).Distinct().ToList();
                    RefreshViews.Ürünsource = false;
                }
                if (RefreshViews.salesmansource)
                {
                    Salesmansourcelist = new List<string>(ObjMainService.salesmansource());
                    RefreshViews.salesmansource = false;
                }
                if (RefreshViews.ürün2source)
                {
                    Ürün2sourcelist = ObjMainService.ürün2source();
                    Ürün2sourcelistall = Ürün2sourcelist;
                    RefreshViews.ürün2source = false;
                }
                if (RefreshViews.türsource)
                {
                    Türsourcelist = ObjMainService.türsource();
                    RefreshViews.türsource = false;
                }
                if (RefreshViews.türdetaysource)
                {
                    Türsdetayourcelist = ObjMainService.typedetailsource();
                    RefreshViews.türdetaysource = false;
                }
                Joborderlist = ObjMainService.Getjoborderlist();                   
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Combobox Doldurma Tamamlandı", "");
               
               
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Combobox Doldurma Hatası", ex.Message);
            }
        }

        public void LoadData(int count)
        {
            try
            {
                List<MainModel> Alllist = new List<MainModel>();
                List<MainModel> mainlist = new List<MainModel>();
                Alllist = ObjMainService.GetAll();
                if (!UserUtils.Authority.Contains(UserUtils.Bütün_Kayıtlar))                
                    mainlist = Alllist.Where(x => x.Kullanıcı == UserUtils.ActiveUser).ToList();               
                else                
                    mainlist = Alllist;                               
                Mainlistfirma = mainlist.Where(X => X.Tür == "ŞİRKETLER").ToList();
                Mainlistözel = mainlist.Where(X => X.Tür == "ÖZEL MÜŞTERİLER").ToList();
                Mainlist = mainlist.Where(X => X.Tür != "ÖZEL MÜŞTERİLER" && X.Tür != "ŞİRKETLER").ToList();
                Loadsources();
                RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Tablo Doldurma Hatası", ex.Message);
            }
        }

        public void getselectedfilelist(int id)
        {
            List<FilemanagementModel> list = new List<FilemanagementModel>();
            List<LocalfileModel> locallist = new List<LocalfileModel>();
            list = ObjMainService.Getselectedfilelist(id);
            foreach (var item in list)
            {
                LocalfileModel model = new LocalfileModel()
                {
                    Id = item.Id,
                    Dosya = item.Dosyaadı,
                    Durum = FileUtils.yüklendi,
                    Mainid = item.Mainid
                };
                locallist.Add(model);
            }
            Localfilelist = locallist;
        }

        public bool Update()
        {
            bool isok = false;
            try
            {
                currentdata.Beklenentutar = (Convert.ToDouble(currentdata.Önerilentutar) - currentdata.Ücret).ToString();
                isok = ObjMainService.Update(currentdata);
                uploadfiles(false);
                LoadData(1000);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Güncelleme Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Güncelleme Hatası", ex.Message);
            }
            return isok;
        }

        public void changelocalfilelist(int id)
        {          
            var model = Localfilelist.Single(r => r.Id == id);
            if (model.Durum!="YÜKLENDİ")
            {
                Localfilelist.Remove(model);
                LogVM.displaypopup("INFO", "Dosya Kaldırıldı");
            }
            else
            {
                LogVM.displaypopup("ERROR", "Yüklenmiş dosya kaldırılamaz!!");
            }
           
        }
        #endregion





       

    }

  
}
