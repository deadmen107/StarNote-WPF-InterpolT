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
using StarNote.Model;
using StarNote.Service;
using StarNote.Utils;
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for HedeflerUC.xaml
    /// </summary>
    public partial class LogUC : UserControl
    {
        LogVM logVM = new LogVM();
        private bool userControlHasFocus;

        public LogUC()
        {
            InitializeComponent();
            this.DataContext = logVM;
           
        }

       

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 16)
                {
                    logVM.loaddata();
                    tableAcik.MoveLastRow();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<LogUC>();

            if (parent != this) userControlHasFocus = false;
        }

        private void Btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "JOB BAŞLADI", "MANUEL");
            TokenModel tk = new TokenModel();
            tk = Task.Run(async () => await WebapiUtils.GetToken()).Result;
            WebapiUtils.access_token = tk.access_token;
            WebapiUtils.expires_in = tk.expires_in;
            WebapiUtils.token_type = tk.token_type;
            LogVM.Addlog("IJOBS", System.Reflection.MethodBase.GetCurrentMethod().Name, "INFO", "JOB TAMAMLANDI", "MANUEL");
        }

    }
}
