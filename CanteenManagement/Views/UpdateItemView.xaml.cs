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
    /// Interaction logic for UpdateItemViewModel.xaml
    /// </summary>
    public partial class UpdateItemView : UserControl
    {
        private IUpdateItemPageViewModel viewModel = null;
        public UpdateItemView(IUpdateItemPageViewModel iUpdateItemPageViewModel)
        {
            viewModel = iUpdateItemPageViewModel;
            this.DataContext = viewModel;

            InitializeComponent();
        }
    }
}

