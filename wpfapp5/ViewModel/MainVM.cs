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
using System.Threading;
using System.Drawing;

namespace StarNote.ViewModel
{
    public class MainVM : BaseModel
    {
        StokVM stokVM;
        BaseDa dataacces;
        bool isDataValid = false;

        public MainVM()
        {
            dataacces = new BaseDa();
            Currentdata = new OrderModel();
            Currentdata.Costumerorder = new CostumerOrderModel();
            Currentdata.Joborder = new List<JobOrderModel>();
            Currentstok = new StokModel();
            stokVM = new StokVM();
            Joborderrowhight = new GridLength(100);
            Savebtnvisibility = Visibility.Visible;
            Updatebtnvisibility = Visibility.Hidden;
            Commandinit();
            filljobordercount();
            LoadData();
            Thread mainvmThread = new Thread(DataValidChecker);
            mainvmThread.Start();
        }
        private void DataValidChecker()
        {
            while (true)
            {
                if (
                    MainWindow.ActivePage == MainWindow.AppPages.MainGrid || 
                    MainWindow.ActivePage == MainWindow.AppPages.MainCompanyEdit ||
                    MainWindow.ActivePage == MainWindow.AppPages.MainLawEdit ||
                    MainWindow.ActivePage == MainWindow.AppPages.MainPrivateEdit||
                    MainWindow.ActivePage == MainWindow.AppPages.MainPurchaseEdit ||
                    MainWindow.ActivePage == MainWindow.AppPages.MainSalesEdit
                    )
                {
                    if (!isDataValid)
                    {
                        LoadData();
                        isDataValid = true;
                    }
                }
                else
                {
                    isDataValid = false;
                }
            }
        }

