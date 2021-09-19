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
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for PrintingUC.xaml
    /// </summary>
    public partial class PrintingUC : UserControl
    {
        PrintingVM printingVM = new PrintingVM();
        private bool userControlHasFocus;

        public PrintingUC()
        {
            InitializeComponent();
           
            this.DataContext = printingVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Dosya_Yolu_Düzenle))
            {
                printingVM.Currentdata.Id = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("ID"));
                printingVM.Currentdata.Rapor = gridhedef.GetFocusedRowCellDisplayText("HA").ToString();
                printingVM.Currentdata.Dosyayolu = gridhedef.GetFocusedRowCellDisplayText("HM");
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Dosya_Yolu_Düzenle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 15)
                {
                    printingVM.loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<PrintingUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Dosyayolusec_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog())
            {
                dlg.Description = "Rapor Dosya Yolu Seç";
                dlg.SelectedPath = string.Empty;
                dlg.ShowNewFolderButton = true;
                System.Windows.Forms.DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (dlg.SelectedPath!=string.Empty)
                    {
                        dosyayolu.Text = dlg.SelectedPath;
                        printingVM.Currentdata.Dosyayolu = dlg.SelectedPath;
                    }                              
                }
            }
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (printingVM.Update())
            {
                tabcontrol.SelectedItem = tabtakip;
                //MessageBox.Show("Güncelleme Tamamlandı", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Information);
                LogVM.displaypopup("INFO", "Güncelleme Tamamlandı");
            }
            else
            {
                MessageBox.Show("Güncelleme Başarısız", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
           
        }
    }
}

    

