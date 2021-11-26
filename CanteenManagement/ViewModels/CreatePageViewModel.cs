using CanteenManagement.Models;
using CanteenManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    public class CreatePageViewModel : ICreatePageViewModel
    {
        public ICommand ChangePageCMD { get; set; }

        public CreatePageViewModel()
        {
            ChangePageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });
        }
    }
}
