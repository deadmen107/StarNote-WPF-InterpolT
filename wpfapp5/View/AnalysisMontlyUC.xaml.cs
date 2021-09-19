using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for AnalysisMontlyUC.xaml
    /// </summary>
    public partial class AnalysisMontlyUC : UserControl
    {
        AnalysisMontlyVM analysisMontlyVM;
        private bool userControlHasFocus;

        public AnalysisMontlyUC()
        {
            InitializeComponent();
            analysisMontlyVM = new AnalysisMontlyVM();
            this.DataContext = analysisMontlyVM;
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            this.Language = XmlLanguage.GetLanguage("tr-TR");
            cd.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
            filtregünü.SelectedDate = DateTime.Now;
        }

        private void Grdsatıs_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {         
            if (e.DisplayText=="0")
            {
                e.DisplayText = "";
            }
            else
            {
                if (e.Column.FieldName != "ÜRÜN" && e.Column.FieldName != "ID")
                {
                    e.DisplayText = e.DisplayText + "₺";
                }           
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 11)
                {
                    analysisMontlyVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
                }
            }
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<AnalysisMontlyUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Filtregünü_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RefreshViews.appstatus)
            analysisMontlyVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_Analiz_yazdırma))
            {
                try
                {
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Aylık Analiz Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.AnalysisMontly;
                    if (printingRoute.AnalysisMontly == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);                      
                    }
                    else
                    {
                        msg += " dizinine Aylık Analiz Raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdsatıs.View) { Landscape = true });
                            links[0].ExportToPdf(printingRoute.AnalysisMontly + "\\Aylık Analiz Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf");
                            //links[0].CreateDocument(false);
                            //links[0].PageHeaderTemplate = (DataTemplate)Resources["PageHeader"];
                            //links[0].PageFooterTemplate = (DataTemplate)Resources["PageFooter"];
                            //DocumentPreviewWindow wnd = new DocumentPreviewWindow();
                            //wnd.PreviewControl.DocumentSource = links[0];
                            //links[0].CreateDocument();
                            //wnd.Show();
                            //links[0].PrintingSystem.Document.Pages.AddRange(links[1].PrintingSystem.Document.Pages);
                            //PrintHelper.ShowRibbonPrintPreview(this, links[0]);
                            //Export the document to the file:
                            //tablesatıs.ExportToPdf(printingRoute.AnalysisMontly + "\\Aylık Analiz Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".pdf",options);
                        }
                    }
                }
                catch (Exception ex)
                {

                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Aylık Analiz Rapor hatası ", ex.Message);
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                }

            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_Analiz_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_Analiz_yazdırma))
            {
                string RaporAdı = "Aylık Analiz";
                try
                {
                   
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", RaporAdı+ "Rapor İsteği alındı", "");
                    PrintingRoute printingRoute = new PrintingRoute();
                    string msg = string.Empty;
                    msg += printingRoute.AnalysisMontly;
                    if (printingRoute.AnalysisMontly == "")
                    {
                        MessageBox.Show("Geçerli bir dosya yolu yok", "Dosya Yazdırma Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        msg += " dizinine "+RaporAdı+ " Raporunu çıkartmak istiyor musunuz?";
                        MessageBoxResult result = MessageBox.Show(msg, "PDF Rapor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<TemplatedLink> links = new List<TemplatedLink>();
                            links.Add(new PrintableControlLink((TableView)grdsatıs.View) { Landscape = true });
                            links[0].ExportToXlsx(printingRoute.AnalysisMontly + "\\"+ RaporAdı + " Raporu " + DateTime.Now.ToString("dd MM yyyy HH mm") + ".xlsx");                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogVM.displaypopup("ERROR", "Rapor Yazdırma başarısız.");
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", RaporAdı+"Rapor hatası ", ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_Analiz_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }   
}
