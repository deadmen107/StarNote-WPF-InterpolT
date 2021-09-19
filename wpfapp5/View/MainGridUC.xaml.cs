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
        private List<SettingModel> list = new List<SettingModel>();
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
            gridcolumnsettings();
            gridcolumnsettings1();
            gridcolumnsettings2();
            //try
            //{
            //    grdmain.RestoreLayoutFromXml(System.Environment.CurrentDirectory + "\\grdmain1.xml");
            //}
            //catch (Exception ex)
            //{
            //    LogVM.displaypopup("ERROR", ex.Message);
            //}            
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

        private void Btnekle_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!isshowed)
            {
                LogVM.displaypopup("INFO", "Star Note Veri Takip Uygulaması Versiyon 2.0");
                isshowed = true;
            }
            if (userControlHasFocus == true) { e.Handled = true; }
            else { userControlHasFocus = true;

                if (RefreshViews.pagecount==1)    // Genel takip ekranı
                {
                    tabcontrol.SelectedItem = grid;
                    ViewModel.LoadData(1000);                                   
                }
                if (RefreshViews.pagecount == 2)   // Özel Müşteri Ekleme Ekranı
                {
                    tabcontrol.SelectedItem = addözel;
                    özelbtnguncelle.Visibility = Visibility.Hidden;
                    özelbtnkayıt.Visibility = Visibility.Visible;
                    ViewModel.Currentdata = new Model.MainModel();
                    ViewModel.Currentdata.Birim = "SAYFA";
                    ViewModel.Currentdata.Metod = "GELIR";
                    ViewModel.Currentdata.Tür = "ÖZEL MÜŞTERİLER";
                    ViewModel.Currentdata.Birim = "ŞAHIS";
                    ViewModel.Currentdata.Joborder = ViewModel.filljoborder();
                    try
                    {
                        ViewModel.Currentdata.Kayıttarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                        ViewModel.Currentdata.Randevutarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    }
                    catch (Exception)
                    {

                    }                   
                    ViewModel.Localfilelist = new List<LocalfileModel>();
                    ViewModel.Localfile = new LocalfileModel();
                    
                    ViewModel.Loadsources();                  
                }               
                if (RefreshViews.pagecount == 26)    // Şirket Ekleme Ekranı
                {
                    tabcontrol.SelectedItem = addfirma;
                    firmabtnguncelle.Visibility = Visibility.Hidden;
                    firmabtnkayıt.Visibility = Visibility.Visible;
                    ViewModel.Currentdata = new Model.MainModel();
                    ViewModel.Currentdata.Joborder = ViewModel.filljoborder();
                    ViewModel.Currentdata.Birim = "SAYFA";
                    ViewModel.Currentdata.Metod = "GELIR";
                    ViewModel.Currentdata.Tür = "ŞİRKETLER";
                    
                    try
                    {
                        ViewModel.Currentdata.Kayıttarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                        ViewModel.Currentdata.Randevutarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    }
                    catch (Exception)
                    {
                    }
                    ViewModel.Localfilelist = new List<LocalfileModel>();
                    ViewModel.Localfile = new LocalfileModel();
                    
                    ViewModel.Loadsources();
                }
                if (RefreshViews.pagecount == 27)
                {
                    tabcontrol.SelectedItem = adddava;
                    btnguncelle.Visibility = Visibility.Hidden;
                    btnkayıt.Visibility = Visibility.Visible;
                    ViewModel.Currentdata = new Model.MainModel();
                    ViewModel.Currentdata.Birim = "SAYFA";
                    ViewModel.Currentdata.Metod = "GELIR";
                    ViewModel.Currentdata.Ödemeyöntemi = "NAKIT";
                    ViewModel.Currentdata.Ürün2 = "DAVA BELGELERİ";
                    ViewModel.Currentdata.Joborder = " ";

                    try
                    {
                        ViewModel.Currentdata.Kayıttarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                        ViewModel.Currentdata.Randevutarihi = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    }
                    catch (Exception)
                    {                      
                    }
                    ViewModel.Localfilelist = new List<LocalfileModel>();
                    ViewModel.Localfile = new LocalfileModel();
                   
                    ViewModel.Loadsources();
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

        private void Grdmain_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Genel Takip Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.MainGrid;
                    if (printingRoute.MainGrid == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Genel Takip Rapor çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdmain.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.MainGrid + "\\Genel Takip " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Genel Takip Rapor alındı ", "");
                            MessageBox.Show("Dosya Oluşturuldu", "PDF Rapor", MessageBoxButton.OK, MessageBoxImage.Information);
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }

                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Genel Takip Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Geneltakip_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            {
                string RaporAdı = "Genel Takip";
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.MainGrid;
                    if (printingRoute.MainGrid == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine " + RaporAdı + " Raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdmain.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.MainGrid + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
                            MessageBox.Show("Dosya Oluşturuldu", "Excel Rapor", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", RaporAdı + "Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Geneltakip_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        
        private void Bntgeneltakip_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedItem = grid;
        }
        
        private void Bntvazgec_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedItem = grid;
        }

        #endregion

        #region güncelleme yeni kayıt
        
        private List<MainModel> fillselectedrows(string tag)
        {
            List<MainModel> list = new List<MainModel>();
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
            int[] selectedRows = grd.GetSelectedRowHandles();
            foreach (int rowHandle in selectedRows)
            {            
                MainModel model = new MainModel();
                model.Id = Convert.ToInt32(grd.GetCellDisplayText(rowHandle, "1"));
                model.Joborder = grd.GetCellDisplayText(rowHandle, "2");
                model.Tür = grd.GetCellDisplayText(rowHandle, "3");
                model.İsim = grd.GetCellDisplayText(rowHandle, "4");
                model.Kayıttarihi = grd.GetCellDisplayText(rowHandle, "5");
                model.Randevutarihi = grd.GetCellDisplayText(rowHandle, "6");
                model.Satıselemanı = grd.GetCellDisplayText(rowHandle, "7");
                model.Ürün = grd.GetCellDisplayText(rowHandle, "8");
                model.Ürün2 = grd.GetCellDisplayText(rowHandle, "33");
                model.Miktar = Convert.ToInt32(grd.GetCellDisplayText(rowHandle, "9"));
                model.Birim = grd.GetCellDisplayText(rowHandle, "10");
                model.Ücret = Convert.ToDouble(grd.GetCellDisplayText(rowHandle, "11"));
                model.Karaktersayı = Convert.ToInt32(grd.GetCellDisplayText(rowHandle, "12"));
                model.Satırsayı = Convert.ToInt32(grd.GetCellDisplayText(rowHandle, "13"));
                model.Kelimesayı = Convert.ToInt32(grd.GetCellDisplayText(rowHandle, "14"));
                model.Tavsiyeedilentutar = grd.GetCellDisplayText(rowHandle, "15");
                model.Önerilenbirim = grd.GetCellDisplayText(rowHandle, "16");
                model.Önerilentutar = grd.GetCellDisplayText(rowHandle, "17");
                model.Kdvoran = grd.GetCellDisplayText(rowHandle, "18");
                model.Metod = grd.GetCellDisplayText(rowHandle, "19");
                model.Ödemeyöntemi = grd.GetCellDisplayText(rowHandle, "20");
                model.Durum = grd.GetCellDisplayText(rowHandle, "21");
                model.Acıklama = grd.GetCellDisplayText(rowHandle, "22");
                model.Telefon = grd.GetCellDisplayText(rowHandle, "23");
                model.Tckimlik = grd.GetCellDisplayText(rowHandle, "24");
                model.Eposta = grd.GetCellDisplayText(rowHandle, "25");
                model.Şehir = grd.GetCellDisplayText(rowHandle, "26");
                model.İlçe = grd.GetCellDisplayText(rowHandle, "27");
                model.Adres = grd.GetCellDisplayText(rowHandle, "28");
                model.Vergidairesi = grd.GetCellDisplayText(rowHandle, "29");
                model.Vergino = grd.GetCellDisplayText(rowHandle, "30");
                model.Firmaadı = grd.GetCellDisplayText(rowHandle, "31");
                model.Firmaadresi = grd.GetCellDisplayText(rowHandle, "32");
                model.Türdetay = grd.GetCellDisplayText(rowHandle, "34");
                model.Kayıtdetay = grd.GetCellDisplayText(rowHandle, "35");
                model.Ürün2detay = grd.GetCellDisplayText(rowHandle, "36");

                list.Add(model);
            }
            return list;
        }

        private void fillfilelist(int id)
        {
            ViewModel.getselectedfilelist(id);
        }

        private void fillcurrentdata(string tag)
        {
            try
            {
                GridControl grd = new GridControl();
                if (tag=="0")
                {
                    grd = grdmain;
                }
                else if (tag=="1")
                {
                    grd = grdmain1;
                }
                else if (tag == "2")
                {
                    grd = grdmain2;
                }
                ViewModel.Currentdata.Id = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1"));
                ViewModel.Currentdata.Joborder = grd.GetFocusedRowCellDisplayText("2");
                ViewModel.Currentdata.Tür = grd.GetFocusedRowCellDisplayText("3").ToString();
                ViewModel.Currentdata.İsim = grd.GetFocusedRowCellDisplayText("4").ToString();
                ViewModel.Currentdata.Tckimlik = grd.GetFocusedRowCellDisplayText("24");
                ViewModel.Currentdata.Telefon = grd.GetFocusedRowCellDisplayText("23").ToString();
                ViewModel.Currentdata.Eposta = grd.GetFocusedRowCellDisplayText("25").ToString();
                ViewModel.Currentdata.Şehir = grd.GetFocusedRowCellDisplayText("26").ToString();
                ViewModel.Currentdata.İlçe = grd.GetFocusedRowCellDisplayText("27").ToString();
                ViewModel.Currentdata.Adres = grd.GetFocusedRowCellDisplayText("28").ToString();
                ViewModel.Currentdata.Kayıttarihi = grd.GetFocusedRowCellValue("5").ToString();             
                ViewModel.Currentdata.Randevutarihi = grd.GetFocusedRowCellValue("6").ToString();              
                ViewModel.Currentdata.Satıselemanı = grd.GetFocusedRowCellDisplayText("7").ToString();
                ViewModel.Currentdata.Ürün = grd.GetFocusedRowCellDisplayText("8").ToString();
                ViewModel.Currentdata.Ürün2 = grd.GetFocusedRowCellDisplayText("33").ToString();
                ViewModel.Currentdata.Miktar = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("9"));
                ViewModel.Currentdata.Birim = grd.GetFocusedRowCellDisplayText("10").ToString();
                ViewModel.Currentdata.Ücret = Convert.ToDouble(grd.GetFocusedRowCellDisplayText("11"));
                ViewModel.Currentdata.Kdvoran = grd.GetFocusedRowCellDisplayText("18").ToString();
                ViewModel.Currentdata.Vergidairesi = grd.GetFocusedRowCellDisplayText("29").ToString();
                ViewModel.Currentdata.Vergino = grd.GetFocusedRowCellDisplayText("30").ToString();
                ViewModel.Currentdata.Firmaadı = grd.GetFocusedRowCellDisplayText("31").ToString();
                ViewModel.Currentdata.Firmaadresi = grd.GetFocusedRowCellDisplayText("32").ToString();
                ViewModel.Currentdata.Metod = grd.GetFocusedRowCellDisplayText("19").ToString();
                ViewModel.Currentdata.Ödemeyöntemi = grd.GetFocusedRowCellDisplayText("20").ToString();
                ViewModel.Currentdata.Durum = grd.GetFocusedRowCellDisplayText("21").ToString();
                ViewModel.Currentdata.Acıklama = grd.GetFocusedRowCellDisplayText("22").ToString();
                ViewModel.Currentdata.Karaktersayı = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("12").ToString());
                ViewModel.Currentdata.Kelimesayı = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("14").ToString());
                ViewModel.Currentdata.Satırsayı = Convert.ToInt32(grd.GetFocusedRowCellDisplayText("13").ToString());
                ViewModel.Currentdata.Önerilentutar = grd.GetFocusedRowCellDisplayText("17").ToString();
                ViewModel.Currentdata.Önerilenbirim = grd.GetFocusedRowCellDisplayText("16").ToString();
                ViewModel.Currentdata.Tavsiyeedilentutar = grd.GetFocusedRowCellDisplayText("15").ToString();
                ViewModel.Currentdata.Türdetay = grd.GetFocusedRowCellDisplayText("34").ToString();
                ViewModel.Currentdata.Kayıtdetay = grd.GetFocusedRowCellDisplayText("35").ToString();
                fillfilelist(Convert.ToInt32(grd.GetFocusedRowCellDisplayText("1")));
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Main update veri alma hatası", ex.Message);
            }           
        }

        private void Cmbfirma_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (pagestatus==1)
            {
                ViewModel.Getselectedcompany(özelcmbfirma.Text);
            }
            if (pagestatus == 2)
            {
                ViewModel.Getselectedcompany(özelcmbfirma.Text);
            }

        }

        private void Cmbisimsoyisim_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
           
            if (pagestatus == 1)
            {
                ViewModel.Getselectedcostumer(özelcmbisimsoyisim.Text);
            }
            if (pagestatus == 2)
            {
                ViewModel.Getselectedcostumer(firmacmbisimsoyisim.Text);
            }
        }
        
      

        private void calcprice(string value)
        {
            try
            {
                if (pagestatus==0)
                {
                    ViewModel.Currentdata.Önerilentutar = (90 * Convert.ToInt32(value)).ToString();
                }
                else
                {
                    ViewModel.Currentdata.Önerilentutar = (ViewModel.Currentstok.Satışfiyat * Convert.ToInt32(value)).ToString();
                }
                    
                
            }
            catch (Exception ex)
            {
                
            }
        }
        
        private void Cmbürün_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void Özelcmbsalescmbürün2_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            try
            {
                ViewModel.fillstok(e.NewValue.ToString());
                ViewModel.Currentdata.Birim = ViewModel.Currentstok.Birim;
                calcprice(ViewModel.Currentdata.Miktar.ToString());
                ürün = ViewModel.Currentdata.Ürün;
            }
            catch (Exception ex)
            {
            }

        }

        private void Txtmiktar_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            try
            {
                ViewModel.fillstok(ViewModel.Currentdata.Ürün);
                ViewModel.Currentdata.Birim = ViewModel.Currentstok.Birim;
                calcprice(e.NewValue.ToString());
            }
            catch (Exception ex)
            {
            }           
        }

        private void Cmbürün_PopupClosed(object sender, ClosePopupEventArgs e)
        {
            ViewModel.fillstok(ViewModel.Currentdata.Ürün);
            ViewModel.Currentdata.Birim = ViewModel.Currentstok.Birim;
            calcprice(ViewModel.Currentdata.Miktar.ToString());
        }

        private void Txtkelime_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            if (txtkelime.Text.Trim() != string.Empty && txtsayfa.Text.Trim() != string.Empty && txtkarakter.Text.Trim() != string.Empty)
            {
                string kelime = txtkelime.Text;
                string satır = txtsayfa.Text;
                string karakter = txtkarakter.Text;
                int value;
                int value1;
                int vlaue2;
                if (int.TryParse(kelime, out value) && int.TryParse(satır, out value1) && int.TryParse(karakter, out vlaue2))
                {
                    double kelimesayfa, satırsayfa, karaktersayfa;
                    kelimesayfa = Convert.ToDouble(kelime) / 180;
                    satırsayfa = Convert.ToDouble(satır) / 20;
                    karaktersayfa = Convert.ToDouble(karakter) / 1000;

                    if (kelimesayfa > satırsayfa && kelimesayfa > karaktersayfa)
                    {
                        //kelime out
                        ViewModel.Currentdata.Tavsiyeedilentutar = (Math.Ceiling(kelimesayfa) * ViewModel.Currentstok.Satışfiyat).ToString();
                        //ViewModel.Currentdata.Önerilenbirim = "Kelime" + " ("+ Math.Ceiling(kelimesayfa) + " sayfa)";
                        ViewModel.Currentdata.Önerilenbirim = Math.Ceiling(kelimesayfa) + " Sayfa";
                    }
                    else if (satırsayfa > kelimesayfa && satırsayfa > karaktersayfa)
                    {
                        //satır out
                        ViewModel.Currentdata.Tavsiyeedilentutar = (Math.Ceiling(satırsayfa) * ViewModel.Currentstok.Satışfiyat).ToString();
                        //ViewModel.Currentdata.Önerilenbirim = "Satır" + " (" + Math.Ceiling(satırsayfa) + " sayfa)";
                        ViewModel.Currentdata.Önerilenbirim = Math.Ceiling(satırsayfa) + " Sayfa";
                    }
                    else if (karaktersayfa > kelimesayfa && karaktersayfa > satırsayfa)
                    {
                        //karakter out
                        ViewModel.Currentdata.Tavsiyeedilentutar = (Math.Ceiling(karaktersayfa) * ViewModel.Currentstok.Satışfiyat).ToString();
                        //ViewModel.Currentdata.Önerilenbirim = "Karakter" + " (" + Math.Ceiling(karaktersayfa) + " sayfa)";
                        ViewModel.Currentdata.Önerilenbirim = Math.Ceiling(karaktersayfa) + " Sayfa";
                    }
                    else
                    {
                        //satır out
                        ViewModel.Currentdata.Tavsiyeedilentutar = (Math.Ceiling(satırsayfa) * ViewModel.Currentstok.Satışfiyat).ToString();
                        ViewModel.Currentdata.Önerilenbirim = "";
                    }

                }
            }
        }

        #endregion

        #region save and update click eventler 
        
        private bool checkvalues()
        {
            if (pagestatus==0)
            {
                if
               (
                 txttür.Text != null &&
                 cmbisimsoyisim.Text != null &&                
                 cmbürün.Text != null &&
                 txtmiktar.Text != null &&
                 cmbkdv.Text != null &&
                 cmbsales.Text != null &&
                 txtfiyat.Text != null &&              
                 cmbdurum.Text != null
                
               )
                {
                    if
                  (
                    txttür.Text.Trim() != string.Empty &&
                    cmbisimsoyisim.Text.Trim() != string.Empty &&                 
                    cmbürün.Text.Trim() != string.Empty &&
                    txtmiktar.Text.ToString().Trim() != string.Empty &&
                    cmbkdv.Text.Trim() != string.Empty &&
                    cmbsales.Text.Trim() != string.Empty &&
                    txtfiyat.Text.ToString().Trim() != string.Empty &&                   
                    cmbdurum.Text.Trim() != string.Empty
                   
                  )
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

            }
            else if (pagestatus==1)
            {
                if
              (
              
                özelcmbisimsoyisim.Text != null &&
                özelcmbfirma.Text != null &&
                özelcmbsalescmbürün.Text != null &&
                özelcmbsalestxtmiktar.Text != null &&
                özelcmbsalescmbkdv.Text != null &&
                özelcmbsales.Text != null &&
                özelcmbsalestxtfiyat.Text != null &&
                özelcmbfirma.Text != null &&
                özelcmbyöntem.Text != null &&
                özelcmbdurum.Text != null &&
                özeltxttelefon.Text != null
              )
                {
                    if
                  (
                   
                    özelcmbisimsoyisim.Text.Trim() != string.Empty &&
                    özelcmbfirma.Text.Trim() != string.Empty &&
                    özelcmbsalestxtmiktar.Text.Trim() != string.Empty &&
                    özelcmbsalestxtmiktar.Text.ToString().Trim() != string.Empty &&
                    özelcmbsalestxtmiktar.Text.Trim() != string.Empty &&
                    özelcmbsales.Text.Trim() != string.Empty &&
                    özelcmbsalestxtfiyat.Text.ToString().Trim() != string.Empty &&
                    
                    özelcmbyöntem.Text.Trim() != string.Empty &&
                    özelcmbdurum.Text.Trim() != string.Empty &&
                    özeltxttelefon.Text.Trim() != string.Empty
                  )
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else if (pagestatus == 2)
            {
                if
              (
                firmacmbisimsoyisim.Text != null &&
                firmacmbisimsoyisim.Text != null &&
                firmacmbfirma.Text != null &&
                firmacmbürün.Text != null &&
                firmatxtmiktar.Text != null &&
                firmacmbkdv.Text != null &&
                firmacmbsales.Text != null &&
                firmatxtfiyat.Text != null &&                
                firmacmbyöntem.Text != null &&
                firmacmbdurum.Text != null &&
                firmatxttelefon.Text != null
              )
                {
                    if
                  (
                    
                    firmacmbisimsoyisim.Text.Trim() != string.Empty &&
                    firmacmbfirma.Text.Trim() != string.Empty &&
                    firmacmbürün.Text.Trim() != string.Empty &&
                    firmatxtmiktar.Text.ToString().Trim() != string.Empty &&
                    firmacmbkdv.Text.Trim() != string.Empty &&
                    firmacmbsales.Text.Trim() != string.Empty &&
                    firmatxtfiyat.Text.ToString().Trim() != string.Empty &&
                    firmacmbyöntem.Text.Trim() != string.Empty &&
                    firmacmbyöntem.Text.Trim() != string.Empty &&
                    firmacmbdurum.Text.Trim() != string.Empty &&
                    firmatxttelefon.Text.Trim() != string.Empty
                  )
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Gerekli alanları doldurunuz", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return false;
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Yeni_Kayıt_Ekleme))
            {
                if (ViewModel.Currentdata.Randevutarihi != string.Empty && ViewModel.Currentdata.Kayıttarihi != string.Empty)
                {
                    if (checkvalues())
                    {
                        if (Convert.ToDateTime(ViewModel.Currentdata.Kayıttarihi) < Convert.ToDateTime(ViewModel.Currentdata.Randevutarihi))
                        {
                            if (ViewModel.Save())
                            {
                                //MessageBox.Show("Kaydetme Tamamlandı", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);
                                LogVM.displaypopup("INFO", "Kaydetme Tamamlandı");
                                tabcontrol.SelectedItem = grid;
                            }
                            else
                            {
                                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
                            }                          
                        }
                        else
                        {
                            MessageBox.Show("Randevu tarihi Kayıt tarihinden önce olamaz", UserUtils.Yeni_Kayıt_Ekleme, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }                            
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Yeni_Kayıt_Ekleme, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kayıt_Düzenleme))
            {
                if (ViewModel.Currentdata.Randevutarihi != string.Empty && ViewModel.Currentdata.Kayıttarihi != string.Empty)
                {
                    if (checkvalues())
                    {
                        if (Convert.ToDateTime(ViewModel.Currentdata.Kayıttarihi) < Convert.ToDateTime(ViewModel.Currentdata.Randevutarihi))
                        {
                            if (ViewModel.Update())
                            {
                                tabcontrol.SelectedItem = grid;
                                //MessageBox.Show("Güncelleme Tamamlandı", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Information);    
                                LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
                            }
                            else
                            {
                                MessageBox.Show("Güncelleme Başarısız", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Randevu tarihi Kayıt tarihinden önce olamaz", UserUtils.Yeni_Kayıt_Ekleme, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kayıt_Düzenleme, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btngüncelle_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kayıt_Düzenleme))
            {
                DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
                fillcurrentdata(barButton.Tag.ToString());
                btnguncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                //tabcontrol.SelectedItem = add;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kayıt_Düzenleme, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kayıt_Düzenleme))
            {
                TableView tableView = sender as TableView;

                fillcurrentdata(tableView.Tag.ToString());

                btnguncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                özelbtnguncelle.Visibility = Visibility.Visible;
                özelbtnkayıt.Visibility = Visibility.Hidden;
                firmabtnguncelle.Visibility = Visibility.Visible;
                firmabtnkayıt.Visibility = Visibility.Hidden;
                if (tableView.Tag.ToString()=="0")
                {
                    tabcontrol.SelectedItem = adddava;
                }
                else if (tableView.Tag.ToString() == "1")
                {
                    tabcontrol.SelectedItem = addözel;
                }
                else if (tableView.Tag.ToString() == "2")
                {
                    tabcontrol.SelectedItem = addfirma;
                }

            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kayıt_Düzenleme, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        #endregion
        
        #region raporlama seçenecekleri

        private void Btnbildiriücret_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                
                DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
                fillcurrentdata(barButton.Tag.ToString());
                if (ViewModel.Createfile(fillselectedrows(barButton.Tag.ToString()), 1))
                {
                    tabcontrol.SelectedItem = grid;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
                    //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
                }
                else
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
                    MessageBox.Show("Dosya Yükleme Başarısız", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Dosya_Kayıt_Oluşturma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btntercümerapor_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
                fillcurrentdata(barButton.Tag.ToString());
                if (ViewModel.Createfile(fillselectedrows(barButton.Tag.ToString()), 0))
                {
                    tabcontrol.SelectedItem = grid;
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
                    //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
                }
                else
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
                    MessageBox.Show("Dosya Yükleme Başarısız", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Dosya_Kayıt_Oluşturma, MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Btnfaturaçıktı_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {


        }

        #endregion

        #region kolon ayarlama

        private void Btnayar_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (!popup.IsOpen)
            {
                
                gridpopup.Children.Clear();
                gridpopup.RowDefinitions.Clear();
                list = createsettinglist();
                RowDefinition rowDefn = new RowDefinition();
                rowDefn.Height = new GridLength(30);
                int newRow = gridpopup.RowDefinitions.Count;
                gridpopup.RowDefinitions.Add(rowDefn);
                var button = new System.Windows.Controls.Button
                {
                    Content = "Kapat",
                    Width = 80,
                    Height = 25,
                    Background = new SolidColorBrush(Colors.White),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center

                };
                button.Click += new RoutedEventHandler(popupclose);
                Grid.SetRow(button, newRow);
                Grid.SetColumn(button, 1);
                gridpopup.Children.Add(button);
                double count = 0.0;
                int count1 = 0;
                bool fourcolumnopen = false;
                foreach (var objDomain in list)
                {
                    count++;
                    if(!fourcolumnopen)
                    count1++;
                    if (count<= grdmain.Columns.Count/2)
                    {
                        var credentialsUserNameLabel = new System.Windows.Controls.Label
                        {
                            Content = objDomain.Xname,
                            //Foreground = new SolidColorBrush(Colors.Red),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        };
                        var credentialsUserNameTextbox = new DevExpress.Xpf.Editors.ToggleSwitchEdit
                        {
                            Name = objDomain.Name,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            IsChecked = objDomain.Status
                        };
                        credentialsUserNameTextbox.Checked += new RoutedEventHandler(columnvisiblechange);
                        credentialsUserNameTextbox.Unchecked += new RoutedEventHandler(columnvisiblechange);
                        rowDefn = new RowDefinition();
                        rowDefn.Height = new GridLength(30);
                        newRow = gridpopup.RowDefinitions.Count;
                        gridpopup.RowDefinitions.Add(rowDefn);
                        Grid.SetRow(credentialsUserNameLabel, newRow);
                        Grid.SetColumn(credentialsUserNameLabel, 0);
                        Grid.SetRow(credentialsUserNameTextbox, newRow);
                        Grid.SetColumn(credentialsUserNameTextbox, 1);
                        gridpopup.Children.Add(credentialsUserNameLabel);
                        gridpopup.Children.Add(credentialsUserNameTextbox);
                    }
                    else
                    {
                        
                        if (!fourcolumnopen)
                        {
                            fourcolumnopen = true;
                            popupcolumn1.Width = new GridLength(200);
                            popupcolumn2.Width = new GridLength(120);
                        }
                        var credentialsUserNameLabel = new System.Windows.Controls.Label
                        {
                            Content = objDomain.Xname,
                            //Foreground = new SolidColorBrush(Colors.Red),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        };
                        var credentialsUserNameTextbox = new DevExpress.Xpf.Editors.ToggleSwitchEdit
                        {
                            Name = objDomain.Name,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            IsChecked = objDomain.Status
                        };
                        credentialsUserNameTextbox.Checked += new RoutedEventHandler(columnvisiblechange);
                        credentialsUserNameTextbox.Unchecked += new RoutedEventHandler(columnvisiblechange);
                        rowDefn = new RowDefinition();
                        rowDefn.Height = new GridLength(30);
                        newRow = gridpopup.RowDefinitions.Count - count1+1;
                        gridpopup.RowDefinitions.Add(rowDefn);
                        Grid.SetRow(credentialsUserNameLabel, newRow);
                        Grid.SetColumn(credentialsUserNameLabel, 2);
                        Grid.SetRow(credentialsUserNameTextbox, newRow);
                        Grid.SetColumn(credentialsUserNameTextbox, 3);
                        gridpopup.Children.Add(credentialsUserNameLabel);
                        gridpopup.Children.Add(credentialsUserNameTextbox);
                    }
                    
                }
                popup.IsOpen = true;
            }

        }

        private void popupclose(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void columnvisiblechange(object sender, RoutedEventArgs e)
        {
            var s = sender as DevExpress.Xpf.Editors.ToggleSwitchEdit;
            if (pagestatus==0)
            {
                MainGrid settings = new MainGrid();
                if (s.Name.ToString() == kolonId.Name) settings.Id = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonJoborder.Name) settings.Joborder = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKayıtdetay.Name) settings.Kayıtdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKayıtdetay1.Name) settings.Kayıtdetay1 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKayıtdetay2.Name) settings.Kayıtdetay2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonTür.Name) settings.Tür = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonTürdetay.Name) settings.Türdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonİsim.Name) settings.İsim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonTckimlik.Name) settings.Tckimlik = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonTelefon.Name) settings.Telefon = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonEposta.Name) settings.Eposta = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonŞehir.Name) settings.Şehir = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonİlçe.Name) settings.İlçe = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonAdres.Name) settings.Adres = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKayıttarihi.Name) settings.Kayıttarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonRandevutarihi.Name) settings.Randevutarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonSatıselemanı.Name) settings.Satıselemanı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÜrün.Name) settings.Ürün = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÜrün2.Name) settings.Ürün2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonMiktar.Name) settings.Miktar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonBirim.Name) settings.Birim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÜcret.Name) settings.Ücret = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKdvoran.Name) settings.Kdvoran = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonVergidairesi.Name) settings.Vergidairesi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonVergino.Name) settings.Vergino = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonFirmaadı.Name) settings.Firmaadı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonFirmaadresi.Name) settings.Firmaadresi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonMetod.Name) settings.Metod = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÖdemeyöntemi.Name) settings.Ödemeyöntemi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonDurum.Name) settings.Durum = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonAcıklama.Name) settings.Acıklama = (bool)s.IsChecked;
                //if (s.Name.ToString() == kolonKullanıcı.Name) settings.Kullanıcı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonTavsiyeedilentutar.Name) settings.Tavsiyeedilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÖnerilentutar.Name) settings.Önerilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonÖnerilenbirim.Name) settings.Önerilenbirim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKelimesayı.Name) settings.Kelimesayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonSatırsayı.Name) settings.Satırsayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonKaraktersayı.Name) settings.Karaktersayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolonBeklenentutar.Name) settings.Beklenentutar = (bool)s.IsChecked;
                settings.Save();
                gridcolumnsettings();
            }
            else if (pagestatus == 1)
            {
                MainGrid1 settings = new MainGrid1();
                if (s.Name.ToString() == kolon1Id.Name) settings.Id = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Joborder.Name) settings.Joborder = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kayıtdetay.Name) settings.Kayıtdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kayıtdetay1.Name) settings.Kayıtdetay1 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kayıtdetay2.Name) settings.Kayıtdetay2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Tür.Name) settings.Tür = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Türdetay.Name) settings.Türdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1İsim.Name) settings.İsim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Tckimlik.Name) settings.Tckimlik = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Telefon.Name) settings.Telefon = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Eposta.Name) settings.Eposta = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Şehir.Name) settings.Şehir = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1İlçe.Name) settings.İlçe = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Adres.Name) settings.Adres = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kayıttarihi.Name) settings.Kayıttarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Randevutarih.Name) settings.Randevutarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Satıselemanı.Name) settings.Satıselemanı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Ürün.Name) settings.Ürün = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Ürün2.Name) settings.Ürün2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Miktar.Name) settings.Miktar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Birim.Name) settings.Birim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Ücret.Name) settings.Ücret = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kdvoran.Name) settings.Kdvoran = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Vergidairesi.Name) settings.Vergidairesi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Vergino.Name) settings.Vergino = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Firmaadı.Name) settings.Firmaadı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Firmaadresi.Name) settings.Firmaadresi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Metod.Name) settings.Metod = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Ödemeyöntemi.Name) settings.Ödemeyöntemi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Durum.Name) settings.Durum = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Acıklama.Name) settings.Acıklama = (bool)s.IsChecked;
                //if (s.Name.ToString() == kol1onKullanıcı.Name) settings.Kullanıcı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Tavsiyeedilentutar.Name) settings.Tavsiyeedilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Önerilentutar.Name) settings.Önerilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Önerilenbirim.Name) settings.Önerilenbirim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Kelimesayı.Name) settings.Kelimesayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Satırsayı.Name) settings.Satırsayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Karaktersayı.Name) settings.Karaktersayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon1Beklenentutar.Name) settings.Beklenentutar = (bool)s.IsChecked;
                settings.Save();
                gridcolumnsettings1();
            }
            else if (pagestatus == 2)
            {
                MainGrid2 settings = new MainGrid2();
                if (s.Name.ToString() == kolon2Id.Name) settings.Id = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Joborder.Name) settings.Joborder = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kayıtdetay.Name) settings.Kayıtdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kayıtdetay1.Name) settings.Kayıtdetay1 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kayıtdetay2.Name) settings.Kayıtdetay2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Tür.Name) settings.Tür = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Türdetay.Name) settings.Türdetay = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2İsim.Name) settings.İsim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Tckimlik.Name) settings.Tckimlik = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Telefon.Name) settings.Telefon = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Eposta.Name) settings.Eposta = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Şehir.Name) settings.Şehir = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2İlçe.Name) settings.İlçe = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Adres.Name) settings.Adres = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kayıttarihi.Name) settings.Kayıttarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Randevutarih.Name) settings.Randevutarihi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Satıselemanı.Name) settings.Satıselemanı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Ürün.Name) settings.Ürün = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Ürün2.Name) settings.Ürün2 = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Miktar.Name) settings.Miktar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Birim.Name) settings.Birim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Ücret.Name) settings.Ücret = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kdvoran.Name) settings.Kdvoran = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Vergidairesi.Name) settings.Vergidairesi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Vergino.Name) settings.Vergino = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Firmaadı.Name) settings.Firmaadı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Firmaadresi.Name) settings.Firmaadresi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Metod.Name) settings.Metod = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Ödemeyöntemi.Name) settings.Ödemeyöntemi = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Durum.Name) settings.Durum = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Acıklama.Name) settings.Acıklama = (bool)s.IsChecked;
                //if (s.Name.ToString() == kol2onKullanıcı.Name) settings.Kullanıcı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Tavsiyeedilentutar.Name) settings.Tavsiyeedilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Önerilentutar.Name) settings.Önerilentutar = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Önerilenbirim.Name) settings.Önerilenbirim = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Kelimesayı.Name) settings.Kelimesayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Satırsayı.Name) settings.Satırsayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Karaktersayı.Name) settings.Karaktersayı = (bool)s.IsChecked;
                if (s.Name.ToString() == kolon2Beklenentutar.Name) settings.Beklenentutar = (bool)s.IsChecked;
                settings.Save();
                gridcolumnsettings2();
            }
        }

        private List<SettingModel> createsettinglist()
        {
            List<SettingModel> list = new List<SettingModel>();
            if (pagestatus==0)
            {
                MainGrid settings = new MainGrid();
                list.Add(new SettingModel { Xname = kolonId.Header.ToString(), Name = kolonId.Name, Status = settings.Id });
                list.Add(new SettingModel { Xname = kolonJoborder.Header.ToString(), Name = kolonJoborder.Name, Status = settings.Joborder });
                list.Add(new SettingModel { Xname = kolonTür.Header.ToString(), Name = kolonTür.Name, Status = settings.Tür });
                list.Add(new SettingModel { Xname = kolonTürdetay.Header.ToString(), Name = kolonTürdetay.Name, Status = settings.Türdetay });
                list.Add(new SettingModel { Xname = kolonKayıtdetay.Header.ToString(), Name = kolonKayıtdetay.Name, Status = settings.Kayıtdetay });
                list.Add(new SettingModel { Xname = kolonKayıtdetay1.Header.ToString(), Name = kolonKayıtdetay1.Name, Status = settings.Kayıtdetay1 });
                list.Add(new SettingModel { Xname = kolonKayıtdetay2.Header.ToString(), Name = kolonKayıtdetay2.Name, Status = settings.Kayıtdetay2 });
                list.Add(new SettingModel { Xname = kolonİsim.Header.ToString(), Name = kolonİsim.Name, Status = settings.İsim });
                list.Add(new SettingModel { Xname = kolonKayıttarihi.Header.ToString(), Name = kolonKayıttarihi.Name, Status = settings.Kayıttarihi });
                list.Add(new SettingModel { Xname = kolonRandevutarihi.Header.ToString(), Name = kolonRandevutarihi.Name, Status = settings.Randevutarihi });
                list.Add(new SettingModel { Xname = kolonSatıselemanı.Header.ToString(), Name = kolonSatıselemanı.Name, Status = settings.Satıselemanı });
                list.Add(new SettingModel { Xname = kolonÜrün.Header.ToString(), Name = kolonÜrün.Name, Status = settings.Ürün });
                list.Add(new SettingModel { Xname = kolonÜrün2.Header.ToString(), Name = kolonÜrün2.Name, Status = settings.Ürün2 });
                list.Add(new SettingModel { Xname = kolonMiktar.Header.ToString(), Name = kolonMiktar.Name, Status = settings.Miktar });
                list.Add(new SettingModel { Xname = kolonBirim.Header.ToString(), Name = kolonBirim.Name, Status = settings.Birim });
                list.Add(new SettingModel { Xname = kolonÜcret.Header.ToString(), Name = kolonÜcret.Name, Status = settings.Ücret });
                list.Add(new SettingModel { Xname = kolonKaraktersayı.Header.ToString(), Name = kolonKaraktersayı.Name, Status = settings.Karaktersayı });
                list.Add(new SettingModel { Xname = kolonSatırsayı.Header.ToString(), Name = kolonSatırsayı.Name, Status = settings.Satırsayı });
                list.Add(new SettingModel { Xname = kolonKelimesayı.Header.ToString(), Name = kolonKelimesayı.Name, Status = settings.Kelimesayı });
                list.Add(new SettingModel { Xname = kolonTavsiyeedilentutar.Header.ToString(), Name = kolonTavsiyeedilentutar.Name, Status = settings.Tavsiyeedilentutar });
                list.Add(new SettingModel { Xname = kolonÖnerilenbirim.Header.ToString(), Name = kolonÖnerilenbirim.Name, Status = settings.Önerilenbirim });
                list.Add(new SettingModel { Xname = kolonÖnerilentutar.Header.ToString(), Name = kolonÖnerilentutar.Name, Status = settings.Önerilentutar });
                list.Add(new SettingModel { Xname = kolonKdvoran.Header.ToString(), Name = kolonKdvoran.Name, Status = settings.Kdvoran });
                list.Add(new SettingModel { Xname = kolonMetod.Header.ToString(), Name = kolonMetod.Name, Status = settings.Metod });
                list.Add(new SettingModel { Xname = kolonÖdemeyöntemi.Header.ToString(), Name = kolonÖdemeyöntemi.Name, Status = settings.Ödemeyöntemi });
                list.Add(new SettingModel { Xname = kolonDurum.Header.ToString(), Name = kolonDurum.Name, Status = settings.Durum });
                list.Add(new SettingModel { Xname = kolonAcıklama.Header.ToString(), Name = kolonAcıklama.Name, Status = settings.Acıklama });
                list.Add(new SettingModel { Xname = kolonTelefon.Header.ToString(), Name = kolonTelefon.Name, Status = settings.Telefon });
                list.Add(new SettingModel { Xname = kolonTckimlik.Header.ToString(), Name = kolonTckimlik.Name, Status = settings.Tckimlik });
                list.Add(new SettingModel { Xname = kolonEposta.Header.ToString(), Name = kolonEposta.Name, Status = settings.Eposta });
                list.Add(new SettingModel { Xname = kolonŞehir.Header.ToString(), Name = kolonŞehir.Name, Status = settings.Şehir });
                list.Add(new SettingModel { Xname = kolonİlçe.Header.ToString(), Name = kolonİlçe.Name, Status = settings.İlçe });
                list.Add(new SettingModel { Xname = kolonAdres.Header.ToString(), Name = kolonAdres.Name, Status = settings.Adres });
                list.Add(new SettingModel { Xname = kolonVergidairesi.Header.ToString(), Name = kolonVergidairesi.Name, Status = settings.Vergidairesi });
                list.Add(new SettingModel { Xname = kolonVergino.Header.ToString(), Name = kolonVergino.Name, Status = settings.Vergino });
                list.Add(new SettingModel { Xname = kolonFirmaadı.Header.ToString(), Name = kolonFirmaadı.Name, Status = settings.Firmaadı });
                list.Add(new SettingModel { Xname = kolonFirmaadresi.Header.ToString(), Name = kolonFirmaadresi.Name, Status = settings.Firmaadresi });
                list.Add(new SettingModel { Xname = kolonBeklenentutar.Header.ToString(), Name = kolonBeklenentutar.Name, Status = settings.Beklenentutar });
            }
            else if (pagestatus==1)
            {
                MainGrid1 settings = new MainGrid1();
                list.Add(new SettingModel { Xname = kolon1Id.Header.ToString(),                 Name = kolon1Id.Name, Status = settings.Id });
                list.Add(new SettingModel { Xname = kolon1Joborder.Header.ToString(),           Name = kolon1Joborder.Name, Status = settings.Joborder });
                list.Add(new SettingModel { Xname = kolon1Tür.Header.ToString(),                Name = kolon1Tür.Name, Status = settings.Tür });
                list.Add(new SettingModel { Xname = kolon1Türdetay.Header.ToString(),           Name = kolon1Türdetay.Name, Status = settings.Türdetay });
                list.Add(new SettingModel { Xname = kolon1Kayıtdetay.Header.ToString(),         Name = kolon1Kayıtdetay.Name, Status = settings.Kayıtdetay });
                list.Add(new SettingModel { Xname = kolon1Kayıtdetay1.Header.ToString(),        Name = kolon1Kayıtdetay1.Name, Status = settings.Kayıtdetay1 });
                list.Add(new SettingModel { Xname = kolon1Kayıtdetay2.Header.ToString(),        Name = kolon1Kayıtdetay2.Name, Status = settings.Kayıtdetay2 });
                list.Add(new SettingModel { Xname = kolon1İsim.Header.ToString(),               Name = kolon1İsim.Name, Status = settings.İsim });
                list.Add(new SettingModel { Xname = kolon1Kayıttarihi.Header.ToString(),        Name = kolon1Kayıttarihi.Name, Status = settings.Kayıttarihi });
                list.Add(new SettingModel { Xname = kolon1Randevutarih.Header.ToString(),       Name = kolon1Randevutarih.Name, Status = settings.Randevutarihi });
                list.Add(new SettingModel { Xname = kolon1Satıselemanı.Header.ToString(),       Name = kolon1Satıselemanı.Name, Status = settings.Satıselemanı });
                list.Add(new SettingModel { Xname = kolon1Ürün.Header.ToString(),               Name = kolon1Ürün.Name, Status = settings.Ürün });
                list.Add(new SettingModel { Xname = kolon1Ürün2.Header.ToString(),              Name = kolon1Ürün2.Name, Status = settings.Ürün2 });
                list.Add(new SettingModel { Xname = kolon1Miktar.Header.ToString(),             Name = kolon1Miktar.Name, Status = settings.Miktar });
                list.Add(new SettingModel { Xname = kolon1Birim.Header.ToString(),              Name = kolon1Birim.Name, Status = settings.Birim });
                list.Add(new SettingModel { Xname = kolon1Ücret.Header.ToString(),              Name = kolon1Ücret.Name, Status = settings.Ücret });
                list.Add(new SettingModel { Xname = kolon1Karaktersayı.Header.ToString(),       Name = kolon1Karaktersayı.Name, Status = settings.Karaktersayı });
                list.Add(new SettingModel { Xname = kolon1Satırsayı.Header.ToString(),          Name = kolon1Satırsayı.Name, Status = settings.Satırsayı });
                list.Add(new SettingModel { Xname = kolon1Kelimesayı.Header.ToString(),         Name = kolon1Kelimesayı.Name, Status = settings.Kelimesayı });
                list.Add(new SettingModel { Xname = kolon1Tavsiyeedilentutar.Header.ToString(), Name = kolon1Tavsiyeedilentutar.Name, Status = settings.Tavsiyeedilentutar });
                list.Add(new SettingModel { Xname = kolon1Önerilenbirim.Header.ToString(),      Name = kolon1Önerilenbirim.Name, Status = settings.Önerilenbirim });
                list.Add(new SettingModel { Xname = kolon1Önerilentutar.Header.ToString(),      Name = kolon1Önerilentutar.Name, Status = settings.Önerilentutar });
                list.Add(new SettingModel { Xname = kolon1Kdvoran.Header.ToString(),            Name = kolon1Kdvoran.Name, Status = settings.Kdvoran });
                list.Add(new SettingModel { Xname = kolon1Metod.Header.ToString(),              Name = kolon1Metod.Name, Status = settings.Metod });
                list.Add(new SettingModel { Xname = kolon1Ödemeyöntemi.Header.ToString(),       Name = kolon1Ödemeyöntemi.Name, Status = settings.Ödemeyöntemi });
                list.Add(new SettingModel { Xname = kolon1Durum.Header.ToString(),              Name = kolon1Durum.Name, Status = settings.Durum });
                list.Add(new SettingModel { Xname = kolon1Acıklama.Header.ToString(),           Name = kolon1Acıklama.Name, Status = settings.Acıklama });
                list.Add(new SettingModel { Xname = kolon1Telefon.Header.ToString(),            Name = kolon1Telefon.Name, Status = settings.Telefon });
                list.Add(new SettingModel { Xname = kolon1Tckimlik.Header.ToString(),           Name = kolon1Tckimlik.Name, Status = settings.Tckimlik });
                list.Add(new SettingModel { Xname = kolon1Eposta.Header.ToString(),             Name = kolon1Eposta.Name, Status = settings.Eposta });
                list.Add(new SettingModel { Xname = kolon1Şehir.Header.ToString(),              Name = kolon1Şehir.Name, Status = settings.Şehir });
                list.Add(new SettingModel { Xname = kolon1İlçe.Header.ToString(),               Name = kolon1İlçe.Name, Status = settings.İlçe });
                list.Add(new SettingModel { Xname = kolon1Adres.Header.ToString(),              Name = kolon1Adres.Name, Status = settings.Adres });
                list.Add(new SettingModel { Xname = kolon1Vergidairesi.Header.ToString(),       Name = kolon1Vergidairesi.Name, Status = settings.Vergidairesi });
                list.Add(new SettingModel { Xname = kolon1Vergino.Header.ToString(),            Name = kolon1Vergino.Name, Status = settings.Vergino });
                list.Add(new SettingModel { Xname = kolon1Firmaadı.Header.ToString(),           Name = kolon1Firmaadı.Name, Status = settings.Firmaadı });
                list.Add(new SettingModel { Xname = kolon1Firmaadresi.Header.ToString(),        Name = kolon1Firmaadresi.Name, Status = settings.Firmaadresi });
                list.Add(new SettingModel { Xname = kolon1Beklenentutar.Header.ToString(),      Name = kolon1Beklenentutar.Name, Status = settings.Beklenentutar });
            }
            else if (pagestatus == 2)
            {
                MainGrid2 settings = new MainGrid2();
                list.Add(new SettingModel { Xname = kolon2Id.Header.ToString(), Name = kolon2Id.Name, Status = settings.Id });
                list.Add(new SettingModel { Xname = kolon2Joborder.Header.ToString(), Name = kolon2Joborder.Name, Status = settings.Joborder });
                list.Add(new SettingModel { Xname = kolon2Tür.Header.ToString(), Name = kolon2Tür.Name, Status = settings.Tür });
                list.Add(new SettingModel { Xname = kolon2Türdetay.Header.ToString(), Name = kolon2Türdetay.Name, Status = settings.Türdetay });
                list.Add(new SettingModel { Xname = kolon2Kayıtdetay.Header.ToString(), Name = kolon2Kayıtdetay.Name, Status = settings.Kayıtdetay });
                list.Add(new SettingModel { Xname = kolon2Kayıtdetay1.Header.ToString(), Name = kolon2Kayıtdetay1.Name, Status = settings.Kayıtdetay1 });
                list.Add(new SettingModel { Xname = kolon2Kayıtdetay2.Header.ToString(), Name = kolon2Kayıtdetay2.Name, Status = settings.Kayıtdetay2 });
                list.Add(new SettingModel { Xname = kolon2İsim.Header.ToString(), Name = kolon2İsim.Name, Status = settings.İsim });
                list.Add(new SettingModel { Xname = kolon2Kayıttarihi.Header.ToString(), Name = kolon2Kayıttarihi.Name, Status = settings.Kayıttarihi });
                list.Add(new SettingModel { Xname = kolon2Randevutarih.Header.ToString(), Name = kolon2Randevutarih.Name, Status = settings.Randevutarihi });
                list.Add(new SettingModel { Xname = kolon2Satıselemanı.Header.ToString(), Name = kolon2Satıselemanı.Name, Status = settings.Satıselemanı });
                list.Add(new SettingModel { Xname = kolon2Ürün.Header.ToString(), Name = kolon2Ürün.Name, Status = settings.Ürün });
                list.Add(new SettingModel { Xname = kolon2Ürün2.Header.ToString(), Name = kolon2Ürün2.Name, Status = settings.Ürün2 });
                list.Add(new SettingModel { Xname = kolon2Miktar.Header.ToString(), Name = kolon2Miktar.Name, Status = settings.Miktar });
                list.Add(new SettingModel { Xname = kolon2Birim.Header.ToString(), Name = kolon2Birim.Name, Status = settings.Birim });
                list.Add(new SettingModel { Xname = kolon2Ücret.Header.ToString(), Name = kolon2Ücret.Name, Status = settings.Ücret });
                list.Add(new SettingModel { Xname = kolon2Karaktersayı.Header.ToString(), Name = kolon2Karaktersayı.Name, Status = settings.Karaktersayı });
                list.Add(new SettingModel { Xname = kolon2Satırsayı.Header.ToString(), Name = kolon2Satırsayı.Name, Status = settings.Satırsayı });
                list.Add(new SettingModel { Xname = kolon2Kelimesayı.Header.ToString(), Name = kolon2Kelimesayı.Name, Status = settings.Kelimesayı });
                list.Add(new SettingModel { Xname = kolon2Tavsiyeedilentutar.Header.ToString(), Name = kolon2Tavsiyeedilentutar.Name, Status = settings.Tavsiyeedilentutar });
                list.Add(new SettingModel { Xname = kolon2Önerilenbirim.Header.ToString(), Name = kolon2Önerilenbirim.Name, Status = settings.Önerilenbirim });
                list.Add(new SettingModel { Xname = kolon2Önerilentutar.Header.ToString(), Name = kolon2Önerilentutar.Name, Status = settings.Önerilentutar });
                list.Add(new SettingModel { Xname = kolon2Kdvoran.Header.ToString(), Name = kolon2Kdvoran.Name, Status = settings.Kdvoran });
                list.Add(new SettingModel { Xname = kolon2Metod.Header.ToString(), Name = kolon2Metod.Name, Status = settings.Metod });
                list.Add(new SettingModel { Xname = kolon2Ödemeyöntemi.Header.ToString(), Name = kolon2Ödemeyöntemi.Name, Status = settings.Ödemeyöntemi });
                list.Add(new SettingModel { Xname = kolon2Durum.Header.ToString(), Name = kolon2Durum.Name, Status = settings.Durum });
                list.Add(new SettingModel { Xname = kolon2Acıklama.Header.ToString(), Name = kolon2Acıklama.Name, Status = settings.Acıklama });
                list.Add(new SettingModel { Xname = kolon2Telefon.Header.ToString(), Name = kolon2Telefon.Name, Status = settings.Telefon });
                list.Add(new SettingModel { Xname = kolon2Tckimlik.Header.ToString(), Name = kolon2Tckimlik.Name, Status = settings.Tckimlik });
                list.Add(new SettingModel { Xname = kolon2Eposta.Header.ToString(), Name = kolon2Eposta.Name, Status = settings.Eposta });
                list.Add(new SettingModel { Xname = kolon2Şehir.Header.ToString(), Name = kolon2Şehir.Name, Status = settings.Şehir });
                list.Add(new SettingModel { Xname = kolon2İlçe.Header.ToString(), Name = kolon2İlçe.Name, Status = settings.İlçe });
                list.Add(new SettingModel { Xname = kolon2Adres.Header.ToString(), Name = kolon2Adres.Name, Status = settings.Adres });
                list.Add(new SettingModel { Xname = kolon2Vergidairesi.Header.ToString(), Name = kolon2Vergidairesi.Name, Status = settings.Vergidairesi });
                list.Add(new SettingModel { Xname = kolon2Vergino.Header.ToString(), Name = kolon2Vergino.Name, Status = settings.Vergino });
                list.Add(new SettingModel { Xname = kolon2Firmaadı.Header.ToString(), Name = kolon2Firmaadı.Name, Status = settings.Firmaadı });
                list.Add(new SettingModel { Xname = kolon2Firmaadresi.Header.ToString(), Name = kolon2Firmaadresi.Name, Status = settings.Firmaadresi });
                list.Add(new SettingModel { Xname = kolon2Beklenentutar.Header.ToString(), Name = kolon2Beklenentutar.Name, Status = settings.Beklenentutar });
            }

            return list;
        }

        private void gridcolumnsettings()
        {
            MainGrid settings = new MainGrid();
            kolonId.Visible=settings.Id;
            kolonJoborder.Visible=settings.Joborder;
            kolonTür.Visible=settings.Tür;
            kolonTürdetay.Visible=settings.Türdetay;
            kolonKayıtdetay.Visible=settings.Kayıtdetay;
            kolonKayıtdetay1.Visible = settings.Kayıtdetay1;
            kolonKayıtdetay2.Visible = settings.Kayıtdetay2;
            kolonİsim.Visible=settings.İsim;
            kolonKayıttarihi.Visible=settings.Kayıttarihi;
            kolonRandevutarihi.Visible=settings.Randevutarihi;
            kolonSatıselemanı.Visible=settings.Satıselemanı;
            kolonÜrün.Visible=settings.Ürün;
            kolonÜrün2.Visible=settings.Ürün2;
            kolonMiktar.Visible=settings.Miktar;
            kolonBirim.Visible=settings.Birim;
            kolonÜcret.Visible=settings.Ücret;
            kolonKaraktersayı.Visible=settings.Karaktersayı;
            kolonSatırsayı.Visible=settings.Satırsayı;
            kolonKelimesayı.Visible=settings.Kelimesayı;
            kolonTavsiyeedilentutar.Visible = settings.Tavsiyeedilentutar;
            kolonÖnerilenbirim.Visible=settings.Önerilenbirim;
            kolonÖnerilentutar.Visible=settings.Önerilentutar;
            kolonKdvoran.Visible=settings.Kdvoran;
            kolonMetod.Visible=settings.Metod;
            kolonÖdemeyöntemi.Visible=settings.Ödemeyöntemi;
            kolonDurum.Visible=settings.Durum;
            kolonAcıklama.Visible=settings.Acıklama;
            kolonTelefon.Visible=settings.Telefon;
            kolonTckimlik.Visible=settings.Tckimlik;
            kolonEposta.Visible=settings.Eposta;
            kolonŞehir.Visible=settings.Şehir;
            kolonİlçe.Visible=settings.İlçe;
            kolonAdres.Visible=settings.Adres;
            kolonVergidairesi.Visible=settings.Vergidairesi;
            kolonVergino.Visible=settings.Vergino;
            kolonFirmaadı.Visible=settings.Firmaadı;
            kolonFirmaadresi.Visible = settings.Firmaadresi;
            kolonBeklenentutar.Visible = settings.Beklenentutar;           

        }

        private void gridcolumnsettings1()
        {
            MainGrid1 settings = new MainGrid1();
            kolon1Id.Visible = settings.Id;
            kolon1Joborder.Visible = settings.Joborder;
            kolon1Tür.Visible = settings.Tür;
            kolon1Türdetay.Visible = settings.Türdetay;
            kolon1Kayıtdetay.Visible = settings.Kayıtdetay;
            kolon1Kayıtdetay1.Visible = settings.Kayıtdetay1;
            kolon1Kayıtdetay2.Visible = settings.Kayıtdetay2;
            kolon1İsim.Visible = settings.İsim;
            kolon1Kayıttarihi.Visible = settings.Kayıttarihi;
            kolon1Randevutarih.Visible = settings.Randevutarihi;
            kolon1Satıselemanı.Visible = settings.Satıselemanı;
            kolon1Ürün.Visible = settings.Ürün;
            kolon1Ürün2.Visible = settings.Ürün2;
            kolon1Miktar.Visible = settings.Miktar;
            kolon1Birim.Visible = settings.Birim;
            kolon1Ücret.Visible = settings.Ücret;
            kolon1Karaktersayı.Visible = settings.Karaktersayı;
            kolon1Satırsayı.Visible = settings.Satırsayı;
            kolon1Kelimesayı.Visible = settings.Kelimesayı;
            kolon1Tavsiyeedilentutar.Visible = settings.Tavsiyeedilentutar;
            kolon1Önerilenbirim.Visible = settings.Önerilenbirim;
            kolon1Önerilentutar.Visible = settings.Önerilentutar;
            kolon1Kdvoran.Visible = settings.Kdvoran;
            kolon1Metod.Visible = settings.Metod;
            kolon1Ödemeyöntemi.Visible = settings.Ödemeyöntemi;
            kolon1Durum.Visible = settings.Durum;
            kolon1Acıklama.Visible = settings.Acıklama;
            kolon1Telefon.Visible = settings.Telefon;
            kolon1Tckimlik.Visible = settings.Tckimlik;
            kolon1Eposta.Visible = settings.Eposta;
            kolon1Şehir.Visible = settings.Şehir;
            kolon1İlçe.Visible = settings.İlçe;
            kolon1Adres.Visible = settings.Adres;
            kolon1Vergidairesi.Visible = settings.Vergidairesi;
            kolon1Vergino.Visible = settings.Vergino;
            kolon1Firmaadı.Visible = settings.Firmaadı;
            kolon1Firmaadresi.Visible = settings.Firmaadresi;
            kolon1Beklenentutar.Visible = settings.Beklenentutar;

        }

        private void gridcolumnsettings2()
        {
            MainGrid2 settings = new MainGrid2();
            kolon2Id.Visible = settings.Id;
            kolon2Joborder.Visible = settings.Joborder;
            kolon2Tür.Visible = settings.Tür;
            kolon2Türdetay.Visible = settings.Türdetay;
            kolon2Kayıtdetay.Visible = settings.Kayıtdetay;
            kolon2Kayıtdetay1.Visible = settings.Kayıtdetay1;
            kolon2Kayıtdetay2.Visible = settings.Kayıtdetay2;
            kolon2İsim.Visible = settings.İsim;
            kolon2Kayıttarihi.Visible = settings.Kayıttarihi;
            kolon2Randevutarih.Visible = settings.Randevutarihi;
            kolon2Satıselemanı.Visible = settings.Satıselemanı;
            kolon2Ürün.Visible = settings.Ürün;
            kolon2Ürün2.Visible = settings.Ürün2;
            kolon2Miktar.Visible = settings.Miktar;
            kolon2Birim.Visible = settings.Birim;
            kolon2Ücret.Visible = settings.Ücret;
            kolon2Karaktersayı.Visible = settings.Karaktersayı;
            kolon2Satırsayı.Visible = settings.Satırsayı;
            kolon2Kelimesayı.Visible = settings.Kelimesayı;
            kolon2Tavsiyeedilentutar.Visible = settings.Tavsiyeedilentutar;
            kolon2Önerilenbirim.Visible = settings.Önerilenbirim;
            kolon2Önerilentutar.Visible = settings.Önerilentutar;
            kolon2Kdvoran.Visible = settings.Kdvoran;
            kolon2Metod.Visible = settings.Metod;
            kolon2Ödemeyöntemi.Visible = settings.Ödemeyöntemi;
            kolon2Durum.Visible = settings.Durum;
            kolon2Acıklama.Visible = settings.Acıklama;
            kolon2Telefon.Visible = settings.Telefon;
            kolon2Tckimlik.Visible = settings.Tckimlik;
            kolon2Eposta.Visible = settings.Eposta;
            kolon2Şehir.Visible = settings.Şehir;
            kolon2İlçe.Visible = settings.İlçe;
            kolon2Adres.Visible = settings.Adres;
            kolon2Vergidairesi.Visible = settings.Vergidairesi;
            kolon2Vergino.Visible = settings.Vergino;
            kolon2Firmaadı.Visible = settings.Firmaadı;
            kolon2Firmaadresi.Visible = settings.Firmaadresi;
            kolon2Beklenentutar.Visible = settings.Beklenentutar;

        }

        private void Özelfirmasecim_SelectionChanged(object sender, TabControlSelectionChangedEventArgs e)
        {
            DXTabControl item = sender as DXTabControl;
            pagestatus = Convert.ToInt16(item.SelectedIndex);
        }



        #endregion

        private bool save()
        {
            bool isok = false;
            try
            {
                foreach (GridColumn column in grdmain.Columns)
                    column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                
              
                grdmain.SaveLayoutToXml(System.Environment.CurrentDirectory + "\\grdmain1.xml");
                LogVM.displaypopup("INFO", "Ayarlar Kayıt Edildi");
            }
            catch (Exception)
            {
                LogVM.displaypopup("ERROR", "Hatalı Kayıt");

            }
            return isok;
        }

        void column_AllowProperty(object sender, AllowPropertyEventArgs e)
        {
            e.Allow = e.DependencyProperty == GridColumn.ActualWidthProperty ||
                      e.DependencyProperty == GridColumn.FieldNameProperty ||
                      e.DependencyProperty == GridColumn.VisibleProperty ||
                      e.DependencyProperty== GridColumn.AllowBestFitProperty||
                      e.DependencyProperty == GridColumn.AllowGroupingProperty;
        }

        private void Btnlayoutsave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            save();
        }
    }
}















































































































