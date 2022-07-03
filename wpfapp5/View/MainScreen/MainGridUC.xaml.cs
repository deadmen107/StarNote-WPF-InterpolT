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
using StarNote.ViewModel;
using StarNote.Service;
using StarNote.Utils;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Services;
using DevExpress.Xpf.Editors.Validation.Native;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Grid;
using StarNote.Model;
using StarNote.Settings;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Utils;
using System.IO;

namespace StarNote.View.MainScreen
{
    /// <summary>
    /// Interaction logic for MainUC.xaml
    /// </summary>
    /// 

    public partial class MainGridUC : UserControl
    {
        public MainGridUC()
        {

            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            restoreviews();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!RefreshViews.appstatus)
            {
                try
                {
                    DXSplashScreen.Close();
                    LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", " --- PROGRAM AÇILIDI  ----", "");

                }
                catch (Exception)
                {

                }

                RefreshViews.appstatus = true;
            }

        }

        private void restoreviews()
        {
            //FileInfo fi = new FileInfo("C:\\StarNote\\Templates\\grddava.xml");
            //if (fi.Exists)
            //{
            //    grdmain.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grddava.xml");
            //}
            //fi = new FileInfo("C:\\StarNote\\Templates\\grdözel.xml");
            //if (fi.Exists)
            //{
            //    grdmain1.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grdözel.xml");
            //}
            //fi = new FileInfo("C:\\StarNote\\Templates\\grdfirma.xml");
            //if (fi.Exists)
            //{
            //    grdmain2.RestoreLayoutFromXml("C:\\StarNote\\Templates\\grdfirma.xml");
            //}

        }

        private void Btnbildiriücret_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            //{