        private void Commandinit()
        {
            Savecommand = new RelayCommand(Save);
            Updatecommand = new RelayCommand(Update);
            Gobackcommand = new RelayCommand(GoBack);
            Addnewsubitemcommand = new RelayCommand(Addsubitem);
            Companynamechangedcommand = new RelayCommand(Getselectedcompany);
            Costumernamechangedcommand = new RelayCommand(Getselectedcostumer);
            Tabledoubleclick = new RelayparameterCommand(fillcurrentdata, CanExecuteMyMethod);
            Deletesubitemcommand = new RelayparameterCommand(DeleteSubItem, CanExecuteMyMethod);
            Newsavechange = new RelayCommand(Preparenewsave);
            Subpricechangedcommand = new RelayCommand(Subpricechanged);
            Amountchangedcommand = new RelayCommand(AmountChanged);
            Amountcalccommand = new RelayCommand(AmountCalc);
            clearcommand = new RelayCommand(Clear);
            Statechangedcommand = new RelayCommand(Statechanged);
            Deletesubfilecommand = new RelayparameterCommand(Deletesubfile, CanExecuteMyMethod);
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

        private GridLength joborderrowhight;

        public GridLength Joborderrowhight
        {
            get { return joborderrowhight; }
            set { joborderrowhight = value; RaisePropertyChanged("Joborderrowhight"); }
        }


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

        #region commands
        private bool CanExecuteMyMethod(object parameter)
        {
            return true;
        }

        private RelayCommand newsavechange;
        public RelayCommand Newsavechange
        {
            get { return newsavechange; }
            set { newsavechange = value; RaisePropertyChanged("Newsavechange"); }
        }

        private RelayparameterCommand tabledoubleclick;
        public RelayparameterCommand Tabledoubleclick
        {
            get { return tabledoubleclick; }
            set { tabledoubleclick = value; RaisePropertyChanged("Tabledoubleclick"); }
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

        private RelayCommand clearcommand;
        public RelayCommand Clearcommand
        {
            get { return clearcommand; }

        }

        private RelayCommand companynamechangedcommand;
        public RelayCommand Companynamechangedcommand
        {
            get { return companynamechangedcommand; }
            set { companynamechangedcommand = value; RaisePropertyChanged("Companynamechangedcommand"); }
        }

        private RelayCommand costumernamechangedcommand;
        public RelayCommand Costumernamechangedcommand
        {
            get { return costumernamechangedcommand; }
            set { costumernamechangedcommand = value; RaisePropertyChanged("Costumernamechangedcommand"); }
        }

        private RelayCommand addnewsubitemcommand;
        public RelayCommand Addnewsubitemcommand
        {
            get { return addnewsubitemcommand; }
            set { addnewsubitemcommand = value; RaisePropertyChanged("Addnewsubitemcommand"); }
        }

        private RelayparameterCommand deletesubitemcommand;
        public RelayparameterCommand Deletesubitemcommand
        {
            get { return deletesubitemcommand; }
            set { deletesubitemcommand = value; RaisePropertyChanged("Deletesubitemcommand"); }
        }

        private RelayCommand subpricechangedcommand;
        public RelayCommand Subpricechangedcommand
        {
            get { return subpricechangedcommand; }
            set { subpricechangedcommand = value; RaisePropertyChanged("Subpricechangedcommand"); }
        }


        private RelayCommand amountchangedcommand;
        public RelayCommand Amountchangedcommand
        {
            get { return amountchangedcommand; }
            set { amountchangedcommand = value; RaisePropertyChanged("Amountchangedcommand"); }
        }

        private RelayCommand amountcalccommand;
        public RelayCommand Amountcalccommand
        {
            get { return amountcalccommand; }
            set { amountcalccommand = value; RaisePropertyChanged("Amountcalccommand"); }
        }

        private RelayCommand statechangedcommand;
        public RelayCommand Statechangedcommand
        {
            get { return statechangedcommand; }
            set { statechangedcommand = value; RaisePropertyChanged("Statechangedcommand"); }
        }

        private RelayparameterCommand deletesubfilecommand;

        public RelayparameterCommand Deletesubfilecommand
        {
            get { return deletesubfilecommand; }
            set { deletesubfilecommand = value; RaisePropertyChanged("Deletesubfilecommand"); }
        }

        #endregion

        #region routes
        private const string controller = "MainScreen";
        private const string GetMainAll = "GetMainAll";
        private const string Getselectedjoborders = "Getselectedjoborders"; //Id
        private const string GetJobOrder = "GetJobOrder";
        private const string Getnewid = "Getnewid";
        private const string Getjoborderlist = "Getjoborderlist";
        private const string Getselectedstok = "Getselectedstok"; //name
        private const string UpdateMain = "UpdateMain";
        private const string Add = "AddMain";  //kayıt ve update date al
        private const string Addsoft = "AddMainSoft";//kayıt ve update date al
        private const string Getsource = "Getsources";
        private const string türsource = "GettürSource";
        private const string Getnewmainid = "Getnewid";
        private const string ürün2source = "GetproductSource";
        private const string ödemeyöntemsource = "GetödemeyöntemSource";
        private const string methodsource = "GetmethodSource";
        private const string durumsource = "GetdurumSource";
        private const string birimsource = "GetbirimSource";
        private const string kdvsource = "GetkdvSource";
        private const string ürünsource = "GetürünSource";
        private const string salesmansource = "GetsalesmanSource";
        private const string typedetailsource = "Gettypedetailsource";
        private const string GetcompanySource = "GetCompanySource";
        private const string Getselectedfilelist = "Getselectedfilelist"; //id
        private const string GetcostumerSource = "GetCostumerSource";
        #endregion

        #endregion

        #region Method

        private void Preparenewsave()
        {
            Loadsources();
            Localfilelist = new List<LocalfileModel>();
            Localfile = new LocalfileModel();
            Currentdata = new OrderModel();
            Currentdata.Costumerorder.Kayıttarihi = DateTime.Now.ToString();
            Currentdata.Costumerorder.Randevutarihi = DateTime.Now.AddMinutes(1).ToString();
            Currentdata.Costumerorder.Durum = "YAPILIYOR";
            Currentdata.Costumerorder.Satıselemanı = "MUSTAFA ŞAN";
            Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
            Currentdata.Costumerorder.Kdv = "%40";
            filljoborders(true);
            if (MainWindow.AppPages.MainLawEdit == MainWindow.ActivePage)
            {
                Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
            }
            if (MainWindow.AppPages.MainPrivateEdit == MainWindow.ActivePage)
            {
                Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                Currentdata.Costumerorder.Tür = "ÖZEL MÜŞTERİLER";
                Currentdata.Costumerorder.Firmaadı = "ŞAHIS";
            }
            if (MainWindow.AppPages.MainCompanyEdit == MainWindow.ActivePage)
            {
                Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                Currentdata.Costumerorder.Tür = "ŞİRKETLER";
                Currentdata.Costumerorder.Firmaadı = "ŞAHIS";
            }
            if (MainWindow.AppPages.MainPurchaseEdit == MainWindow.ActivePage)
            {
                Currentdata.Costumerorder.Durum = "TAMAMLANDI";
                Currentdata.Costumerorder.Kullanıcı = UserUtils.ActiveUser;
                Currentdata.Costumerorder.Satışyöntemi = "GIDER";
                Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                Currentdata.Costumerorder.Savetype = 1;
            }
            if (MainWindow.AppPages.MainSalesEdit == MainWindow.ActivePage)
            {
                Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                Currentdata.Costumerorder.Durum = "TAMAMLANDI";
                Currentdata.Costumerorder.Kullanıcı = UserUtils.ActiveUser;
                Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                Currentdata.Costumerorder.Savetype = 1;
            }
        }

        private void filljoborders(bool createnew)
        {
            try
            {
                int newid = 1;
                if (Currentdata.Joborder.Count != 0)
                    newid =Currentdata.Joborder.Max(u => u.Id);
                if (createnew)
                {
                    if (MainWindow.AppPages.MainPurchaseEdit != MainWindow.ActivePage && MainWindow.AppPages.MainSalesEdit != MainWindow.ActivePage)
                    {
                        Currentdata.Joborder.Add(new JobOrderModel()
                        {
                            Id = newid + 1,
                            Ücret = 0.0,
                            Birim = "SAYFA",
                            Durum = "YAPILIYOR",
                            Ürün2 = "TÜRKÇE",
                            Ürün = "TÜRKÇE"
                        });
                    }
                    else
                    {
                        Currentdata.Joborder.Add(new JobOrderModel()
                        {
                            Id = newid + 1,
                            Ücret = 0.0,
                            Birim = "",
                            Durum = "YAPILIYOR",
                            Ürün2 = "",
                            Ürün = ""
                        });
                    }
                }
                Joborderrowhight = new GridLength(100);
                for (int i = 0; i < Currentdata.Joborder.Count; i++)
                {
                    GridLength newlen = new GridLength(53);
                    Joborderrowhight = new GridLength(Joborderrowhight.Value + newlen.Value);
                }
                for (int i = 0; i < Currentdata.Joborder.Count; i++)
                {
                    Currentdata.Joborder[i].Lowerid = i + 1;
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private void fillcurrentdata(object sender)
        {
            var responsedata = sender as CostumerModel;
            Currentdata = Mainlist.FirstOrDefault(u => u.Costumerorder.Id == responsedata.Id);

            Updatebtnvisibility = Visibility.Visible;
            Savebtnvisibility = Visibility.Hidden;

            if(Currentdata.Costumerorder.Tür == "ÖZEL MÜŞLERİLER")
            {
                MainWindow.ChangePage(MainWindow.AppPages.MainPrivateEdit);
            }
            if (Currentdata.Costumerorder.Tür == "ŞİRKETLER")
            {
                MainWindow.ChangePage(MainWindow.AppPages.MainCompanyEdit);
            }
            if (Currentdata.Costumerorder.Tür != "ŞİRKETLER" && Currentdata.Costumerorder.Tür != "ÖZEL MÜŞLERİLER"  && Currentdata.Costumerorder.Savetype == 0)
            {
                MainWindow.ChangePage(MainWindow.AppPages.MainCompanyEdit);
            }
            if (Currentdata.Costumerorder.Satışyöntemi != "GELIR"  && Currentdata.Costumerorder.Savetype == 1)
            {
                MainWindow.ChangePage(MainWindow.AppPages.MainSalesEdit);
            }
            if (Currentdata.Costumerorder.Satışyöntemi != "GIDER" && Currentdata.Costumerorder.Savetype == 1)
            {
                MainWindow.ChangePage(MainWindow.AppPages.MainPurchaseEdit);
            }
        }

        public void Save()
        {
            try
            {
                if (!DataValidation(currentdata))
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Data Validation Hatası", "");
                }
                else
                {
                    bool isok = dataacces.DoPost(Currentdata, controller, Add);
                    if (isok)
                    {
                        uploadfiles(true);
                        MainWindow.ChangePage(MainWindow.AppPages.MainGrid);
                        LoadData();
                        LogVM.displaypopup("INFO", "Kayıt Tamamlandı");
                        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Firma Kaydetme Tamamlandı", "");
                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Kaydetme Başarısız");
                    }
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
                bool isok = dataacces.DoPost(Currentdata, controller, UpdateMain);
                if (isok)
                {
                    uploadfiles(false);
                    LoadData();
                    MainWindow.ChangePage(MainWindow.AppPages.MainGrid);
                    LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
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
            MainWindow.ChangePage(MainWindow.AppPages.MainGrid);
        }

        private void filljobordercount()
        {
            Jobordercount = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                Jobordercount.Add(i);
            }
        }
       
        public string filljoborder()
        {
            string joborder = string.Empty;
            joborder = dataacces.DoGet(joborder, controller, GetJobOrder);
            return joborder;
        }
            
        public List<JobOrderModel> Getorderlist(int Id)
        {
            List<JobOrderModel> list = new List<JobOrderModel>();
            return dataacces.DoGet(list, controller, Getselectedjoborders, "Id", Id.ToString());
        }
        
        private void Clear()
        {
            Preparenewsave();
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

        public void Loadsources()
        {
            try
            {
                List<string> companies = new List<string>();
                List<string> costumers = new List<string>();
                helperclass model = new helperclass();
                model = dataacces.DoGet(model, controller, Getsource);
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

        public void LoadData()
        {
            try
            {                
                List<OrderModel> mainlist = new List<OrderModel>();
                Alllist = dataacces.DoGet(mainlist, controller, GetMainAll);
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
            int filemainid = 0;
            filemainid = dataacces.DoGet(filemainid, controller, Getnewmainid);
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
            list = dataacces.DoGet(list, controller, Getselectedfilelist, "id", id.ToString());
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

        private void DeleteSubItem(object sender)
        {
            int tag = (int)sender;
            JobOrderModel model = Currentdata.Joborder.Find(u => u.Id == tag);
            if (model.Üstid == 0)
            {
                Currentdata.Joborder.Remove(model);
                filljoborders(false);
                getmainprice();
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kayıtlı Sipariş Değiştirilemez");
            }
        }

        private void Addsubitem()
        {
            filljoborders(true);
        }

        public void fillstok(string name)
        {
            try
            {
                Currentstok = dataacces.DoGet(Currentstok, controller, Getselectedstok, "name", name);
            }
            catch (Exception)
            {
            }

        }

        public void Getselectedcompany()
        {
            string Companyname = Currentdata.Costumerorder.Firmaadı;
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

        public void Getselectedcostumer()
        {
            string Costumername = Currentdata.Costumerorder.İsim;
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

        public void AmountCalc()
        {
            foreach (var item in Currentdata.Joborder)
            {
                string kelime = Currentdata.Joborder.Find(u => u.Id == item.Id).Kelimesayı.ToString();
                string satır = Currentdata.Joborder.Find(u => u.Id == item.Id).Satırsayı.ToString();
                string karakter = Currentdata.Joborder.Find(u => u.Id == item.Id).Karaktersayı.ToString();
                int value;
                int value1;
                int vlaue2;
                if (int.TryParse(kelime, out value) && int.TryParse(satır, out value1) && int.TryParse(karakter, out vlaue2))
                {
                    Currentstok = stokVM.Stoklist.Find(u => u.Stokadı == Currentdata.Joborder.Find(i => i.Id == item.Id).Ürün);

                    double kelimesayfa, satırsayfa, karaktersayfa;
                    kelimesayfa = Convert.ToDouble(kelime) / 180;
                    satırsayfa = Convert.ToDouble(satır) / 20;
                    karaktersayfa = Convert.ToDouble(karakter) / 1000;

                    if (kelimesayfa > satırsayfa && kelimesayfa > karaktersayfa)
                    {
                        //kelime out
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplanantutar = Math.Ceiling(kelimesayfa) * Currentstok.Satışfiyat;
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplananadet = (int)Math.Ceiling(kelimesayfa);
                    }
                    else if (satırsayfa > kelimesayfa && satırsayfa > karaktersayfa)
                    {
                        //satır out
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplanantutar = Math.Ceiling(satırsayfa) * Currentstok.Satışfiyat;
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplananadet = (int)Math.Ceiling(satırsayfa);
                    }
                    else if (karaktersayfa > kelimesayfa && karaktersayfa > satırsayfa)
                    {
                        //karakter out
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplanantutar = Math.Ceiling(karaktersayfa) * Currentstok.Satışfiyat;
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplananadet = (int)Math.Ceiling(karaktersayfa);
                    }
                    else
                    {
                        //satır out
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplanantutar = 0;
                        Currentdata.Joborder.Find(u => u.Id == item.Id).Hesaplananadet = 0;
                    }
                }
            }
        }
        private void getmainprice()
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

        public void AmountChanged()
        {
            foreach (var subitem in Currentdata.Joborder)
            {
                Currentstok = stokVM.Stoklist.Find(u => u.Stokadı == Currentdata.Joborder.Find(i => i.Id == subitem.Id).Ürün);
                Currentdata.Joborder.Find(u => u.Id == subitem.Id).Ücret = Currentdata.Costumerorder.Tür!="ÖZEL MÜŞTERİLER" && Currentdata.Costumerorder.Tür=="ŞİRKETLER" && Currentdata.Costumerorder.Savetype == 0
                    ? 122 * Convert.ToDouble(subitem.Miktar)
                    : Currentstok.Satışfiyat * Convert.ToDouble(subitem.Miktar);
            }
        }

        public void  Statechanged()
        {
            foreach (var item in Currentdata.Joborder)
            {
                if (item.Durum != "TAMAMLANDI")
                {
                    if (Currentdata.Costumerorder.Durum == "TAMAMLANDI")
                    {
                        LogVM.displaypopup("ERROR", "AÇIK SİPARİŞ VAR");
                        Currentdata.Costumerorder.Durum = "YAPILIYOR";
                    }
                }
               
            }
        }

        private void Subpricechanged()
        {
            getmainprice();
            if (MainWindow.ActivePage == MainWindow.AppPages.MainPurchaseEdit || MainWindow.ActivePage == MainWindow.AppPages.MainSalesEdit)
            {
                Currentdata.Costumerorder.Ücret = Currentdata.Costumerorder.Beklenentutar;
            }
           
        }

        private void Deletesubfile(object sender)
        {
            var item = sender as LocalfileModel;
            changelocalfilelist(item.Id);
        }

        #endregion

        #endregion

    }
    public class helperclass
    {
        public List<string> Ödemeyöntem { get; set; }
        public List<string> Method { get; set; }
        public List<string> Durum { get; set; }
        public List<string> Birim { get; set; }
        public List<string> Kdv { get; set; }
        public List<string> Ürün { get; set; }
        public List<string> Salesman { get; set; }
        public List<string> tür { get; set; }
        public List<string> türdetay { get; set; }
        public List<string> mainürün { get; set; }
        public List<CompanyModel> company { get; set; }
        public List<CostumerModel> costumer { get; set; }
    }

}
