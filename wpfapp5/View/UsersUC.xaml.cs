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
using StarNote.ViewModel;
using StarNote.Model;
using System.Windows.Threading;
using System.Threading;
using StarNote.Utils;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for UsersUC.xaml
    /// </summary>
    public partial class UsersUC : UserControl
    {
        UsersVM usersVM = new UsersVM();
        private bool userControlHasFocus;
     
        public UsersUC()
        {
            InitializeComponent();
            this.DataContext = usersVM;           
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 17)
                {
                    usersVM.Loaddata();
                }
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<UsersUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_Ekle))
            {
                usersVM.Currentdata = new Model.UsersModel();
                usersVM.Currentdata.Isactive = true;
                clearcheckedits();
                kayıtekrantext.Text = "Kullanıcılar > Yeni Kayıt";
                var converter = new System.Windows.GridLengthConverter();
                hesaprow.Height = (GridLength)converter.ConvertFromString("200");
                btngüncelle.Visibility = Visibility.Hidden;
                btnkayıt.Visibility = Visibility.Visible;
                tabcontrol.SelectedItem = tabgüncelleme;
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_Ekle, MessageBoxButton.OK, MessageBoxImage.Error);
            }                    
        }

        private void clearcheckedits()
        {
            CheckEdit[] checkEdits = new CheckEdit[]
            {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69
            };
            foreach (var checkedit in checkEdits)
            {
                checkedit.IsChecked = false;
            }

        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar  Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Kullanıcılar;
                    if (printingRoute.Kullanıcılar == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine Kullanıcılar raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdmain.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.Kullanıcılar + "\\Kullanıcılar " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Kullanıcılar Rapor alındı ", "");
                            //tablesatıs.ExportToPdf(printingRoute.MainGrid + "\\Genel Takip Raporu" + ".pdf");
                        }
                    }
                }

                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Kullanıcılar Rapor hatası ", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_yazdırma))
            {
                string RaporAdı = "Kullanıcılar";
                try
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı + "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.Kullanıcılar;
                    if (printingRoute.Kullanıcılar == "")
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
                            links.Add(new PrintableControlLink((TableView)grdmain.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.Kullanıcılar + "\\" + RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");
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
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void parseyetki()
        {
            CheckEdit[] checkEdits = new CheckEdit[]
              {
                 cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62
              };
            string Yetkitext = grdmain.GetFocusedRowCellDisplayText("Yetki");
            foreach (var item in checkEdits)
            {
                item.IsChecked = false;
            }
            if (Yetkitext!=""||Yetkitext!=string.Empty)
            {
                if (Yetkitext == "All")
                {
                    foreach (var item in checkEdits)
                    {
                        item.IsChecked = true;
                    }
                }
                else
                {
                    string[] yetkiler = Yetkitext.Split(',');
                    foreach (var checkboxes in checkEdits)
                    {
                        foreach (var yetki in yetkiler)
                        {
                            if (yetki == checkboxes.NullText.Replace('ı','i')||yetki==checkboxes.NullText.Replace('I','İ'))
                            {
                                checkboxes.IsChecked = true;
                            }
                        }
                    }
                }
            }           
        }

        private void fillcurrentdata()
        {
            usersVM.Currentdata.Id = Convert.ToInt32(grdmain.GetFocusedRowCellDisplayText("ID"));
            usersVM.Currentdata.İsim = grdmain.GetFocusedRowCellDisplayText("Name").ToString();
            usersVM.Currentdata.Soyisim = grdmain.GetFocusedRowCellDisplayText("Surname").ToString();
            usersVM.Currentdata.Kullanıcıadi = grdmain.GetFocusedRowCellDisplayText("User").ToString();
            usersVM.Currentdata.Kayıttarihi = grdmain.GetFocusedRowCellDisplayText("Regdate").ToString();
            usersVM.Currentdata.Mailadres = grdmain.GetFocusedRowCellDisplayText("Mail").ToString();
            usersVM.Currentdata.Isactive = Convert.ToBoolean(grdmain.GetFocusedRowCellValue("Isactive"));
            usersVM.Currentdata.Yetki = grdmain.GetFocusedRowCellDisplayText("Yetki").ToString();
        }

        private void TableAcik_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
           
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_Güncelle))
            {          
                fillcurrentdata();
                if (usersVM.Currentdata.Kullanıcıadi!="sys")
                {
                    parseyetki();
                    var converter = new System.Windows.GridLengthConverter();
                    hesaprow.Height = (GridLength)converter.ConvertFromString("100");
                    kayıtekrantext.Text = "Kullanıcılar > Güncelle";
                    btngüncelle.Visibility = Visibility.Visible;
                    btnkayıt.Visibility = Visibility.Hidden;
                    tabcontrol.SelectedItem = tabgüncelleme;
                }
                else
                {
                    MessageBox.Show("Admin kullanıcı güncellenemez", UserUtils.Kullanıcı_Güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
                }              
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_Güncelle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void Buttonvazgec_Click(object sender, RoutedEventArgs e)
        {
            kayıtekrantext.Text = "Kullanıcılar";
            tabcontrol.SelectedItem = tabtakip;
        }

        private void Btngüncelle_Click(object sender, RoutedEventArgs e)
        {           
            if (usersVM.Update())
            {
                tabcontrol.SelectedItem = tabtakip;
                MessageBox.Show("Güncelleme Tamamlandı", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Information);            
            }
            else
            {
                MessageBox.Show("Güncelleme Başarısız", "Kayıt Güncelleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }           
        }

        private void Cmb_yetki_Checked(object sender, RoutedEventArgs e)
        {
            int yetkicheckedcount = 0;
            string Yetkitext = "";            
            //UserUtils.Authority = new List<string>();
            CheckEdit[] checkEdits = new CheckEdit[] 
            {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69              
            };         
            for (int i = 0; i < checkEdits.Length; i++)
            {
                if (checkEdits[i].IsChecked == true)
                {
                    yetkicheckedcount++;
                    if (Yetkitext == string.Empty)                    
                        Yetkitext = checkEdits[i].NullText;                                         
                    else                                           
                        Yetkitext = Yetkitext + "," + checkEdits[i].NullText;
                    //UserUtils.Authority.Add(checkEdits[i].NullText);
                }           
            }
            if (yetkicheckedcount==checkEdits.Length)
            {
                Yetkitext = "All";
            }
            usersVM.Currentdata.Yetki = Yetkitext;           
        }

        private void Grdmain_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Isactive")
            {
                
                e.DisplayText = e.DisplayText + " TL";
            }
        }
        
        private void Btnsil_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_Sil))
            {
                fillcurrentdata();
                if (usersVM.Delete())
                {
                    MessageBox.Show("Silme Tamamlandı", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Information);
                    tabcontrol.SelectedItem = tabtakip;
                }
                else
                {
                    MessageBox.Show("Silme Başarısız", "Kayıt Silme", MessageBoxButton.OK, MessageBoxImage.Error);
                }              
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_Sil, MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }

        private void Btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            if (usersVM.Save())
            {
                tabcontrol.SelectedItem = tabtakip;
                MessageBox.Show("Kaydetme Tamamlandı", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);               
            }
            else
            {
                MessageBox.Show("Kaydetme Başarısız", "Kayıt Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Buttonallauthory_Click(object sender, RoutedEventArgs e)
        {
            CheckEdit[] checkEdits = new CheckEdit[]
             {
                cmb_1, cmb_2, cmb_3, cmb_4, cmb_5, cmb_6, cmb_7, cmb_8, cmb_9, cmb_10, cmb_11, cmb_12,
                cmb_13, cmb_14, cmb_15, cmb_16, cmb_17, cmb_18, cmb_19, cmb_20, cmb_21, cmb_22, cmb_23,
                cmb_24, cmb_25,cmb_26,cmb_27,cmb_28,cmb_29,cmb_30,cmb_31,cmb_32,cmb_33,cmb_34,cmb_35,cmb_36,cmb_37
                ,cmb_38,cmb_39,cmb_40,cmb_41,cmb_42,cmb_43,cmb_44,cmb_45,cmb_46,cmb_47,cmb_48,cmb_49,cmb_50,cmb_51,cmb_52
                ,cmb_53,cmb_54,cmb_55,cmb_56,cmb_57,cmb_58,cmb_59,cmb_60,cmb_61,cmb_62,cmb_63,cmb_64,cmb_65,cmb_66,cmb_67,cmb_68,cmb_69
             };
            foreach (var checkedit in checkEdits)
            {
                checkedit.IsChecked = true;
            }
        }
    }
}
