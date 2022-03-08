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
using System.IO;
using DevExpress.Xpf.Core.Serialization;

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

            restoreviews();
        }

        private void restoreviews()
        {
            FileInfo fi = new FileInfo("C:\\StarNote\\Templates\\gridstok.xml");
            if (fi.Exists)
            {
                gridstok.RestoreLayoutFromXml("C:\\StarNote\\Templates\\gridstok.xml");
            }
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
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.Diller, "Diller ", PrintUtils.PDF, gridstok);
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
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.Diller, "Diller", PrintUtils.Excel, gridstok);
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

        private bool savetemplate()
        {
            bool isok = false;
            try
            {
                foreach (GridColumn column in gridstok.Columns)
                    column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                gridstok.SaveLayoutToXml("C:\\StarNote\\Templates\\gridstok.xml");
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
