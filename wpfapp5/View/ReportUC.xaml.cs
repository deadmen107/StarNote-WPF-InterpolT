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

namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for ReportUC.xaml
    /// </summary>
    public partial class ReportUC : Window
    {       
        List<MainModel> list = new List<MainModel>();
        string ftpfilename;
        public ReportUC(DevExpress.XtraReports.IReport report,List<MainModel> mainlist,string filename)
        {            
            InitializeComponent();   
           
            documentview.DocumentSource = report;
            list = mainlist;
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
                string folderpath = list[0].Tür + "/" + list[0].Firmaadı;
                if (fileUtils.SaveFile(folderdesktoppath, folderpath, filenameforftp))
                {
                    if (fileUtils.deletefile(folderdesktoppath))
                    {
                        FilemanagementModel filemanagementModel = new FilemanagementModel();

                        filemanagementModel.Id = 0;
                        filemanagementModel.Dosyaadı = filenameforftp;
                        filemanagementModel.Firmadı = list[0].Firmaadı;
                        filemanagementModel.Türadı = list[0].Tür;
                        filemanagementModel.Müşteriadı = list[0].İsim;
                        filemanagementModel.İşemrino = list[0].Joborder;
                        filemanagementModel.Kayıtdetay = list[0].Kayıtdetay;
                        filemanagementModel.Mainid = list[0].Id;
                        filemanagementModel.Türdetay = list[0].Türdetay;

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


