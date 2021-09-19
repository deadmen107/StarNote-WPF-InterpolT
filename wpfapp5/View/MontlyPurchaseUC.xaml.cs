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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StarNote.Model;
using StarNote.Service;
using StarNote.Settings;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for MontlyPurchaseUC.xaml
    /// </summary>
    public partial class MontlyPurchaseUC : UserControl
    {
        MontlyPurchaseVM montlyPurchaseVM = new MontlyPurchaseVM();
        private bool userControlHasFocus;
        private List<SettingModel> list = new List<SettingModel>();
        public MontlyPurchaseUC()
        {
            InitializeComponent();
            this.DataContext = montlyPurchaseVM;
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            this.Language = XmlLanguage.GetLanguage("tr-TR");
            cd.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
            filtregünü.SelectedDate = DateTime.Now;
        }
        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 9)
                {
                    montlyPurchaseVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<MontlyPurchaseUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Filtregünü_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RefreshViews.appstatus)
                montlyPurchaseVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
        }
        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_satınalma_yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Satın Alma Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.MontlyPurchase;
                    if (printingRoute.MontlyPurchase == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Aylık Satın Alma raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdsatınalma.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.MontlyPurchase + "\\Aylık Satın Alma " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Satın Alma Rapor alındı ", "");
                            MessageBox.Show("Dosya Oluşturuldu", "PDF Rapor", MessageBoxButton.OK, MessageBoxImage.Information);
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }

                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Satın Alma Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_satınalma_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_satınalma_yazdırma))
            {
                string RaporAdı = "Aylık Satın Alma";
                try
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.MontlyPurchase;
                    if (printingRoute.MontlyPurchase == "")
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
                            links.Add(new PrintableControlLink((TableView)grdsatınalma.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.MontlyPurchase + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_satınalma_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

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
                foreach (var objDomain in list)
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
            MontlyPurchaseUI settings = new MontlyPurchaseUI();
            if (s.Name.ToString() == Id.Name) settings.Id = (bool)s.IsChecked;
            if (s.Name.ToString() == Satisgorevli.Name) settings.Satisgorevli = (bool)s.IsChecked;
            if (s.Name.ToString() == Urun.Name) settings.Urun = (bool)s.IsChecked;
            if (s.Name.ToString() == Miktar.Name) settings.Miktar = (bool)s.IsChecked;
            if (s.Name.ToString() == Birim.Name) settings.Birim = (bool)s.IsChecked;
            if (s.Name.ToString() == Randevutarihi.Name) settings.Randevutarihi = (bool)s.IsChecked;
            if (s.Name.ToString() == Fiyat.Name) settings.Fiyat = (bool)s.IsChecked;
            if (s.Name.ToString() == Ödemeyöntemi.Name) settings.Ödemeyöntemi = (bool)s.IsChecked;
            settings.Save();
            gridcolumnsettings();
        }

        private List<SettingModel> createsettinglist()
        {
            MontlyPurchaseUI settings = new MontlyPurchaseUI();
            List<SettingModel> list = new List<SettingModel>();
            list.Add(new SettingModel { Xname = Id.Header.ToString(), Name = Id.Name, Status = settings.Id });
            list.Add(new SettingModel { Xname = Satisgorevli.Header.ToString(), Name = Satisgorevli.Name, Status = settings.Satisgorevli });
            list.Add(new SettingModel { Xname = Urun.Header.ToString(), Name = Urun.Name, Status = settings.Urun });
            list.Add(new SettingModel { Xname = Miktar.Header.ToString(), Name = Miktar.Name, Status = settings.Miktar });
            list.Add(new SettingModel { Xname = Birim.Header.ToString(), Name = Birim.Name, Status = settings.Birim });
            list.Add(new SettingModel { Xname = Randevutarihi.Header.ToString(), Name = Randevutarihi.Name, Status = settings.Randevutarihi });
            list.Add(new SettingModel { Xname = Fiyat.Header.ToString(), Name = Fiyat.Name, Status = settings.Fiyat });
            list.Add(new SettingModel { Xname = Ödemeyöntemi.Header.ToString(), Name = Ödemeyöntemi.Name, Status = settings.Ödemeyöntemi });
            return list;
        }

        private void gridcolumnsettings()
        {
            MontlyPurchaseUI settings = new MontlyPurchaseUI();
            Id.Visible = settings.Id;
            Satisgorevli.Visible = settings.Satisgorevli;
            Urun.Visible = settings.Urun;
            Miktar.Visible = settings.Miktar;
            Birim.Visible = settings.Birim;
            Randevutarihi.Visible = settings.Randevutarihi;
            Fiyat.Visible = settings.Fiyat;
            Ödemeyöntemi.Visible = settings.Ödemeyöntemi;
        }
    }
}
