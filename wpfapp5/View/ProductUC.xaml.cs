using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
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

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        ProductVM productVM = new ProductVM();

        public ProductUC()
        {
            InitializeComponent();
            this.DataContext = productVM;
            tabcontrol.SelectedItem = tabtakip;
        }
        
        private bool userControlHasFocus;
        
        private void fillcurrentdata()
        {
            productVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
            productVM.Currentdata.Parameter = gridhedef.GetFocusedRowCellDisplayText("GA").ToString();
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.belgeler, "Belgeler", PrintUtils.PDF, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.belgeler, "Belgeler", PrintUtils.Excel, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_Güncelle))
            {
                productVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
                productVM.Currentdata.Parameter = gridhedef.GetFocusedRowCellDisplayText("GA").ToString();
                kayıtekrantext.Text = "Belgeler > Güncelle";
                btngüncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 24)
                {
                    productVM.Loaddata();
                }
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<ProductUC>();
            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Belgeler";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (productVM.Update())
            {
                tabcontrol.SelectedItem = tabtakip;
                 LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
                //MessageBox.Show("Kaydetme Güncelleme", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Information);              
            }
            else
            {
                MessageBox.Show("Kaydetme Güncelleme", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }         
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Üründetay_Ekle))
            {
                productVM.Currentdata = new Model.ParameterModel();
                kayıtekrantext.Text = "Belgeler > Yeni Kayıt";
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_Sil))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (productVM.Delete())
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (productVM.Save())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Kayıt Tamamlandı");
                //MessageBox.Show("Kaydetme Tamamlandı", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

    }
}
