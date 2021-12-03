using CanteenManagement.ViewModels;
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

namespace CanteenManagement.Views
{
    /// <summary>
    /// Interaction logic for LunchPageView.xaml
    /// </summary>
    public partial class LunchPageView : UserControl
    {
        private ILunchPageViewModel viewModel = null;
        public LunchPageView(ILunchPageViewModel iLunchPageViewModel)
        {
            viewModel = iLunchPageViewModel;
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
