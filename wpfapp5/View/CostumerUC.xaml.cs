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
    /// Interaction logic for CostumerUC.xaml
    /// </summary>
    public partial class CostumerUC : UserControl
    {
        CostumerVM costumerVM = new CostumerVM();
        private bool userControlHasFocus;

        public CostumerUC()
        {
            InitializeComponent();
            this.DataContext = costumerVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void fillcurrentdata()
        {
            costumerVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
            costumerVM.Currentdata.İsim = gridhedef.GetFocusedRowCellDisplayText("MA").ToString();
            costumerVM.Currentdata.Tckimlik = gridhedef.GetFocusedRowCellDisplayText("TC").ToString();
            costumerVM.Currentdata.Telefon = gridhedef.GetFocusedRowCellDisplayText("TEL").ToString();
            costumerVM.Currentdata.Eposta = gridhedef.GetFocusedRowCellDisplayText("MAIL").ToString();
            costumerVM.Currentdata.Şehir = gridhedef.GetFocusedRowCellDisplayText("ŞEHIR").ToString();
            costumerVM.Currentdata.İlçe = gridhedef.GetFocusedRowCellDisplayText("ILCE").ToString();
            costumerVM.Currentdata.Adres = gridhedef.GetFocusedRowCellDisplayText("ADRES").ToString();
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tanımlımüsteriter, "Tanımlı Müşteriler", PrintUtils.PDF, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.tanımlımüsteriter, "Tanımlı Müşteriler", PrintUtils.Excel, gridhedef);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_Güncelle))
            {
                fillcurrentdata();
                kayıtekrantext.Text = "MÜŞTERİLER > Güncelle";
                btngüncelle.Visibility = Visibility.Visible;
                btnkayıt.Visibility = Visibility.Hidden;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_Güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }           
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 22)
                {
                    costumerVM.Loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<CostumerUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "MÜŞTERİLER";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_Güncelle))
            {
                if (costumerVM.Update())
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_ekle))
            {
                costumerVM.Currentdata = new Model.CostumerModel();
                kayıtekrantext.Text = "MÜŞTERİLER > Yeni Kayıt";
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {           
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_sil))
            {
                string msg = " Kaydı silmek istiyor musunuz?";
                MessageBoxResult result = MessageBox.Show(msg, "Firma Silme ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fillcurrentdata();
                    if (costumerVM.Delete())
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Müşteri_ekle))
            {
                if (costumerVM.Save())
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Müşteri_ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

