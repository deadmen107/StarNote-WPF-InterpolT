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
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for MontlyAnalysisUC.xaml
    /// </summary>
    public partial class MontlyAnalysisUC : UserControl
    {
        MontlyAnalysisVM analysisVM = new MontlyAnalysisVM();
        private bool userControlHasFocus;
        public MontlyAnalysisUC()
        {
            InitializeComponent();
            this.DataContext = analysisVM;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userControlHasFocus == true) { e.Handled = true; }
            else
            {
                userControlHasFocus = true;
                if (RefreshViews.pagecount == 11)
                {
                    analysisVM.Loaddata();
                }
            }

        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive));
            var parent = (focused_element as FrameworkElement).TryFindParent<MontlyAnalysisUC>();
            if (parent != this) userControlHasFocus = false;
        }
    }
}
