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
using StarNote.ViewModel;
namespace StarNote.View
{
    /// <summary>
    /// Interaction logic for MontlyAnalysisUC.xaml
    /// </summary>
    public partial class MontlyAnalysisUC : UserControl
    {
        MontlyAnalysisVM analysisVM = new MontlyAnalysisVM();
        public MontlyAnalysisUC()
        {
            InitializeComponent();
            this.DataContext = analysisVM;
        }

    }
}
