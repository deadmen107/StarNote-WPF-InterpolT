﻿using System;
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
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for AnalysisYearlyUC.xaml
    /// </summary>
    public partial class AnalysisYearlyUC : UserControl
    {
        AnalysisYearlyVM analysisYearlyVM;
        private bool userControlHasFocus;

        public AnalysisYearlyUC()
        {
            InitializeComponent();
            analysisYearlyVM = new AnalysisYearlyVM();
            this.DataContext = analysisYearlyVM;
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            this.Language = XmlLanguage.GetLanguage("tr-TR");
            cd.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
            filtregünü.SelectedDate = DateTime.Now;
        }

        private void Grdsatıs_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            if (e.DisplayText == "0")
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
                if (RefreshViews.pagecount == 12)
                {
                    analysisYearlyVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<AnalysisYearlyUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Filtregünü_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RefreshViews.appstatus)
                analysisYearlyVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Yıllık_Analiz_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.yıllıkizanaliz, "Yllık İş Analizi ", PrintUtils.PDF, grdsatıs);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Yıllık_Analiz_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Yıllık_Analiz_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.yıllıkizanaliz, "Yllık İş Analizi ", PrintUtils.Excel, grdsatıs);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Yıllık_Analiz_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


