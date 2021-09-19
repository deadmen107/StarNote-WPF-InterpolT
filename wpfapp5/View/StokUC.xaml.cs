using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StarNote.Utils;
using StarNote.ViewModel;
using StarNote.Service;
using StarNote.Settings;
using StarNote.Model;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for StokUC.xaml
    /// </summary>
    public partial class StokUC : UserControl
    {
        StokVM stokVM = new StokVM();
        public StokUC()
        {
            InitializeComponent();
           
            this.DataContext = stokVM;
            gridcolumnsettings();
        }
        private List<SettingModel> list = new List<SettingModel>();
        private bool userControlHasFocus;

        private void Tablesatınalma_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Stok_Güncelle))
            {
                stokVM.Currentdata.Id = Convert.ToInt32(gridstok.GetFocusedRowCellDisplayText("ID"));
                stokVM.Currentdata.Stokkod = gridstok.GetFocusedRowCellDisplayText("SK").ToString();
                stokVM.Currentdata.Stokadı = gridstok.GetFocusedRowCellDisplayText("SA").ToString();
                stokVM.Currentdata.Miktar = Convert.ToInt32(gridstok.GetFocusedRowCellDisplayText("SM"));
                //stokVM.Currentdata.Stokürün = gridstok.GetFocusedRowCellDisplayText("SB").ToString();
                stokVM.Currentdata.Alışfiyat = Convert.ToDouble(gridstok.GetFocusedRowCellValue("SAL"));
                stokVM.Currentdata.Satışfiyat = Convert.ToDouble(gridstok.GetFocusedRowCellValue("SSA"));
                stokVM.Currentdata.Kdv = gridstok.GetFocusedRowCellDisplayText("SKDV").ToString();
                stokVM.Currentdata.İskonto = Convert.ToDouble(gridstok.GetFocusedRowCellValue("SF"));               
                kayıtekrantext.Text = "DİLLER > Güncelle";
                btngüncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Stok_Güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; 
            }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 8)
                {
                    stokVM.loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<StokUC>();
            //if (popup.IsOpen)
            //{
            //    popup.IsOpen=false;
            //}
            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "DİLLER";           
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (stokVM.Update())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
                //MessageBox.Show("Güncelleme Tamamlandı", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Information);               
            }
            else
            {
                MessageBox.Show("Güncelleme Başarısız", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }                  
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Stok_Ekle))
            {
                stokVM.Currentdata = new Model.StokModel();
                kayıtekrantext.Text = "DİLLER > Yeni Kayıt";
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Stok_Ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }               
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (stokVM.Save())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Kaydetme Tamamlandı");
                //MessageBox.Show("Kaydetme Tamamlandı", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Stok_Yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Stok;
                    if (printingRoute.Stok == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Stok raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)gridstok.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.Stok + "\\Stok " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Stok Rapor alındı ", "");
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }

                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Stok Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Stok_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Stok_Yazdırma))
            {
                string RaporAdı = "Diller";
                try
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Stok;
                    if (printingRoute.Stok == "")
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
                            links.Add(new PrintableControlLink((TableView)gridstok.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.Stok + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Stok_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Gridstok_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SAL" || e.Column.FieldName == "SSA" || e.Column.FieldName=="SF")
            {
                e.DisplayText = e.DisplayText + " TL";
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
            StokGridUI settings = new StokGridUI();
            if (s.Name.ToString() == ID.Name) settings.ID = (bool)s.IsChecked;
            if (s.Name.ToString() == Stokkod.Name) settings.Stokkod = (bool)s.IsChecked;
            if (s.Name.ToString() == Stokadı.Name) settings.Stokadı = (bool)s.IsChecked;           
            if (s.Name.ToString() == Miktar.Name) settings.Miktar = (bool)s.IsChecked;
            if (s.Name.ToString() == Birim.Name) settings.Birim = (bool)s.IsChecked;
            if (s.Name.ToString() == Alışfiyat.Name) settings.Alışfiyat = (bool)s.IsChecked;
            if (s.Name.ToString() == Satışfiyat.Name) settings.Satışfiyat = (bool)s.IsChecked;
            if (s.Name.ToString() == Kdv.Name) settings.Kdv = (bool)s.IsChecked;
            if (s.Name.ToString() == İskonto.Name) settings.İskonto = (bool)s.IsChecked;
            settings.Save();
            gridcolumnsettings();
        }

        private List<SettingModel> createsettinglist()
        {
            StokGridUI settings = new StokGridUI();
            List<SettingModel> list = new List<SettingModel>();
            list.Add(new SettingModel {  Xname=ID.Header.ToString(),   Name = ID.Name, Status = settings.ID });
            list.Add(new SettingModel {  Xname=Stokkod.Header.ToString(),   Name = Stokkod.Name, Status = settings.Stokkod });
            list.Add(new SettingModel {  Xname=Stokadı.Header.ToString(),   Name = Stokadı.Name, Status = settings.Stokadı });          
            list.Add(new SettingModel {  Xname=Miktar.Header.ToString(),   Name = Miktar.Name, Status = settings.Miktar });
            list.Add(new SettingModel {  Xname=Birim.Header.ToString(),   Name = Birim.Name, Status = settings.Birim });
            list.Add(new SettingModel {  Xname=Alışfiyat.Header.ToString(),   Name = Alışfiyat.Name, Status = settings.Alışfiyat });
            list.Add(new SettingModel {  Xname=Satışfiyat.Header.ToString(),   Name = Satışfiyat.Name, Status = settings.Satışfiyat });
            list.Add(new SettingModel {  Xname=Kdv.Header.ToString(),   Name = Kdv.Name, Status = settings.Kdv });
            list.Add(new SettingModel {  Xname= İskonto.Header.ToString(),  Name = İskonto.Name, Status = settings.İskonto });
            return list;
        }

        private void gridcolumnsettings()
        {
            StokGridUI settings = new StokGridUI();         
            ID.Visible = settings.ID;
            Stokkod.Visible = settings.Stokkod;
            Stokadı.Visible = settings.Stokadı;           
            Miktar.Visible = settings.Miktar;
            Birim.Visible = settings.Birim;
            Alışfiyat.Visible = settings.Alışfiyat;
            Satışfiyat.Visible = settings.Satışfiyat;
            Kdv.Visible = settings.Kdv;
            İskonto.Visible = settings.İskonto;          
        }
    }
}
