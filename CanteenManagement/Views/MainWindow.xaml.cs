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
using CanteenManagement.Models;
using CanteenManagement.Views;
using Unity;

namespace CanteenManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((App)App.Current).ContentControlRef = this.mainContent;

            //((App)App.Current).ChangeUserControl(container.Resolve<BlueView>());
            ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());

            ApiHelper.InitializeClient();
        }
    }
}
