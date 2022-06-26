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
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Printing.PreviewControl;
using StarNote.Model;
using StarNote.Utils;
using StarNote.ViewModel;

namespace StarNote.View.Common
{
    /// <summary>
    /// Interaction logic for ReportUC.xaml
    /// </summary>
    public partial class ReportUC : Window
    {       
        OrderModel mainmodel = new OrderModel();
        string ftpfilename;
        public ReportUC(DevExpress.XtraReports.IReport report,OrderModel model,string filename)
        {            
            InitializeComponent();   
           
            documentview.DocumentSource = report;
            mainmodel = model;
            ftpfilename = filename;
            PrintingLocalizer.Active = new TurkishFiltersLocalizer1();            
         
        }

        private void Buttonyenikayıt_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "Rapor oluşturuluyor", "");
                documentview.Export(DevExpress.XtraPrinting.ExportFormat.Pdf);
                FileUtils fileUtils = new FileUtils();
                string filenameforftp = ftpfilename;
                string folderdesktoppath = System.Environment.CurrentDirectory + "\\" + filenameforftp;
                string folderpath = mainmodel.Costumerorder.Id + "/" + "Starnote";
                if (fileUtils.SaveFile(folderdesktoppath, folderpath, filenameforftp))
                {
                    if (fileUtils.deletefile(folderdesktoppath))
                    {
                        FilemanagementModel filemanagementModel = new FilemanagementModel();

                        filemanagementModel.Id = 0;
                        filemanagementModel.Dosyaadı = filenameforftp;
                        filemanagementModel.Firmadı = mainmodel.Costumerorder.Firmaadı;
                        filemanagementModel.Türadı = mainmodel.Costumerorder.Tür;
                        filemanagementModel.Müşteriadı = mainmodel.Costumerorder.İsim;
                        filemanagementModel.Klasörno = "Starnote";
                        filemanagementModel.Kayıtdetay = mainmodel.Costumerorder.Kayıtdetay;
                        filemanagementModel.Mainid = mainmodel.Costumerorder.Id;
                        filemanagementModel.Türdetay = mainmodel.Costumerorder.Türdetay;

                        fileUtils.filltable(filemanagementModel);                    
                        this.Close();
                        LogVM.displaypopup("INFO", "Dosya Yükleme Tamamlandı");
                        //MessageBox.Show("Dosya Yükleme Tamamlandı", "Dosya Ekleme", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogVM.Addlog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, "ERROR", "Rapor oluşturma hatası", ex.Message);
            }
          
        }
    }
}

public class TurkishFiltersLocalizer1 : PrintingLocalizer
{
    protected override void PopulateStringTable()
    {
        base.PopulateStringTable();
        
        // Changes the caption of the menu item used to invoke the Total Summary Editor.
        AddString(PrintingStringId.Parameters, "Parametreler");
        AddString(PrintingStringId.ParametersReset, "Sıfırla");
        // Changes the Total Summary Editor's default caption.
        AddString(PrintingStringId.ParametersSubmit, "Raporu Oluştur");
        // Changes the default caption of the tab page that lists total summary items.     
    }
}


