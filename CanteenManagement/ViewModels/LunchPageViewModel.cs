using CanteenManagement.Models;
using CanteenManagement.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    class LunchPageViewModel : Bindable, ILunchPageViewModel
    {
        public ICommand ChangeToHomePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }

        public string WeekNumber { get; set; }

        public LunchPageViewModel()
        {
            ChangeToHomePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            LunchTest();
        }

        public int LunchTest()
        {
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int intWeekNumber = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                WeekNumber = "Current week: " + intWeekNumber;

                //MessageBox.Show(WeekNumber +" ");

                return intWeekNumber;
            }
        }

    
    }

}

