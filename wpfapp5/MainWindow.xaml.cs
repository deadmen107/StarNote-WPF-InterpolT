using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.WindowsUI;
using StarNote.Model;
using StarNote.View;
using StarNote.ViewModel;
using StarNote.Service;
using StarNote.Utils;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using StarNote.View.Common;


namespace StarNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : ThemedWindow
    {
        public static AppPages ActivePage = AppPages.MainGrid;
        private static MainWindowVM windowVM = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = windowVM;
            windowVM.Pagestatus = 0;
            GridControlLocalizer.Active = new TurkishFiltersLocalizer();
            RefreshViews.pagecount = 1;
            WeatherStatus();
            createxmlfolder();
            //notifier.ShowInformation("Star Note Veri Takip Uygulaması Versiyon 2.0");
            txtversiyon.Text = "Version V" + GetPublishedVersion();
        }
        public static bool pagechanged;
        public static string GetPublishedVersion()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else
            {
                return "1.0.0.1";
            }
        }
        public static void ChangePage(AppPages page)
        {
            ActivePage = page;
            windowVM.Pagestatus = (int)page;
        }

        public static readonly DependencyProperty windowevent;

        private void createxmlfolder()
        {

            DirectoryInfo fi1 = new DirectoryInfo("C:\\StarNote");
            if (!fi1.Exists)
            {                  
                fi1.Create();
            }

            DirectoryInfo fi2 = new DirectoryInfo("C:\\StarNote\\Templates");
            if (!fi2.Exists)
            {
                fi2.Create();
            }
        }

        public static Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);
            
            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(4));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private void HamburgerSubMenuNavigationButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerSubMenuNavigationButton menu = sender as HamburgerSubMenuNavigationButton;
            DocumentPanel panel = null;           
            if (menu != null)
            {
                menü.Text = (string)menu.Content;
                windowVM.Pagestatus = Convert.ToInt32(menu.Tag);
            }
            if (panel != null)
            {
                if (panel.IsClosed)
                {
                    dockLayoutManager.DockController.Restore(panel);
                }
                panel.Visibility = Visibility.Visible;
                dockLayoutManager.DockController.Activate(panel);
            }
        }

        private async void WeatherStatus()
        {

            try
            {
                string lokasyon = ConfigurationManager.AppSettings["lokasyon"].ToString();                
                string CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + lokasyon + "&lang=tr&mode=json&units=metric&APPID=d739b3c8f4d94c7da59c1601bcbf9132";

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string xmlContent = await client.DownloadStringTaskAsync(CurrentURL);

                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherModel.RootObject>(xmlContent);
                    txtHava.Text = lokasyon + " Hava Sıcaklık: " + obj.main.temp.ToString() + " °C" + " Hissedilen Sıcaklık: " + obj.main.feels_like.ToString() + " °C" + " Nem: %" + obj.main.humidity.ToString() + " Durum: " + obj.weather[0].description.ToString();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("http://openweathermap.org/img/w/" + obj.weather[0].icon + ".png");
                    bitmap.EndInit();
                    imgHava.Source = bitmap;
                }
                notifier.ShowInformation("Hava Durumu Bilgisi Alındı");
            }
            catch (Exception ex)
            {
                txtHava.Text = "--";
                notifier.ShowError("Hava Durumu Bilgisi Alınamadı");
                //MailGonder.SendMail("hava durumu cekilirken hata",ex.ToString());
            }
        }

        private void HamburgerMenuNavigationButton_Click_1(object sender, RoutedEventArgs e)
        {
           string msg = " Uygulamayı kapatmak istiyor musunuz?";
            MessageBoxResult result = MessageBox.Show(msg, "Star Note ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void ThemedWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = " Uygulamayı kapatmak istiyor musunuz?";
            MessageBoxResult result = MessageBox.Show(msg, "Star Note", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Txtversiyon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            VersionUC versionUC = new VersionUC();
            versionUC.Show();
        }

        public enum AppPages
        {
            DailyPurchase = 0,
            DailySales = 1,
            AnalysisScreen = 2,
            MontlyPurchase = 3,
            MontlySales = 4,
            Log = 5,
            Password = 6,
            Printing = 7,
            Company = 8,
            CompanyEdit = 9,
            Costumer = 10,
            CostumerEdit = 11,
            Filemanagement = 12,
            FilemanagementEdit = 13,
            Goals = 14,
            Lisance = 15,
            MainCompanyEdit = 16,
            MainGrid = 17,
            MainLawEdit = 18,
            MainPrivateEdit = 19,
            MainPurchaseEdit = 20,
            MainSalesEdit = 21,
            Product = 22,
            ProductEdit = 23,
            Salesman = 24,
            SalesmanEdit = 25,
            Stok = 26,
            StokEdit = 27,
            Type = 28,
            TypeEdit = 29,
            TypeDetail = 30,
            TypeDetailEdit = 31,
            Users = 32,
            UsersEdit = 33,
            Reminding = 34
        }
    }

    public class TurkishFiltersLocalizer : GridControlLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();
            
            AddString(GridControlStringId.GridGroupPanelText, "Grouplamak istediğiniz alanları buraya sürükleyiniz.");
            AddString(GridControlStringId.MenuColumnClearSorting, "Sıralamayı Kaldır");
            AddString(GridControlStringId.MenuColumnHideGroupPanel, "Grouplama Alanını Gizle");
            AddString(GridControlStringId.MenuColumnShowGroupPanel, "Grouplama Alanını Göster");
            //AddString(GridControlStringId.menucolumnhidecol, " Sütünü Kaldır");
            AddString(GridControlStringId.MenuColumnFilterEditor, " Filtreleme & Düzenleme");
            //AddString(GridControlStringId.menucolumnshow , "Aramayı Göster");
            AddString(GridControlStringId.MenuColumnShowColumnChooser, "Kolon Seçimini Aç");
            AddString(GridControlStringId.MenuColumnSortAscending, " Artan");
            AddString(GridControlStringId.MenuColumnSortDescending, "Azalan");
            AddString(GridControlStringId.MenuColumnGroup, "Bu alan için Grupla");
            AddString(GridControlStringId.MenuColumnUnGroup, "Çöz");
            //AddString(GridControlStringId.MenuColumnColumnCustomization, "Özel Sütün");
            AddString(GridControlStringId.MenuColumnBestFit, "En uygun Genişlik");
            //AddString(GridControlStringId.MenuColumnFilter, "Filtrele");
            AddString(GridControlStringId.MenuColumnClearFilter, "Filtremeyi Kaldır");
            AddString(GridControlStringId.MenuColumnBestFitColumns, "Tüm Sütünler Optimal");
            AddString(GridControlStringId.ConditionalFormatting_Manager_BeginningWith, "ile başlıyor");
            //AddString(GridControlStringId.ConditionalFormatting_Manager_BeginningWith, "ile başlıyor");
            AddString(GridControlStringId.MenuGroupPanelClearGrouping,"Gruplandırmayı temizle");
            //AddString(GridControlStringId.FindControlClearButton,"Temizle");
            //AddString(GridControlStringId.FindControlFindButton,"Ara");
            AddString(GridControlStringId.FilterEditorTitle, "Kolon Filtreleme");
        
            AddString(GridControlStringId.MenuGroupPanelFullExpand, "Hepsini genişlet");
            AddString(GridControlStringId.MenuGroupPanelFullCollapse,"Hepsini gizle");
            AddString(GridControlStringId.ColumnChooserCaption, "Kolon Seçimi");
            AddString(GridControlStringId.ExtendedColumnChooserSearchColumns, "Kolon arama");
        }
    }    
}
