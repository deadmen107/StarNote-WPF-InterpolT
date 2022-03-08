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
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for HedeflerUC.xaml
    /// </summary>
    public partial class SalesmanAdd : UserControl
    {
        SalesmanAddVM salesmanAddVM = new SalesmanAddVM();
        private bool userControlHasFocus;

        public SalesmanAdd()
        {
            InitializeComponent();
            this.DataContext = salesmanAddVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Satış_görevli_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tercümanlar, "Tanımlı Tercümanlar", PrintUtils.PDF, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Satış_görevli_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Satış_görevli_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tercümanlar, "Tanımlı Tercümanlar", PrintUtils.Excel, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Satış_görevli_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private void fillcurrentdata()
        {
            salesmanAddVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
            salesmanAddVM.Currentdata.Parameter = gridhedef.GetFocusedRowCellDisplayText("GA").ToString();
        }
        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Satış_görevli_güncelle))
            {
                fillcurrentdata();
                kayıtekrantext.Text = "Tercümanlar > Güncelle";
                btngüncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Satış_görevli_güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 3)
                {
                    salesmanAddVM.Loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<SalesmanAdd>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Satış Görevlileri";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (salesmanAddVM.Update())
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
            if (UserUtils.Authority.Contains(UserUtils.Satış_görevli_Ekle))
            {
                salesmanAddVM.Currentdata = new Model.ParameterModel();
                kayıtekrantext.Text = "Tercümanlar > Yeni Kayıt";
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Satış_görevli_Ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Satış_görevli_sil))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (salesmanAddVM.Delete())
                    {
                        tabcontrol.SelectedItem = tabtakip;
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Satış_görevli_sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (salesmanAddVM.Save())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Kaydetme Tamamlandı");                            
            }
            else
            {
                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
