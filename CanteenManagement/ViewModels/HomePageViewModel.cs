﻿using CanteenManagement.Models;
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
    public class HomePageViewModel : IHomePageViewModel
    {
        public ICommand ChangePageCMD { get; set; }

        public HomePageViewModel()
        {
            ChangePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<CreatePageView>());
            });
        }
    }

}
