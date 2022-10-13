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
    /// Interaction logic for ReportSettingsUC.xaml
    /// </summary>
    public partial class ReportSettingsUC : UserControl
    {
        ReportsettingsVM viewmodel = new ReportsettingsVM();
        private bool userControlHasFocus;

        public ReportSettingsUC()
        {
            InitializeComponent();
            this.DataContext = viewmodel;
            tabcontrol.SelectedItem = tabtakip;
        }
        private void fillcurrentdata()
        {
            viewmodel.Currentdata = viewmodel.List.FirstOrDefault(u => u.Id == Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID")));
        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.ÜrünDetay_Güncelle))
            {
                fillcurrentdata();
                kayıtekrantext.Text = "Rapor Ayarları > Güncelle";
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
            if (userControlHasFocus) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 31)
                {
                    viewmodel.Loaddata();
                }
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<ReportSettingsUC>();
            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Rapor Ayarları";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (viewmodel.Update())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
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
                viewmodel.Currentdata = new Model.ReportsettingModel();
                kayıtekrantext.Text = "Rapor Ayarları > Yeni Kayıt";
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
                MessageBoxResult result = MessageBox.Show(msg, "Rapor Ayarı Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (viewmodel.Delete())
                    {
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (viewmodel.Save())
            {
                tabcontrol.SelectedItem = tabtakip;
                LogVM.displaypopup("INFO", "Kayıt Tamamlandı");
            }
            else
            {
                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