            //    DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
            //    fillcurrentdata(barButton.Tag.ToString());
            //    if (ViewModel.Createfile(ViewModel.Currentdata, 1))
            //    {
            //        tabcontrol.SelectedItem = grid;
            //        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
            //        //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
            //    }
            //    else
            //    {
            //        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
            //        LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            //        MessageBox.Show("Dosya Yükleme Başarısız", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            //}
        }

        private void Btntercümerapor_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //if (UserUtils.Authority.Contains(UserUtils.Dosya_Kayıt_Oluşturma))
            //{
            //    DevExpress.Xpf.Bars.BarButtonItem barButton = sender as DevExpress.Xpf.Bars.BarButtonItem;
            //    fillcurrentdata(barButton.Tag.ToString());
            //    if (ViewModel.Createfile(ViewModel.Currentdata, 0))
            //    {
            //        tabcontrol.SelectedItem = grid;
            //        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Dosya Oluşturma Tamamlandı", "");
            //        //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);                
            //    }
            //    else
            //    {
            //        LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Dosya Yükleme Başarısız", "");
            //        LogVM.displaypopup("ERROR", "Dosya Yükleme Başarısız");
            //    }
            //}
            //else
            //{
            //    LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            //}
        }

        private void Btndosyasec_Click(object sender, RoutedEventArgs e)
        {
            //string oSelectedFile = "";
            //System.Windows.Forms.OpenFileDialog oDlg = new System.Windows.Forms.OpenFileDialog();
            //if (System.Windows.Forms.DialogResult.OK == oDlg.ShowDialog())
            //{
            //    oSelectedFile = oDlg.FileName;
            //    string[] forname = oSelectedFile.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            //    LocalfileModel localfile = new LocalfileModel()
            //    {
            //        Id = ViewModel.Localfilelist.Count + 1,
            //        Dosya = oDlg.FileName,
            //        Klasöradı = ViewModel.Klasöradıtxt,
            //        Durum = FileUtils.hazır,
            //        Mainid = 0
            //    };
            //    ViewModel.Localfilelist.Add(localfile);
            //    grdlocalfile.RefreshData();
            //    özelgrdlocalfile.RefreshData();
            //    firmagrdlocalfile.RefreshData();
            //}
        }

        private void Grdlocalfile_Drop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    // Note that you can have more than one file.
            //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //    foreach (var file in files)
            //    {
            //        LocalfileModel localfile = new LocalfileModel()
            //        {
            //            Id = ViewModel.Localfilelist.Count + 1,
            //            Dosya = file,
            //            Durum = FileUtils.hazır,
            //            Klasöradı = ViewModel.Klasöradıtxt,
            //            Mainid = 0
            //        };
            //        ViewModel.Localfilelist.Add(localfile);
            //        LogVM.displaypopup("INFO", "Dosya Eklendi");
            //        grdlocalfile.RefreshData();
            //        özelgrdlocalfile.RefreshData();
            //        firmagrdlocalfile.RefreshData();

            //    }
            //}
        }

        
        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            //string tag = btn.Tag.ToString();
            //if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            //{
            //    PrintingRoute printingRoute = new PrintingRoute();
            //    if (tag == "0")
            //    {
            //        PrintUtils.Print(printingRoute.Adliye, "Adliye Kayıtları", PrintUtils.PDF, grdmain);
            //    }
            //    else if (tag == "1")
            //    {
            //        PrintUtils.Print(printingRoute.Özel, "Özel Müşteri Kayıtları", PrintUtils.PDF, grdmain1);
            //    }
            //    else if (tag == "2")
            //    {
            //        PrintUtils.Print(printingRoute.Firma, "Firma Kayıtları", PrintUtils.PDF, grdmain2);
            //    }
            //    else if (tag == "3")
            //    {
            //        PrintUtils.Print(printingRoute.Harcama, "Harcama Kayıtları", PrintUtils.PDF, grdmain3);
            //    }
            //}
            //else
            //{
            //    LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            //}

        }

        private void Btnxcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            //string tag = btn.Tag.ToString();
            //if (UserUtils.Authority.Contains(UserUtils.Geneltakip_yazdırma))
            //{
            //    PrintingRoute printingRoute = new PrintingRoute();
            //    if (tag == "0")
            //    {
            //        PrintUtils.Print(printingRoute.Adliye, "Adliye Kayıtları", PrintUtils.Excel, grdmain);
            //    }
            //    else if (tag == "1")
            //    {
            //        PrintUtils.Print(printingRoute.Özel, "Özel Müşteri Kayıtları", PrintUtils.Excel, grdmain1);
            //    }
            //    else if (tag == "2")
            //    {
            //        PrintUtils.Print(printingRoute.Firma, "Firma Kayıtları", PrintUtils.Excel, grdmain2);
            //    }
            //    else if (tag == "3")
            //    {
            //        PrintUtils.Print(printingRoute.Harcama, "Harcama Kayıtları", PrintUtils.Excel, grdmain3);
            //    }
           // }
            //else
            //{
            //    LogVM.displaypopup("ERROR", "Kullanıcının bu işleme yetkisi yok");
            //}

        }


        private bool savetemplate(string templatename)
        {
            bool isok = false;
            try
            {

                //if (templatename == "0")
                //{
                //    foreach (GridColumn column in grdmain.Columns)
                //        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                //    grdmain.SaveLayoutToXml("C:\\StarNote\\Templates\\grddava.xml");
                //}
                //else if (templatename == "1")
                //{
                //    foreach (GridColumn column in grdmain1.Columns)
                //        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                //    grdmain1.SaveLayoutToXml("C:\\StarNote\\Templates\\grdözel.xml");
                //}
                //else if (templatename == "2")
                //{
                //    foreach (GridColumn column in grdmain2.Columns)
                //        column.AddHandler(DXSerializer.AllowPropertyEvent, new AllowPropertyEventHandler(column_AllowProperty));
                //    grdmain2.SaveLayoutToXml("C:\\StarNote\\Templates\\grdfirma.xml");
                //}

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
            DevExpress.Xpf.Bars.BarButtonItem btn = sender as DevExpress.Xpf.Bars.BarButtonItem;
            savetemplate(btn.Tag.ToString());
        }






    }

}
