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
    /// Interaction logic for FilemanagementUC.xaml
    /// </summary>
    public partial class FilemanagementUC : UserControl
    {
        FilemanagementVM filemanagementVM = new FilemanagementVM();
        private List<SettingModel> list = new List<SettingModel>();
        private bool userControlHasFocus;
        private string filename;
        public FilemanagementUC()
        {
            InitializeComponent();
            this.DataContext = filemanagementVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosyatakip_yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Takip Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Dosya_Takip;
                    if (printingRoute.Dosya_Takip == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Dosya Takip raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)griddosyatakip.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.Dosya_Takip + "\\Dosya Takip " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Takip Rapor alındı ", "");
                            MessageBox.Show("Dosya Oluşturuldu", "PDF Rapor", MessageBoxButton.OK, MessageBoxImage.Information);
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }

                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Takip Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Dosyatakip_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosyatakip_yazdırma))
            {
                string RaporAdı = "Dosya Takip";
                try
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Dosya_Takip;
                    if (printingRoute.Dosya_Takip == "")
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
                            links.Add(new PrintableControlLink((TableView)griddosyatakip.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.Dosya_Takip + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Dosyatakip_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            //filemanagementVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
            //filemanagementVM.Currentdata.Görevliadı = gridhedef.GetFocusedRowCellDisplayText("GA").ToString();
            //kayıtekrantext.Text = "Türler > Güncelle";
            //btngüncelle.Visibility = Visibility.Visible;
            //btnkayıt.Visibility = Visibility.Hidden;
            //tabcontrol.SelectedItem = tabgüncelleme;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 20)
                {
                    filemanagementVM.Loaddata();
                }
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<FilemanagementUC>();
            if (parent != this) userControlHasFocus = false;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            //tabcontrol.SelectedItem = tabtakip;
        }

        private void fillcurrentdata()
        {
            filemanagementVM.Currentdata.Id = Convert.ToInt32(griddosyatakip.GetFocusedRowCellDisplayText("ID"));
            filemanagementVM.Currentdata.Türadı = griddosyatakip.GetFocusedRowCellDisplayText("1");
            filemanagementVM.Currentdata.Firmadı = griddosyatakip.GetFocusedRowCellDisplayText("2");
            filemanagementVM.Currentdata.İşemrino = griddosyatakip.GetFocusedRowCellDisplayText("3");
            filemanagementVM.Currentdata.Müşteriadı = griddosyatakip.GetFocusedRowCellDisplayText("4");
            filemanagementVM.Currentdata.Dosyaadı = griddosyatakip.GetFocusedRowCellDisplayText("5");
        }

        private void Btnindir_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_İndir))
            {
                fillcurrentdata();
                filemanagementVM.Downloadfile();
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok");
            }

        }

        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Silme))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (filemanagementVM.DeleteFilefromftp())
                    {
                        tabcontrol.SelectedItem = tabtakip;
                        //MessageBox.Show("Silme Tamamlandı", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Information);
                        LogVM.displaypopup("INFO", "Silme Tamamlandı");
                    }
                    else
                    {
                        MessageBox.Show("Silme Başarısız", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }                      
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok");
            }


        }

        private void Btnyenidizin_Click(object sender, RoutedEventArgs e)
        {
            string oSelectedFile = "";
            System.Windows.Forms.OpenFileDialog oDlg = new System.Windows.Forms.OpenFileDialog();
            if (System.Windows.Forms.DialogResult.OK == oDlg.ShowDialog())
            {
                oSelectedFile = oDlg.FileName;
                string[] forname = oSelectedFile.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                filename = forname.Last();
                txtdosyaad.Text = oDlg.FileName;
                // Do whatever you want with oSelectedFile
            }
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                kayıtekrantext.Text = "Dosya Takip > Yeni Kayıt";
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
                  
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Dosya Takip";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Harici Dosya Yükleme Başladı", "");
                if (txtaltbaslık.Text.Trim() != string.Empty || txtfirmaad.Text.Trim() != string.Empty)
                {
                    FilemanagementModel model = new FilemanagementModel();
                    model.Türadı = txtaltbaslık.Text;
                    model.Firmadı = txtfirmaad.Text;
                    model.Dosyaadı = filename;
                    model.Müşteriadı = "Harici yükleme";
                    model.İşemrino = "";
                    model.Id = 0;
                    if (filemanagementVM.printirsaliye(model,txtdosyaad.Text))
                    {
                        tabcontrol.SelectedItem = tabtakip;
                        filemanagementVM.Loaddata();
                    }                  
                }
                else
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurunuz!", "Kayıt Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
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
            Filemanagement settings = new Filemanagement();
            if (s.Name.ToString() == Id.Name) settings.Id = (bool)s.IsChecked;
            if (s.Name.ToString() == Türadı.Name) settings.Türadı = (bool)s.IsChecked;
            if (s.Name.ToString() == Türdetay.Name) settings.Türdetay = (bool)s.IsChecked;
            if (s.Name.ToString() == Kayıtdetay.Name) settings.Kayıtdetay = (bool)s.IsChecked;
            if (s.Name.ToString() == Firmadı.Name) settings.Firmadı = (bool)s.IsChecked;
            if (s.Name.ToString() == İşemrino.Name) settings.İşemrino = (bool)s.IsChecked;
            if (s.Name.ToString() == Müşteriadı.Name) settings.Müşteriadı = (bool)s.IsChecked;
            if (s.Name.ToString() == Dosyaadı.Name) settings.Dosyaadı = (bool)s.IsChecked;         
            settings.Save();
            gridcolumnsettings();
        }

        private List<SettingModel> createsettinglist()
        {
            Filemanagement settings = new Filemanagement();
            List<SettingModel> list = new List<SettingModel>();
            list.Add(new SettingModel { Xname = Id.Header.ToString(), Name = Id.Name, Status = settings.Id });
            list.Add(new SettingModel { Xname = Türadı.Header.ToString(), Name = Türadı.Name, Status = settings.Türadı });
            list.Add(new SettingModel { Xname = Türdetay.Header.ToString(), Name = Türdetay.Name, Status = settings.Türdetay });
            list.Add(new SettingModel { Xname = Kayıtdetay.Header.ToString(), Name = Kayıtdetay.Name, Status = settings.Kayıtdetay });
            list.Add(new SettingModel { Xname = Firmadı.Header.ToString(), Name = Firmadı.Name, Status = settings.Firmadı });
            list.Add(new SettingModel { Xname = İşemrino.Header.ToString(), Name = İşemrino.Name, Status = settings.İşemrino });
            list.Add(new SettingModel { Xname = Müşteriadı.Header.ToString(), Name = Müşteriadı.Name, Status = settings.Müşteriadı });
            list.Add(new SettingModel { Xname = Dosyaadı.Header.ToString(), Name = Dosyaadı.Name, Status = settings.Dosyaadı });
           
            return list;
        }

        private void gridcolumnsettings()
        {
            Filemanagement settings = new Filemanagement();
            Id.Visible = settings.Id;
            Türadı.Visible = settings.Türadı;
            Türdetay.Visible = settings.Türdetay;
            Kayıtdetay.Visible = settings.Kayıtdetay;
            Firmadı.Visible = settings.Firmadı;
            İşemrino.Visible = settings.İşemrino;
            Müşteriadı.Visible = settings.Müşteriadı;
            Dosyaadı.Visible = settings.Dosyaadı;           
        }
    }
}

