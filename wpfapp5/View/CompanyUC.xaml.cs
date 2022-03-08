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
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for CompanyUC.xaml
    /// </summary>
    public partial class CompanyUC : UserControl
    {
        CompanyVM companyVM = new CompanyVM();
        private bool userControlHasFocus;

        public CompanyUC()
        {
            InitializeComponent();
            this.DataContext = companyVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tanımlısirketler, "Tanımlı Firmalar", PrintUtils.PDF, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tanımlısirketler, "Tanımlı Firmalar", PrintUtils.Excel, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void fillcurrentdata()
        {
            companyVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
            companyVM.Currentdata.Companyname = gridhedef.GetFocusedRowCellDisplayText("CN").ToString();
            companyVM.Currentdata.Companyadress = gridhedef.GetFocusedRowCellDisplayText("CA").ToString();
            companyVM.Currentdata.Taxname = gridhedef.GetFocusedRowCellDisplayText("TNAME").ToString();
            companyVM.Currentdata.Taxno = gridhedef.GetFocusedRowCellDisplayText("TN").ToString();
        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {            
            if (UserUtils.Authority.Contains(UserUtils.Firma_güncelle))
            {
                fillcurrentdata();
                kayıtekrantext.Text = "FİRMALAR > Güncelle";
                btngüncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 21)
                {
                    companyVM.Loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<CompanyUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "FİRMALAR";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_güncelle))
            {
                if (companyVM.Update())
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
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_ekle))
            {
                companyVM.Currentdata = new Model.CompanyModel();
                kayıtekrantext.Text = "FİRMALAR > Yeni Kayıt";
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_Sil))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (companyVM.Delete())
                    {
                        LogVM.displaypopup("INFO", "Silme Tamamlandı");
                        //MessageBox.Show("Silme Tamamlandı", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silme Başarısız", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                         
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_Sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Firma_ekle))
            {
                if (companyVM.Save())
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
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Firma_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

