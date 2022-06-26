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

namespace StarNote.View.User
{
    /// <summary>
    /// Interaction logic for UsersUC.xaml
    /// </summary>
    public partial class UsersUC : UserControl
    {
        public UsersUC()
        {
            InitializeComponent();
        }

        private void Btnpdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (UserUtils.Authority.Contains(UserUtils.Kullanıcı_yazdırma))
            {
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.kullanıcılar, "Tanımlı Kullanıcılar ", PrintUtils.PDF, grdmain);
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
                PrintingRoute printingRoute = new PrintingRoute();
                PrintUtils.Print(printingRoute.kullanıcılar, "Tanımlı Kullanıcılar ", PrintUtils.Excel, grdmain);
            }
            else
            {
                MessageBox.Show("Kullanıcının bu işleme yetkisi yok", UserUtils.Kullanıcı_yazdırma, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Grdmain_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Isactive")
            {

                e.DisplayText = e.DisplayText + " TL";
            }
        }
    }
}
