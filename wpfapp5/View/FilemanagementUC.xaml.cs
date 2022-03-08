using System;
using System.Collections.Generic;
using System.IO;
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
using DevExpress.Xpf.Core.Serialization;
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
            restoreviews();
        }

        private void restoreviews()
        {
            FileInfo fi = new FileInfo("C:\\StarNote\\Templates\\griddosyatakip.xml");
            if (fi.Exists)
            {
                griddosyatakip.RestoreLayoutFromXml("C:\\StarNote\\Templates\\griddosyatakip.xml");
            }           
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosyatakip_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.Dosyalar, "Dosyalar", PrintUtils.PDF, griddosyatakip);
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
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.Dosyalar, "Dosyalar", PrintUtils.Excel, griddosyatakip);
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
            filemanagementVM.fillcurrentdata(Convert.ToInt32(griddosyatakip.GetFocusedRowCellDisplayText("ID")));
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
                    //model.İşemrino = "";
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

        private bool savetemplate()
        {
            bool isok = false;
            try
            {
                foreach (GridColumn column in griddosyatakip.Columns)
                    column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                griddosyatakip.SaveLayoutToXml("C:\\StarNote\\Templates\\griddosyatakip.xml");
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
                      e.DependencyProperty == GridColumnBase.HeaderProperty ||
                      e.DependencyProperty == GridColumn.BindingGroupProperty
                      ;

        }

        private void Btnlayoutsave_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {            
            savetemplate();
        }
    }
}

