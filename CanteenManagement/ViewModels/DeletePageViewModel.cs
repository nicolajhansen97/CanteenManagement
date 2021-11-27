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
    public class DeletePageViewModel : IDeletePageViewModel
    {
        public ICommand ChangePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }

        public DeletePageViewModel()
        {
            ChangePageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });
        }
    }
}
