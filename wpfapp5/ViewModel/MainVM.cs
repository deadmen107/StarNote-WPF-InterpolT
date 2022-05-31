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
        StokVM stokVM;


        public MainVM()
        {          
            ObjMainService = new MainService();
            stokVM = new StokVM();
            Currentdata = new OrderModel();
            Currentdata.Costumerorder = new CostumerOrderModel();
            Currentdata.Joborder = new List<JobOrderModel>();
            Currentstok = new StokModel();
            LoadData(100);        
            Count = new List<string>() { "10", "100", "1000" };          
            clearcommand = new RelayCommand(Clear);
            filljobordercount();
        }



        #region Defines
        private List<int> jobordercount;
        public List<int> Jobordercount
        {
            get { return jobordercount; }
            set { jobordercount = value; RaisePropertyChanged("Jobordercount"); }
        }

        public static int pagecount { get; set; }

        private string klasöradıtxt;
        public string Klasöradıtxt
        {
            get { return klasöradıtxt; }
            set { klasöradıtxt = value; RaisePropertyChanged("Klasöradıtxt"); }
        }


        private List<string> filenolist;
        public List<string> Filenolist
        {
            get { return filenolist; }
            set { filenolist = value; RaisePropertyChanged("Filenolist"); }
        }

        private string currentcount;
        public string Currentcount
        {
            get { return currentcount; }
            set { currentcount = value; RaisePropertyChanged("Currentcount"); }
        }

        private List<JobOrderModel> orderlist;
        public List<JobOrderModel> Orderlist
        {
            get { return orderlist; }
            set { orderlist = value; RaisePropertyChanged("Orderlist"); }
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

        private List<OrderModel> mainlist;
        public List<OrderModel> Mainlist
        {
            get { return mainlist; }
            set { mainlist = value; RaisePropertyChanged("Mainlist"); }

        }

        private List<OrderModel> mainlistözel;
        public List<OrderModel> Mainlistözel
        {
            get { return mainlistözel; }
            set { mainlistözel = value; RaisePropertyChanged("Mainlistözel"); }

        }

        private List<OrderModel> alllist;
        public List<OrderModel> Alllist
        {
            get { return alllist; }
            set { alllist = value; RaisePropertyChanged("Alllist"); }
        }


        private List<OrderModel> mainlistfirma;
        public List<OrderModel> Mainlistfirma
        {
            get { return mainlistfirma; }
            set { mainlistfirma = value; RaisePropertyChanged("Mainlistfirma"); }
        }

        private List<OrderModel> mainlistharcama;
        public List<OrderModel> Mainlistharcama
        {
            get { return mainlistharcama; }
            set { mainlistharcama = value; RaisePropertyChanged("Mainlistharcama"); }
        }

        private List<OrderModel> mainlistothers;
        public List<OrderModel> Mainlistothers
        {
            get { return mainlistothers; }
            set { mainlistothers = value; RaisePropertyChanged("Mainlistothers"); }
        }

        private OrderModel currentdata;
        public OrderModel Currentdata
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
        private void filljobordercount()
        {
            Jobordercount = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                Jobordercount.Add(i);
            }
        }
        public void fillcurrentdata(int ID)
        {
            Currentdata = Alllist.Find(u => u.Costumerorder.Id == ID);
        }

        public string filljoborder()
        {
            string joborder = string.Empty;
            
            joborder = ObjMainService.Getjoborder();
            return joborder;
        }
            
        public List<JobOrderModel> Getorderlist(int Id)
        {
            return ObjMainService.Getselectedjoborders(Id);
        }
        
        private void Clear()
        {
            Currentdata = new OrderModel();
            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Kayıt Temizleme Tamamlandı", "");
        }     
        
        private bool DataValidation(OrderModel model)
        {
            bool isok = false;
            if (model.Costumerorder.Talimatadliye == "Talimat Adliye")
                model.Costumerorder.Talimatadliye = null;
            isok = true;
            return isok;
        }

        public bool Save()
        {
            bool isok = false;
            try
            {
                //currentdata.Beklenentutar =(Convert.ToDouble(currentdata.Önerilentutar) - currentdata.Ücret).ToString();               
                //currentdata.Kullanıcı = UserUtils.ActiveUser;
                //if (Currentdata.Joborder == null)
                //    Currentdata.Joborder = "";
                if (!DataValidation(currentdata))
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Data Validation Hatası", "");
                    return false;
                }


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
        
        public void Loadsources()
        {
            try
            {
                List<string> companies = new List<string>();
                List<string> costumers = new List<string>();
                helperclass model = ObjMainService.Getsource();
                Companylist = model.company;
                Costumerlist = model.costumer;
                foreach (var item in Companylist)
                {
                    companies.Add((item.Companyname.ToString()));
                }
                Companynamelist = new List<string>(companies);
                foreach (var item in Costumerlist)
                {
                    costumers.Add((item.İsim.ToString()));
                }
                Costumernamelist = new List<string>(costumers);
                Metodsourcelist = model.Method;
                Ödemesourcelist = model.Ödemeyöntem;
                Durumsourcelist = model.Durum;
                Birimsourcelist = model.Birim;
                Kdvsourcelist = model.Kdv;
                Ürünsourcelist = model.Ürün;
                Salesmansourcelist = model.Salesman;
                Ürün2sourcelist = model.mainürün;
                Ürün2sourcelistall = Ürün2sourcelist;
                Türsourcelist = model.tür;
                Türsdetayourcelist = model.türdetay;
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
                List<OrderModel> mainlist = new List<OrderModel>();
                Alllist = ObjMainService.GetAll();
                if (!UserUtils.Authority.Contains(UserUtils.Bütün_Kayıtlar))
                    mainlist = Alllist.Where(x => x.Costumerorder.Kullanıcı == UserUtils.ActiveUser).ToList();
                else
                    mainlist = Alllist;
                Mainlistfirma = mainlist.Where(X => X.Costumerorder.Tür == "ŞİRKETLER" && X.Costumerorder.Savetype==0).ToList();
                Mainlistözel = mainlist.Where(X => X.Costumerorder.Tür == "ÖZEL MÜŞTERİLER" && X.Costumerorder.Savetype==0).ToList();
                Mainlist = mainlist.Where(X => X.Costumerorder.Tür != "ÖZEL MÜŞTERİLER" && X.Costumerorder.Tür != "ŞİRKETLER" && X.Costumerorder.Savetype==0).ToList();
                Mainlistharcama = mainlist.Where(X =>X.Costumerorder.Satışyöntemi=="GIDER" && X.Costumerorder.Savetype == 1).ToList();
                Mainlistothers = mainlist.Where(X => X.Costumerorder.Satışyöntemi == "GELIR" && X.Costumerorder.Savetype == 1).ToList();
                Loadsources();
                //RefreshViews.pagecount = 0;
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Main Tablo Doldurma Tamamlandı", "");
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main Tablo Doldurma Hatası", ex.Message);
            }
        }
        
        public bool Update()
        {
            bool isok = false;
            try
            {
                //currentdata.Beklenentutar = (Convert.ToDouble(currentdata.Önerilentutar) - currentdata.Ücret).ToString();
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
        
        #region Dosya İşlemleri

        public bool Createfile(OrderModel model, int format)
        {
            bool isok = false;

            //string filenameforftp = currentdata.İsim + " " + Convert.ToDateTime(currentdata.Kayıttarihi).ToString("dd.MM.yyyy") +" "+ Convert.ToDateTime(currentdata.Kayıttarihi).ToString("HH.mm") + ".pdf";
            string filenameforftp = model.Costumerorder.İsim + " " + Convert.ToDateTime(model.Costumerorder.Kayıttarihi).ToString("dd.MM.yyyy") + " " + Convert.ToDateTime(model.Costumerorder.Kayıttarihi).ToString("HH.mm") + ".pdf";
            string folderdesktoppath = System.Environment.CurrentDirectory + "\\" + filenameforftp;
            string folderpath = model.Costumerorder.Id + "/" + "Starnote";
            try
            {
                FileUtils fileUtils = new FileUtils();
                filenameforftp = fileUtils.CheckIfFileExistsOnServer(folderpath, filenameforftp);
                if (fileUtils.createStandartFile(System.Environment.CurrentDirectory, filenameforftp, model, format))
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
            string folderpath = model.Mainid + "/" + model.Klasörno;
            try
            {
                if (fileUtils.SaveFile(folderdesktoppath, folderpath, filenameforftp))
                {

                    if (fileUtils.filltable(model))
                    {

                        LogVM.displaypopup("INFO", "Dosya Cloud Sisteme Yükledi  : "+filenameforftp);
                        isok = true;
                        //MessageBox.Show("Dosya Cloud Sisteme Yükledi", "Dosya Yükleme", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenmedi : "+ filenameforftp);
                    }
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenmedi : "+filenameforftp);
                }
            }
            catch (Exception ex)
            {
                LogVM.displaypopup("ERROR", "Dosya Cloud Sisteme Yüklenemedi : "+filenameforftp);
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main İrsaliye kaydetme Hatası", ex.Message);
            }
            return isok;
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
                        string folderpath = Currentdata.Costumerorder.Id + "/" + localfile.Klasöradı;
                        FileUtils fileUtils = new FileUtils();
                        FilemanagementModel model = new FilemanagementModel();
                        model.Id = 0;
                        if (issave)
                            model.Mainid = filemainid;
                        else
                            model.Mainid = Currentdata.Costumerorder.Id;
                        model.Türadı = Currentdata.Costumerorder.Tür;
                        model.Türdetay = Currentdata.Costumerorder.Türdetay;
                        model.Kayıtdetay = Currentdata.Costumerorder.Kayıtdetay;
                        model.Firmadı = Currentdata.Costumerorder.Firmaadı;
                        model.Klasörno = localfile.Klasöradı;
                        model.Müşteriadı = Currentdata.Costumerorder.İsim;
                        model.Dosyaadı = fileUtils.CheckIfFileExistsOnServer(folderpath, filename);                                          
                        Fileupload(model, localfile.Dosya);
                    }
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Yeni kayıt dosya yükleme hatası", ex.Message);
            }
        }

        public void getselectedfilelist(int id)
        {
            List<FilemanagementModel> list = new List<FilemanagementModel>();
            List<LocalfileModel> locallist = new List<LocalfileModel>();
            List<string> listfilenames = new List<string>();
            list = ObjMainService.Getselectedfilelist(id);
            foreach (var item in list)
            {
                listfilenames.Add(item.Klasörno);
                LocalfileModel model = new LocalfileModel()
                {
                    Id = item.Id,
                    Dosya = item.Dosyaadı,
                    Durum = FileUtils.yüklendi,
                    Klasöradı = item.Klasörno,
                    Mainid = item.Mainid
                };
                locallist.Add(model);
            }
            Localfilelist = locallist;
            Filenolist = listfilenames.Distinct().ToList();
        }

        public void changelocalfilelist(int id)
        {
            var model = Localfilelist.Single(r => r.Id == id);
            if (model.Durum != "YÜKLENDİ")
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

        #region UI İşlemleri

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

        public void Getselectedcompany(string Companyname)
        {
            try
            {
                if (Companyname != null && Companyname != string.Empty)
                {
                    CompanyModel companymodel = Companylist.Find(item => item.Companyname == Companyname);
                    Currentdata.Costumerorder.Firmaadı = companymodel.Companyname;
                    Currentdata.Costumerorder.Firmaadresi = companymodel.Companyadress;
                    Currentdata.Costumerorder.Vergino = companymodel.Taxno;
                    Currentdata.Costumerorder.Vergidairesi = companymodel.Taxname;
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
                    currentdata.Costumerorder.İsim = costumerModel.İsim;
                    currentdata.Costumerorder.Tckimlik = costumerModel.Tckimlik;
                    currentdata.Costumerorder.Telefon = costumerModel.Telefon;
                    currentdata.Costumerorder.Eposta = costumerModel.Eposta;
                    currentdata.Costumerorder.Şehir = costumerModel.Şehir;
                    currentdata.Costumerorder.İlçe = costumerModel.İlçe;
                    currentdata.Costumerorder.Adres = costumerModel.Adres;
                }
            }
            catch (Exception)
            {

            }
        }

        public void sayfahesaplama(int Tag)
        {
            string kelime = Currentdata.Joborder.Find(u => u.Id == Tag).Kelimesayı.ToString();
            string satır = Currentdata.Joborder.Find(u => u.Id == Tag).Satırsayı.ToString();
            string karakter = Currentdata.Joborder.Find(u => u.Id == Tag).Karaktersayı.ToString();
            int value;
            int value1;
            int vlaue2;
            if (int.TryParse(kelime, out value) && int.TryParse(satır, out value1) && int.TryParse(karakter, out vlaue2))
            {
                Currentstok = stokVM.Stoklist.Find(u => u.Stokadı == Currentdata.Joborder.Find(i => i.Id == Tag).Ürün);

                double kelimesayfa, satırsayfa, karaktersayfa;
                kelimesayfa = Convert.ToDouble(kelime) / 180;
                satırsayfa = Convert.ToDouble(satır) / 20;
                karaktersayfa = Convert.ToDouble(karakter) / 1000;

                if (kelimesayfa > satırsayfa && kelimesayfa > karaktersayfa)
                {
                    //kelime out
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplanantutar = (Math.Ceiling(kelimesayfa) * Currentstok.Satışfiyat);
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplananadet = (int)Math.Ceiling(kelimesayfa);
                }
                else if (satırsayfa > kelimesayfa && satırsayfa > karaktersayfa)
                {
                    //satır out
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplanantutar = (Math.Ceiling(satırsayfa) * Currentstok.Satışfiyat);
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplananadet = (int)Math.Ceiling(satırsayfa);
                }
                else if (karaktersayfa > kelimesayfa && karaktersayfa > satırsayfa)
                {
                    //karakter out
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplanantutar = (Math.Ceiling(karaktersayfa) * Currentstok.Satışfiyat);
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplananadet = (int)Math.Ceiling(karaktersayfa);
                }
                else
                {
                    //satır out
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplanantutar = 0;
                    Currentdata.Joborder.Find(u => u.Id == Tag).Hesaplananadet = 0;
                }
            }
        }

        public void getmainprice()
        {
            currentdata.Costumerorder.Beklenentutar = 0.0;
            List<JobOrderModel> list = currentdata.Joborder;
            double price = 0.0;
            foreach (var model in list)
            {
                price += model.Ücret;
            }
            currentdata.Costumerorder.Beklenentutar = price;
        }

        public void ürünfiyathesaplama(int Tag,bool mahkememi=false)
        {
            string miktarstr = Currentdata.Joborder.Find(u => u.Id == Tag).Miktar.ToString();
            int value;

            if (int.TryParse(miktarstr, out value))
            {
                Currentstok = stokVM.Stoklist.Find(u => u.Stokadı == Currentdata.Joborder.Find(i => i.Id == Tag).Ürün);
                if (mahkememi)
                    Currentdata.Joborder.Find(u => u.Id == Tag).Ücret = 122 * Convert.ToDouble(miktarstr);
                else                              
                Currentdata.Joborder.Find(u => u.Id == Tag).Ücret = Currentstok.Satışfiyat * Convert.ToDouble(miktarstr);

            }
        }

        public bool anasiparişdurumuhesaplama()
        {
            List<JobOrderModel> list = currentdata.Joborder;
            bool isok = true;
            foreach (var model in list)
            {
                if (model.Durum != "TAMAMLANDI")
                {
                    return false;
                }
            }
            return isok;
        }
        #endregion

        #endregion







    }


}
