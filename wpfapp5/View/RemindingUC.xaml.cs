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
    /// Interaction logic for RemindingUC.xaml
    /// </summary>
    public partial class RemindingUC : UserControl
    {
        RemindingVM remindingVM = new RemindingVM();
        private bool userControlHasFocus;

        public RemindingUC()
        {
            InitializeComponent();
            this.DataContext = remindingVM;
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Tür_Yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Tür;
                    if (printingRoute.Tür == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Günlük Satın Alma raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)gridhedef.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.Tür + "\\Tür " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Tür Rapor alındı ", "");
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Tür Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Tür_Yazdırma))
            {
                string RaporAdı = "Tür";
                try
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Tür;
                    if (printingRoute.Tür == "")
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
                            links.Add(new PrintableControlLink((TableView)gridhedef.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.Tür + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Tür_Yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            remindingVM.Currentdata.ID = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("1"));
            remindingVM.Currentdata.Anakayıtid = Convert.ToInt32(gridhedef.GetFocusedRowCellDisplayText("2").ToString());
            remindingVM.Currentdata.AnaKayıt = gridhedef.GetFocusedRowCellDisplayText("3").ToString();
            remindingVM.Currentdata.AnaKayıtdetay = gridhedef.GetFocusedRowCellDisplayText("4").ToString();
            remindingVM.Currentdata.Hatırlatmatipi = gridhedef.GetFocusedRowCellDisplayText("5").ToString();
            remindingVM.Currentdata.Hatırlatmamesajı = gridhedef.GetFocusedRowCellDisplayText("6").ToString();           
            remindingVM.Currentdata.Hatırlatmadurumu = gridhedef.GetFocusedRowCellDisplayText("7").ToString();           
            kayıtekrantext.Text = "Hatırlatmalar > Güncelle";
            btngüncelle.Visibility = Visibility.Visible;
            btnkayıt.Visibility = Visibility.Hidden;
            tabcontrol.SelectedItem = tabgüncelleme;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 4)
                {
                     remindingVM.Loaddata();
                    tabcontrol.SelectedItem = tabtakip;
                }
                if (RefreshViews.pagecount == 5)
                {
                    remindingVM.Loaddata();
                    tabcontrol.SelectedItem = tabold;
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<RemindingUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Hatırlatmalar";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (remindingVM.Update())
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
            remindingVM.Currentdata = new Model.RemindingModel();
            kayıtekrantext.Text = "Hatırlatmalar > Yeni Kayıt";

            btngüncelle.Visibility = Visibility.Hidden;
            btnkayıt.Visibility = Visibility.Visible;
            tabcontrol.SelectedItem = tabgüncelleme;
        }

        private void Txtdosyano_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {          
            try
            {
                string[] parsedstr = txtdosyano.Text.Split('-');
                int value = 0;
                if (int.TryParse(parsedstr[0], out value))
                {
                    remindingVM.Currentdata.Anakayıtid = Convert.ToInt32(parsedstr[0]);
                    remindingVM.Getselectedmainrecord(Convert.ToInt32(parsedstr[0]));
                    txtdetay.Text = "";
                    txtdetay.Text += "Tür adı:";
                    txtdetay.Text += remindingVM.MainModel.Tür+" - ";
                    txtdetay.Text += "  Dosya no:";
                    txtdetay.Text += remindingVM.MainModel.Joborder + " - ";
                    txtdetay.Text += "  Müşteri:";
                    txtdetay.Text += remindingVM.MainModel.İsim + " - ";
                    txtdetay.Text += "  Firma:";
                    txtdetay.Text += remindingVM.MainModel.Firmaadı + " - ";
                    txtdetay.Text += "  Ürün:";
                    txtdetay.Text += remindingVM.MainModel.Ürün + " - ";
                    txtdetay.Text += "  Ürün Detay:";
                    txtdetay.Text += remindingVM.MainModel.Ürün2 + " - ";
                    txtdetay.Text += "  Ödeme Yöntem:";
                    txtdetay.Text += remindingVM.MainModel.Ödemeyöntemi + " - ";
                    txtdetay.Text += "  Kayıt Tarihi:";
                    txtdetay.Text += remindingVM.MainModel.Kayıttarihi + " - ";
                    txtdetay.Text += "  Randevu Tarihi:";
                    txtdetay.Text += remindingVM.MainModel.Randevutarihi + " - ";
                    txtdetay.Text += "  Durum:";
                    txtdetay.Text += remindingVM.MainModel.Durum + " - ";
                    txtdetay.Text += "  E-posta:";
                    txtdetay.Text += remindingVM.MainModel.Eposta + " - ";
                    txtdetay.Text += "  Tel No:";
                    txtdetay.Text += remindingVM.MainModel.Telefon;
                    remindingVM.Currentdata.AnaKayıtdetay = txtdetay.Text;
                    remindingVM.Getoldremindingsbyid(remindingVM.Currentdata.Anakayıtid);
                }
                else
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Parse int hatası ", "");
                }

            }
            catch (Exception)
            {
                txtdetay.Text = "";
            }
           
        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (remindingVM.Save())
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

       
    }
}
