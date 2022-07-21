using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StarNote.ViewModel;
using StarNote.Service;
using StarNote.Utils;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Services;
using DevExpress.Xpf.Editors.Validation.Native;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;
using StarNote.Model;
using StarNote.Settings;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Utils;
using System.IO;
using DevExpress.Xpf.Bars;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for MainUC.xaml
    /// </summary>
    /// 
   
    public partial class MainGridUC : UserControl 
    {
        MainVM ViewModel;
        private string ürün = "";     
        private bool userControlHasFocus;
        private int pagestatus = 0;
        private bool isshowed = false;
        private bool cancalc = true;
        public MainGridUC()
        {
            
            InitializeComponent();
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            this.Language = XmlLanguage.GetLanguage("tr-TR");
            cd.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
            ViewModel = new MainVM();
            this.DataContext = ViewModel;         
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);           
            sourcetransform();
            restoreviews();
        }
        
        #region UI Control 
        
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!RefreshViews.appstatus)
            {
                try
                {
                    DXSplashScreen.Close();
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- PROGRAM AÇILIDI  ----", "");
                   
                }
                catch (Exception)
                {
                    
                }

                RefreshViews.appstatus = true;
           }

        }
        
        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!isshowed)
            {
                LogVM.displaypopup("INFO", "Star Note Veri Takip Uygulaması Versiyon 2.0");
                isshowed = true;
            }
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;

                if (RefreshViews.screenchanged)
                {
                    Render();
                    RefreshViews.screenchanged = false;
                }

            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
                var parent = (focused_element as FrameworkElement).TryFindParent<MainGridUC>();
                if (parent != this) userControlHasFocus = false;
            }
            catch (Exception)
            {

             
            }
           
        }
        
        private void restoreviews()
        {
            FileInfo fi = new FileInfo("C:\\StarNote\\Templates\\grddava.xml");
            if (fi.Exists)
            {
                grdmain.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grddava.xml");
            }
            fi = new FileInfo("C:\\StarNote\\Templates\\grdözel.xml");
            if (fi.Exists)
            {
                grdmain1.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grdözel.xml");
            }
            fi = new FileInfo("C:\\StarNote\\Templates\\grdfirma.xml");
            if (fi.Exists)
            {
                grdmain2.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grdfirma.xml");
            }

        }

        private void sourcetransform()
        {
            Ürün2sourcelist = ViewModel.Ürün2sourcelist;
            Ürünsourcelist = ViewModel.Ürünsourcelist;
            Durumsourcelist = ViewModel.Durumsourcelist;
            Birimsourcelist = ViewModel.Birimsourcelist;
        }

        #endregion

        #region save and update button olayları      

        private async Task Render()
        {
            try
            {
                bool isok = false;
                if (!DXSplashScreen.IsActive)
                    DXSplashScreen.Show<LoadingSplashScreen>();
                await Task.Run(async () =>
                {
                    if (RefreshViews.pagecount == 1)    // Genel takip ekranı
                    {
                        //tabcontrol.SelectedItem = grid;
                        ViewModel.LoadData(1000);
                    }
                    else
                    {
                        try
                        {
                            //ViewModel.Currentdata = new OrderModel();
                            ViewModel.Currentdata.Costumerorder = new CostumerOrderModel();
                            ViewModel.Currentdata.Joborder = new List<JobOrderModel>();
                        }
                        catch (Exception)
                        {

                        }
                        ViewModel.Localfilelist = new List<LocalfileModel>();
                        ViewModel.Localfile = new LocalfileModel();
                        ViewModel.Loadsources();
                        sourcetransform();
                        ViewModel.Currentdata.Costumerorder.Kayıttarihi = DateTime.Now.ToString();
                        ViewModel.Currentdata.Costumerorder.Randevutarihi = DateTime.Now.AddMinutes(1).ToString();
                        ViewModel.Currentdata.Costumerorder.Durum = "YAPILIYOR";
                        ViewModel.Currentdata.Costumerorder.Satıselemanı = "MUSTAFA ŞAN";
                        ViewModel.Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                        ViewModel.Currentdata.Costumerorder.Kdv = "%40";
                    }
                    isok = true;
                });
                if (isok)
                {
                    if (RefreshViews.pagecount == 1)
                        tabcontrol.SelectedItem = grid;
                    if (RefreshViews.pagecount == 2)   // Özel Müşteri Ekleme Ekranı
                    {
                        filljoborders(true);
                        pagestatus = 1;
                        özelscrollbar.ScrollToVerticalOffset(0);                        
                        özelbtnguncelle.Visibility = Visibility.Hidden;
                        özelbtnkayıt.Visibility = Visibility.Visible;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                        ViewModel.Currentdata.Costumerorder.Tür = "ÖZEL MÜŞTERİLER";
                        ViewModel.Currentdata.Costumerorder.Firmaadı = "ŞAHIS";
                        tabcontrol.SelectedItem = addözel;
                    }
                    if (RefreshViews.pagecount == 26)    // Şirket Ekleme Ekranı
                    {
                        filljoborders(true);
                        firmascrollbar.ScrollToVerticalOffset(0);
                        pagestatus = 2;                        
                        firmabtnguncelle.Visibility = Visibility.Hidden;
                        firmabtnkayıt.Visibility = Visibility.Visible;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                        ViewModel.Currentdata.Costumerorder.Tür = "ŞİRKETLER";
                        ViewModel.Currentdata.Costumerorder.Firmaadı = "ŞAHIS";
                        tabcontrol.SelectedItem = addfirma;
                    }
                    if (RefreshViews.pagecount == 27)
                    {
                        filljoborders(true);
                        davascrollbar.ScrollToVerticalOffset(0);
                        pagestatus = 0;                        
                        btnguncelle.Visibility = Visibility.Hidden;
                        btnkayıt.Visibility = Visibility.Visible;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                        ViewModel.Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                        tabcontrol.SelectedItem = adddava;
                    }
                    if (RefreshViews.pagecount == 29)
                    {
                        filljoborders(true);
                        pagestatus = 3;                        
                        harcamabtnguncelle.Visibility = Visibility.Hidden;
                        harcamabtnkayıt.Visibility = Visibility.Visible;
                        ViewModel.Currentdata.Costumerorder.Durum = "TAMAMLANDI";
                        ViewModel.Currentdata.Costumerorder.Kullanıcı = UserUtils.ActiveUser;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GIDER";
                        //ViewModel.Currentdata.Costumerorder.Kayıttarihi = DateTime.Now.ToString();                   
                        ViewModel.Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                        ViewModel.Currentdata.Costumerorder.Savetype = 1;
                        tabcontrol.SelectedItem = addharcama;
                    }
                    if (RefreshViews.pagecount == 30)
                    {
                        filljoborders(true);
                        pagestatus = 4;
                        othersbtnguncelle.Visibility = Visibility.Hidden;
                        othersbtnkayıt.Visibility = Visibility.Visible;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                        ViewModel.Currentdata.Costumerorder.Durum = "TAMAMLANDI";
                        ViewModel.Currentdata.Costumerorder.Kullanıcı = UserUtils.ActiveUser;
                        ViewModel.Currentdata.Costumerorder.Satışyöntemi = "GELIR";
                        //ViewModel.Currentdata.Costumerorder.Kayıttarihi = DateTime.Now.ToString();                   
                        ViewModel.Currentdata.Costumerorder.Ödemeyöntemi = "NAKIT";
                        ViewModel.Currentdata.Costumerorder.Savetype = 1;
                        tabcontrol.SelectedItem = addharcama;
                    }
                    if (DXSplashScreen.IsActive)
                        DXSplashScreen.Close();
                }
            }
            catch (Exception ex)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
         
        }

        private async Task Save()
        {
            try
            {
                bool issaved = false;
                bool isok = false;
                DXSplashScreen.Show<LoadingSplashScreen>();
                await Task.Run(async () =>
                {
                    if (ViewModel.Save())
                    {
                        //MessageBox.Show("Kaydetme Tamamlandı", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);
                        issaved = true;
                        LogVM.displaypopup("INFO", "Kaydetme Tamamlandı");

                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Kaydetme Başarısız");
                    }
                    isok = true;
                });

                if (isok)
                {
                    if (issaved)
                        tabcontrol.SelectedItem = grid;
                    DXSplashScreen.Close();
                }
            }
            catch (Exception)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }
        }

        private async Task Update()
        {
            try
            {
                bool issaved = false;
                bool isok = false;
                DXSplashScreen.Show<LoadingSplashScreen>();
                await Task.Run(async () =>
                {
                    if (ViewModel.Update())
                    {
                        issaved = true;
                        LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Güncelleme Başarısız");
                    }
                    isok = true;

                });

                if (isok)
                {
                    if (issaved)
                        tabcontrol.SelectedItem = grid;
                    DXSplashScreen.Close();
                }
            }
            catch (Exception ex)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }

        }

        private async Task Goback()
        {
            try
            {
                DXSplashScreen.Show<LoadingSplashScreen>();
                bool isok = false;
                await Task.Run(async () =>
                {
                    ViewModel.LoadData(1000);
                    isok = true;
                });
                if (isok)
                {
                    tabcontrol.SelectedItem = grid;
                    if (DXSplashScreen.IsActive)
                        DXSplashScreen.Close();
                }
            }
            catch (Exception ex)
            {

                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }

        }

        private async Task GetUpdateRecord(string tag)
        {
            try
            {
                bool isok = false;
                DXSplashScreen.Show<LoadingSplashScreen>();
                await Task.Run(async () =>
                {
                    ViewModel.Currentdata.Costumerorder = new CostumerOrderModel();
                    ViewModel.Currentdata.Joborder = new List<JobOrderModel>();
                    filljoborders(true);
                    ViewModel.Localfilelist = new List<LocalfileModel>();
                    ViewModel.Localfile = new LocalfileModel();
                    ViewModel.Loadsources();
                    sourcetransform();
                    isok = true;
                });

                if (isok)
                {
                    fillcurrentdata(tag.ToString());
                    btnguncelle.Visibility = Visibility.Visible;
                    btnkayıt.Visibility = Visibility.Hidden;
                    özelbtnguncelle.Visibility = Visibility.Visible;
                    özelbtnkayıt.Visibility = Visibility.Hidden;
                    firmabtnguncelle.Visibility = Visibility.Visible;
                    firmabtnkayıt.Visibility = Visibility.Hidden;
                    harcamabtnguncelle.Visibility = Visibility.Visible;
                    harcamabtnkayıt.Visibility = Visibility.Hidden;
                    othersbtnguncelle.Visibility = Visibility.Visible;
                    othersbtnkayıt.Visibility = Visibility.Hidden;
                    if (tag == "0")
                    {
                        davascrollbar.ScrollToVerticalOffset(0);
                        tabcontrol.SelectedItem = adddava;
                    }
                    else if (tag == "1")
                    {
                        özelscrollbar.ScrollToVerticalOffset(0);
                        tabcontrol.SelectedItem = addözel;
                    }
                    else if (tag == "2")
                    {
                        firmascrollbar.ScrollToVerticalOffset(0);
                        tabcontrol.SelectedItem = addfirma;
                    }
                    else if (tag == "3")
                    {
                        tabcontrol.SelectedItem = addharcama;
                    }
                    else if (tag == "4")
                    {
                        tabcontrol.SelectedItem = addothers;
                    }
                    filljoborders(false);
                    ViewModel.getselectedfilelist(ViewModel.Currentdata.Costumerorder.Id);
                    if (DXSplashScreen.IsActive)
                        DXSplashScreen.Close();
                }
            }
            catch (Exception ex)
            {
                if (DXSplashScreen.IsActive)
                    DXSplashScreen.Close();
            }

        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Yeni_Kayıt_Ekleme))
            {
                if (ViewModel.Currentdata.Costumerorder.Randevutarihi != string.Empty && ViewModel.Currentdata.Costumerorder.Kayıttarihi != string.Empty)
                {
                    if (true)
                    {
                        if (Convert.ToDateTime(ViewModel.Currentdata.Costumerorder.Kayıttarihi) < Convert.ToDateTime(ViewModel.Currentdata.Costumerorder.Randevutarihi))
                        {
                            Save();
                        }
                        else
                        {
                            LogVM.displaypopup("ERROR", "Randevu tarihi Kayıt tarihinden önce olamaz");                            
                        }
                    }

                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");               
            }

        }

        private void Btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kayıt_Düzenleme))
            {
                if (ViewModel.Currentdata.Costumerorder.Randevutarihi != string.Empty && ViewModel.Currentdata.Costumerorder.Kayıttarihi != string.Empty)
                {
                    if (Convert.ToDateTime(ViewModel.Currentdata.Costumerorder.Kayıttarihi) < Convert.ToDateTime(ViewModel.Currentdata.Costumerorder.Randevutarihi))
                    {
                        Update();
                    }
                    else
                    {
                        LogVM.displaypopup("ERROR", "Randevu tarihi Kayıt tarihinden önce olamaz");                        
                    }
                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");                
            }

        }

        private void Bntvazgec_Click(object sender, RoutedEventArgs e)
        {
            Goback();
        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
           
            //ViewModel.Currentdata = new OrderModel();
            TableView tableView = sender as TableView;
            if (UserUtils.Authority.Contains(UserUtils.Kayıt_Düzenleme))
            {
                GetUpdateRecord(tableView.Tag.ToString());
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            }
        }
        
        private void fillcurrentdata(string tag)
        {
            try
            {
                GridControl grd = new GridControl();
                if (tag == "0")
                {
                    grd = grdmain;
                }
                else if (tag == "1")
                {
                    grd = grdmain1;
                }
                else if (tag == "2")
                {
                    grd = grdmain2;
                }
                else if (tag == "3")
                {
                    grd = grdmain3;
                }
                else if (tag == "4")
                {
                    grd = grdmain4;
                }
                ViewModel.fillcurrentdata(Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1")));
                //fillfilelist(Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1")));
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main update veri alma hatası", ex.Message);
            }
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image btn = sender as Image;
            if (btn.Tag != null)
            {
                JobOrderModel model = ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)btn.Tag);
                if (model.Üstid == 0)
                {
                    ViewModel.Currentdata.Joborder.Remove(model);
                    filljoborders(false);
                    ViewModel.getmainprice();
                }
                else
                {
                    LogVM.displaypopup("ERROR", "Kayıtlı Sipariş Değiştirilemez");
                }
            }
        }

        private void filljoborders(bool createnew)
        {
            try
            {
                cancalc = false;
                int newid = 1;
                if (ViewModel.Currentdata.Joborder.Count != 0)
                    newid = ViewModel.Currentdata.Joborder.Max(u => u.Id);
                if (createnew)
                {
                    if (RefreshViews.pagecount != 29 && RefreshViews.pagecount!=30)
                        ViewModel.Currentdata.Joborder.Add(new JobOrderModel()
                        {
                            Id = newid + 1,
                            Ücret = 0.0,
                            Birim = "SAYFA",
                            Durum = "YAPILIYOR",
                            Ürün2 = "TÜRKÇE",
                            Ürün = "TÜRKÇE"
                        });
                    else
                        ViewModel.Currentdata.Joborder.Add(new JobOrderModel()
                        {
                            Id = newid + 1,
                            Ücret = 0.0,
                            Birim = "",
                            Durum = "YAPILIYOR",
                            Ürün2 = "",
                            Ürün = ""
                        });
                }
                subitems.Height = subitems1.Height = subitems2.Height = subitems3.Height =subitems4.Height= new GridLength(100);
                for (int i = 0; i < ViewModel.Currentdata.Joborder.Count; i++)
                {
                    GridLength newlen = new GridLength(53);
                    subitems.Height = new GridLength(subitems.Height.Value + newlen.Value);
                    subitems1.Height = new GridLength(subitems1.Height.Value + newlen.Value);
                    subitems2.Height = new GridLength(subitems2.Height.Value + newlen.Value);
                    subitems3.Height = new GridLength(subitems3.Height.Value + newlen.Value);
                    subitems4.Height = new GridLength(subitems4.Height.Value + newlen.Value);
                }
                for (int i = 0; i < ViewModel.Currentdata.Joborder.Count; i++)
                {
                    ViewModel.Currentdata.Joborder[i].Lowerid = i + 1;
                }
                davaIC.ItemsSource = özelIC.ItemsSource = firmaIC.ItemsSource = harcamaIC.ItemsSource = OthersIC.ItemsSource = null;
                davaIC.ItemsSource = özelIC.ItemsSource = firmaIC.ItemsSource = harcamaIC.ItemsSource = OthersIC.ItemsSource =ViewModel.Currentdata.Joborder;
                cancalc = true;
            }
            catch (Exception ex)
            {
                cancalc = true;
            }
        }

        private void Addsubitem_Click(object sender, RoutedEventArgs e)
        {
            filljoborders(true);
        }

        #endregion

        #region raporlama seçenecekleri

        private void Btnbildiriücret_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                
                DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
                fillcurrentdata(barButton.Tag.ToString());
                if (ViewModel.Createfile(ViewModel.Currentdata, 1))
                {
                    tabcontrol.SelectedItem = grid;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
                    //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
                }
                else
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
                    LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
                    MessageBox.Show("Dosya Yükleme Başarısız", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");                
            }
        }

        private void Btntercümerapor_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
                fillcurrentdata(barButton.Tag.ToString());
                if (ViewModel.Createfile(ViewModel.Currentdata, 0))
                {
                    tabcontrol.SelectedItem = grid;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
                    //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
                }
                else
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
                    LogVM.displaypopup("ERROR", "Dosya Yükleme Başarısız");                    
                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            }
        }

        private void Btndosyasec_Click(object sender, RoutedEventArgs e)
        {           
            string oSelectedFile = "";
            System.Windows.Forms.OpenFileDialog oDlg = new System.Windows.Forms.OpenFileDialog();
            if (System.Windows.Forms.DialogResult.OK == oDlg.ShowDialog())
            {
                oSelectedFile = oDlg.FileName;
                string[] forname = oSelectedFile.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);                           
                LocalfileModel localfile = new LocalfileModel()
                {
                    Id = ViewModel.Localfilelist.Count + 1,
                    Dosya = oDlg.FileName,
                    Klasöradı = ViewModel.Klasöradıtxt,
                    Durum = FileUtils.hazır,
                    Mainid = 0
                };
                ViewModel.Localfilelist.Add(localfile);
                grdlocalfile.RefreshData();
                özelgrdlocalfile.RefreshData();
                firmagrdlocalfile.RefreshData();
            }
        }
        
        private void Grdlocalfile_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    LocalfileModel localfile = new LocalfileModel()
                    {
                        Id = ViewModel.Localfilelist.Count + 1,
                        Dosya = file,                        
                        Durum = FileUtils.hazır,
                        Klasöradı= ViewModel.Klasöradıtxt,
                        Mainid = 0
                    };
                    ViewModel.Localfilelist.Add(localfile);
                    LogVM.displaypopup("INFO", "Dosya Eklendi");
                    grdlocalfile.RefreshData();
                    özelgrdlocalfile.RefreshData();
                    firmagrdlocalfile.RefreshData();

                }                
            }           
        }

        private void Tableeski_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            TableView tableView = sender as TableView;
            GridControl grd = new GridControl();
                    
            if (tableView.Tag.ToString()=="0")
            {
                grd = grdlocalfile;
            }
            if (tableView.Tag.ToString() == "1")
            {
                grd = özelgrdlocalfile;
            }
            if (tableView.Tag.ToString() == "2")
            {
                grd = firmagrdlocalfile;
            }          
            try
            {
                int ID = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1"));
                ViewModel.changelocalfilelist(ID);
                grdlocalfile.RefreshData();
                özelgrdlocalfile.RefreshData();
                firmagrdlocalfile.RefreshData();
            }
            catch (Exception ex)
            {

              
            }
           
        }
        
        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            string tag = btn.Tag.ToString();
            if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                if (tag == "0")
                {
                    PrintUtils.Print(printingRoute.Adliye, "Adliye Kayıtları", PrintUtils.PDF, grdmain);
                }
                else if (tag == "1")
                {
                    PrintUtils.Print(printingRoute.Özel, "Özel Müşteri Kayıtları", PrintUtils.PDF, grdmain1);
                }
                else if (tag == "2")
                {
                    PrintUtils.Print(printingRoute.Firma, "Firma Kayıtları", PrintUtils.PDF, grdmain2);
                }
                else if (tag == "3")
                {
                    PrintUtils.Print(printingRoute.Harcama, "Harcama Kayıtları", PrintUtils.PDF, grdmain3);
                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            }

        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            string tag = btn.Tag.ToString();
            if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                if (tag=="0")
                {
                    PrintUtils.Print(printingRoute.Adliye, "Adliye Kayıtları", PrintUtils.Excel, grdmain);
                }
                else if (tag=="1")
                {
                    PrintUtils.Print(printingRoute.Özel, "Özel Müşteri Kayıtları", PrintUtils.Excel, grdmain1);
                }
                else if (tag == "2")
                {
                    PrintUtils.Print(printingRoute.Firma, "Firma Kayıtları", PrintUtils.Excel, grdmain2);
                }
                else if (tag == "3")
                {
                    PrintUtils.Print(printingRoute.Harcama, "Harcama Kayıtları", PrintUtils.Excel, grdmain3);
                }
            }
            else
            {
                LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            }

        }

        #endregion

        #region Utils

        private void Özelfirmasecim_SelectionChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            DXTabControl item = sender as DXTabControl;
            pagestatus = Convert.ToInt16(item.SelectedIndex);
        }

        private bool savetemplate(string templatename)
        {
            bool isok = false;
            try
            {
              
                if (templatename=="0")
                {
                    foreach (GridColumn column in grdmain.Columns)
                        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                    grdmain.SaveLayoutToXml("C:\\StarNote\\Templates\\grddava.xml");
                }
                else if (templatename == "1")
                {
                    foreach (GridColumn column in grdmain1.Columns)
                        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                    grdmain1.SaveLayoutToXml("C:\\StarNote\\Templates\\grdözel.xml");
                }
                else if (templatename == "2")
                {
                    foreach (GridColumn column in grdmain2.Columns)
                        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                    grdmain2.SaveLayoutToXml("C:\\StarNote\\Templates\\grdfirma.xml");
                }
               
                LogVM.displaypopup("INFO", "Ayarlar Kayıt Edildi");
            }
            catch (Exception ex)
            {
                LogVM.displaypopup("ERROR", "Hatalı Kayıt");

            }
            return isok;
        }

        private void column_AllowProperty(object sender, AllowPropertyEventArgs e)
        {
            e.Allow = e.DependencyProperty == GridColumn.ActualWidthProperty ||
                      e.DependencyProperty == GridColumn.FieldNameProperty ||
                      e.DependencyProperty == GridColumn.VisibleProperty ||
                      e.DependencyProperty == GridColumn.AllowBestFitProperty ||
                      e.DependencyProperty == GridColumn.VisibleIndexProperty ||
                      e.DependencyProperty == GridColumn.ActualAdditionalRowDataWidthProperty ||
                      e.DependencyProperty == GridColumn.AllowGroupingProperty ||
                      e.DependencyProperty == GridColumn.FixedWidthProperty ||
                      e.DependencyProperty == GridColumn.IsSmartProperty ||
                      e.DependencyProperty == GridColumnBase.HeaderProperty||
                      e.DependencyProperty == GridColumn.BindingGroupProperty                     
                      ;

        }

        private void Btnlayoutsave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {           
            DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            savetemplate(btn.Tag.ToString());           
        }

        private void Klasorname_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            ComboBoxEdit txt = sender as ComboBoxEdit;
            ViewModel.Klasöradıtxt = txt.Text;
        }

        #endregion

        #region hesaplama

        private void Hesaplama_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            try
            {
                if (cancalc)
                {
                    TextEdit txt = sender as TextEdit;
                    if (txt.Tag != null)
                    {
                        if (txt.NullText=="Kelime Sayısı")                        
                            ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)txt.Tag).Kelimesayı = Convert.ToInt16(e.NewValue);
                        if (txt.NullText == "Satır Sayısı")
                            ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)txt.Tag).Satırsayı = Convert.ToInt16(e.NewValue);
                        if (txt.NullText == "Karakter Sayısı")
                            ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)txt.Tag).Karaktersayı = Convert.ToInt16(e.NewValue);
                        ViewModel.sayfahesaplama((int)txt.Tag);
                    }
                }
                
            }
            catch (Exception ex)
            {

                LogVM.displaypopup("ERROR", "Hesaplama hatası");
            }

        }

        private void Sayfasayısı_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            try
            {
                if (cancalc)
                {
                    if (e.NewValue == null)
                        return;
                    TextEdit curretval = sender as TextEdit;
                    int output;
                    if (int.TryParse(e.NewValue.ToString(), out output))
                    {
                        ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)curretval.Tag).Miktar = Convert.ToInt16(e.NewValue);
                        if (pagestatus==0)
                        {
                            ViewModel.ürünfiyathesaplama((int)curretval.Tag,true);
                        }
                        else
                        {
                            ViewModel.ürünfiyathesaplama((int)curretval.Tag);
                        }
                        

                    }
                }
               
            }
            catch (Exception ex)
            {


            }
        }

        private void Hedefdilcmb_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            try
            {
                ComboBoxEdit curretval = sender as ComboBoxEdit;
                ViewModel.Currentdata.Joborder.Find(u => u.Id == (int)curretval.Tag).Ürün = e.NewValue.ToString();
                ViewModel.ürünfiyathesaplama((int)curretval.Tag);
                
            }
            catch (Exception ex)
            {

            }
        }

        private void Anasiparişdurum_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            //if (RefreshViews.pagecount == 30 || RefreshViews.pagecount==29)
            //    return;
            //if (e.NewValue == null)
            //    return;
            //try
            //{
            //    if (pagestatus!=3 && pagestatus!=4)
            //    {
            //        if (e.NewValue.ToString() == "TAMAMLANDI")
            //        {
            //            if (!ViewModel.anasiparişdurumuhesaplama())
            //            {
            //                ViewModel.Currentdata.Costumerorder.Durum = e.OldValue.ToString();
            //                LogVM.displaypopup("ERROR", "Sipariş tamamlanamaz, açık alt işler var");
            //            }
            //        }
            //    }
               
            //}
            //catch (Exception ex)
            //{

              
            //}
         
        }

        private void Subprice_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if (cancalc)
            {
                TextEdit txt = sender as TextEdit;
                if (txt.Text!="")
                {
                    ViewModel.getmainprice();
                    if (pagestatus == 3 || pagestatus == 4)
                    {
                        ViewModel.Currentdata.Costumerorder.Ücret = ViewModel.Currentdata.Costumerorder.Beklenentutar;
                    }
                }
               
               
            }
           
        }

        private void Cmbfirma_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxEdit cmb = sender as ComboBoxEdit;
            ViewModel.Getselectedcompany(cmb.Text);
        }

        private void Cmbisimsoyisim_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxEdit cmb = sender as ComboBoxEdit;
            ViewModel.Getselectedcostumer(cmb.Text);
        }

        #endregion

        #region Defines

        private List<string> ürün2sourcelist;
        public List<string> Ürün2sourcelist
        {
            get { return ürün2sourcelist; }
            set { ürün2sourcelist = value; }
        }

        private List<string> ürün2sourcelistall;
        public List<string> Ürün2sourcelistall
        {
            get { return ürün2sourcelistall; }
            set { ürün2sourcelistall = value; }
        }
        
        private List<string> durumsourcelist;
        public List<string> Durumsourcelist
        {
            get { return durumsourcelist; }
            set { durumsourcelist = value; }
        }
        
        private List<string> birimsourcelist;
        public List<string> Birimsourcelist
        {
            get { return birimsourcelist; }
            set { birimsourcelist = value;  }
        }
        
        private List<string> ürünsourcelist;
        public List<string> Ürünsourcelist
        {
            get { return ürünsourcelist; }
            set { ürünsourcelist = value;  }
        }

        #endregion

        private void btnindir_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_İndir))
            {
                BarButtonItem baritem = sender as BarButtonItem;
                GridControl grd = new GridControl();

                if (baritem.Tag.ToString() == "0")
                {
                    grd = grdlocalfile;
                }
                if (baritem.Tag.ToString() == "1")
                {
                    grd = özelgrdlocalfile;
                }
                if (baritem.Tag.ToString() == "2")
                {
                    grd = firmagrdlocalfile;
                }
                try
                {
                    int ID = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1"));
                    var model = ViewModel.Localfilelist.Single(r => r.Id == ID);
                    ViewModel.Downloadfile(model);
                }
                catch (Exception ex)
                {


                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok");
            }
        }

        private void btnadliyerapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.DoAdliyeReport();
        }
    }

}















































































































