﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StarNote.Model;
using StarNote.Service;
using StarNote.Settings;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for MontlySalesUC.xaml
    /// </summary>
    public partial class MontlySalesUC : UserControl
    {
        MontlySalesVM montlySalesVM = new MontlySalesVM();
        private bool userControlHasFocus;
        private List<SettingModel> list = new List<SettingModel>();
        public MontlySalesUC()
        {
            InitializeComponent();
            this.DataContext = montlySalesVM;
            CultureInfo cd = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            this.Language = XmlLanguage.GetLanguage("tr-TR");
            cd.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            Thread.CurrentThread.CurrentCulture = cd;
            filtregünü.SelectedDate = DateTime.Now;
            restoreviews();
        }

        private void restoreviews()
        {
            FileInfo fi = new FileInfo("C:\\StarNote\\Templates\\grdaylıksatıs.xml");
            if (fi.Exists)
            {
                grdsatış.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grdaylıksatıs.xml");
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 10)
                {
                    montlySalesVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<MontlySalesUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Filtregünü_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RefreshViews.appstatus)
                montlySalesVM.loaddata(Convert.ToDateTime(filtregünü.Text).ToString("dd.MM.yyyy"));
        }
        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_Satış_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.aylıkgelir, "Aylık Gelirler", PrintUtils.PDF, grdsatış);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_Satış_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Aylık_Satış_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.aylıkgelir, "Aylık Gelirler", PrintUtils.Excel, grdsatış);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Aylık_Satış_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool savetemplate()
        {
            bool isok = false;
            try
            {
                foreach (GridColumn column in grdsatış.Columns)
                    column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                grdsatış.SaveLayoutToXml("C:\\StarNote\\Templates\\grdaylıksatıs.xml");
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
