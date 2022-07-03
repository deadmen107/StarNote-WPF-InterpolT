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

namespace StarNote.View.MainScreen
{
    /// <summary>
    /// Interaction logic for MainScreenEditCompanyUC.xaml
    /// </summary>
    public partial class MainCompanyEditUC : UserControl
    {
        public MainCompanyEditUC()
        {
            InitializeComponent();
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
    }
}
