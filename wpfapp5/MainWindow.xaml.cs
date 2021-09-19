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

namespace StarNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : ThemedWindow
    {
    
        public MainWindow()
        {
            
            InitializeComponent();
            GridControlLocalizer.Active = new TurkishFiltersLocalizer();
            RefreshViews.pagecount = 1;
            WeatherStatus();
            //notifier.ShowInformation("Star Note Veri Takip Uygulaması Versiyon 2.0");
        }
        public static bool pagechanged;

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

        private void HamburgerMenuNavigationButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void HamburgerSubMenuNavigationButton_Click(object sender, RoutedEventArgs e)
        {
            
            HamburgerSubMenuNavigationButton menu = sender as HamburgerSubMenuNavigationButton;
            DocumentPanel panel = null;           
            if (menu != null)
            {
                RefreshViews.pagecount = Convert.ToInt16(menu.Tag);
                if (menu.Tag.ToString() == "1" && UserUtils.Authority.Contains(UserUtils.Genel_Takip_Ekranı))
                {
                    panel = documentPanelANAMENU;
                    menü.Text = "Genel Takip Ekranı";
                }
                else if (menu.Tag.ToString() == "2" && UserUtils.Authority.Contains(UserUtils.Yeni_Kayıt_Ekleme))
                {
                    panel = documentPanelANAMENU;
                    menü.Text = "Özel Müşteri Tercümesi Ekleme";

                }
                else if (menu.Tag.ToString() == "3" && UserUtils.Authority.Contains(UserUtils.Satış_görevli_görüntüle))
                {
                    panel = documentAddSalesman;
                    menü.Text = "Satış Görevli Tanımlama";
                }
                else if (menu.Tag.ToString() == "4")
                {
                    panel = documenthatırlatma;
                    menü.Text = "HATIRLATMALAR";
                }
                else if (menu.Tag.ToString() == "5")
                {
                    panel = documenthatırlatma;
                    menü.Text = "ESKİ HATIRLATMALAR";

                }
                else if (menu.Tag.ToString() == "6" && UserUtils.Authority.Contains(UserUtils.Günlük_Satın_Alma))
                {

                    panel = documentPanelMUHASEBEALIS;
                    menü.Text = "Günlük Satın Alma ";

                }
                else if (menu.Tag.ToString() == "7" && UserUtils.Authority.Contains(UserUtils.Günlük_Satış))
                {
                    panel = documentPanelMUHASEBESATIS;
                    menü.Text = "Günlük Satış ";
                }
                else if (menu.Tag.ToString() == "8" && UserUtils.Authority.Contains(UserUtils.Stok_Takip_Ekranı))
                {
                    
                    panel = documentPanelSTOK;
                    menü.Text = "Stok Takip Ekranı";
                }
                else if (menu.Tag.ToString() == "9" && UserUtils.Authority.Contains(UserUtils.Aylık_Satın_Alma))
                {
                    panel = documentPanelGELİR;
                    menü.Text = "Aylık Satın Alma ";

                }
                else if (menu.Tag.ToString() == "10" && UserUtils.Authority.Contains(UserUtils.Aylık_Satış))
                {
                    panel = documentPanelGİDER;
                    menü.Text = "Aylık Satış Takip";
                }
                else if (menu.Tag.ToString() == "11" && UserUtils.Authority.Contains(UserUtils.Aylık_Analiz))
                {
                    panel = documentPanelAylıkANALIZ;
                    menü.Text = "Aylık Analiz Ekranı ";
                }
                else if (menu.Tag.ToString() == "12" && UserUtils.Authority.Contains(UserUtils.Yıllık_Analiz))
                {
                    panel = documentPanelYıllıkANALIZ;
                    menü.Text = "Yıllık Analiz Ekranı ";
                }
                else if (menu.Tag.ToString() == "14" && UserUtils.Authority.Contains(UserUtils.SatışGörevli_analiz))
                {
                    panel = documentPanelPERSONEL;
                    menü.Text = "Personel Takip Ekranı ";
                }
                else if (menu.Tag.ToString() == "15" && UserUtils.Authority.Contains(UserUtils.Dosya_yolu_görüntüle))
                {
                    panel = documentPanelPrint;
                    menü.Text = "Dosya Yolu Ayarları";
                }
                else if (menu.Tag.ToString() == "16" && UserUtils.Authority.Contains(UserUtils.İşlem_Kayıt_Görüntüle))
                {
                    panel = documentlog;
                    menü.Text = "Kayıt Defteri";
                }
                else if (menu.Tag.ToString() == "17" && UserUtils.Authority.Contains(UserUtils.Kullanıcıları_Görüntül))
                {
                    panel = documentPanelUSERS;
                    menü.Text = "Kullanıcı Ayarları ";
                }
                else if (menu.Tag.ToString() == "18" && UserUtils.Authority.Contains(UserUtils.Hedef_ekranı))
                {
                    panel = documentPanelHEDEFLER;
                    menü.Text = "Hedefler ";
                }
                else if (menu.Tag.ToString() == "19" && UserUtils.Authority.Contains(UserUtils.Tür_görüntüle))
                {
                    panel = documentAddTür;
                    menü.Text = "Tür Ekleme ";
                }
                else if (menu.Tag.ToString() == "20" && UserUtils.Authority.Contains(UserUtils.Dosya_Takip_Ekranı))
                {
                    panel = documentdosyatakip;
                    menü.Text = "Dosya Takip Ekranı ";
                }
                else if (menu.Tag.ToString() == "21" && UserUtils.Authority.Contains(UserUtils.Firma_görüntüle))
                {
                    panel = documentfirmaekleme;
                    menü.Text = "Firma Ekleme ";
                }
                else if (menu.Tag.ToString() == "22" && UserUtils.Authority.Contains(UserUtils.Müşteri_görüntüle))
                {
                    panel = documentmüsteriekle;
                    menü.Text = "Müşteri Ekleme ";
                }
                else if (menu.Tag.ToString() == "23")
                {
                    panel = documentşifre;
                    menü.Text = "Parola Değiştirme";
                }
                else if (menu.Tag.ToString() == "24" && UserUtils.Authority.Contains(UserUtils.Ürün_detay_ekranı))
                {
                    panel = documentürünekle;
                    menü.Text = "Ürün Tanımlama";
                }
                else if (menu.Tag.ToString() == "25" && UserUtils.Authority.Contains(UserUtils.Tür_görüntüle))
                {
                    panel = documentürdetay;
                    menü.Text = "Tür Detay Ekleme ";
                }
                else if (menu.Tag.ToString() == "26" && UserUtils.Authority.Contains(UserUtils.Yeni_Kayıt_Ekleme))
                {
                    panel = documentPanelANAMENU;
                    menü.Text = "Şirket Tercümesi Ekleme";
                }
                else if (menu.Tag.ToString() == "27" && UserUtils.Authority.Contains(UserUtils.Yeni_Kayıt_Ekleme))
                {
                    panel = documentPanelANAMENU;
                    menü.Text = "Mahkeme Tercümesi Ekleme";
                }
                else if (menu.Tag.ToString() == "28" )
                {
                    LisanceWindow lisanceWindow = new LisanceWindow();
                    lisanceWindow.Show();
                    panel = documentPanelANAMENU;
                }
                else
                {
                    MessageBox.Show("Kullanıcının bu sayfaya yetkisi yok");
                    panel = documentPanelANAMENU;
                    menü.Text = "Genel Takip Ekranı";
                }

            }

            if (panel.IsClosed)
            {
                dockLayoutManager.DockController.Restore(panel);
            }
            panel.Visibility = Visibility.Visible;
            dockLayoutManager.DockController.Activate(panel);
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

        private void Havadurumu_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Havadurumu_MouseLeave(object sender, MouseEventArgs e)
        {

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
        }
    }    
}
