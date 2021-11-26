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
using CanteenManagement.ViewModels;

namespace CanteenManagement.Views
{
    /// <summary>
    /// Interaction logic for CreatePageView.xaml
    /// </summary>
    public partial class CreatePageView : UserControl
    {
        private ICreatePageViewModel viewModel = null;
        public CreatePageView(ICreatePageViewModel icreatPageViewModel)
        {
            viewModel = icreatPageViewModel;
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
