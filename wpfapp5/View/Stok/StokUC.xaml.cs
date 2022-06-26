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

namespace StarNote.View.Stok
{
    /// <summary>
    /// Interaction logic for StokUC.xaml
    /// </summary>
    public partial class StokUC : UserControl
    {
        public StokUC()
        {
            InitializeComponent();
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
