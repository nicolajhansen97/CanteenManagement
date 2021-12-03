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
        public string MondayCurrentWeek { get; set; }
        public string TuesdayCurrentWeek { get; set; }
        public string WednesdayCurrentWeek { get; set; }
        public string ThursdayCurrentWeek { get; set; }
        public string FridayCurrentWeek { get; set; }
        public string SaturdayCurrentWeek { get; set; }
        public string SundayCurrentWeek { get; set; }

        public LunchPageViewModel()
        {
            ChangeToHomePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            GetCurrentWeek();
        }

        public void GetCurrentWeek()
        {
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int intWeekNumber = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                int intYear = DateTime.Now.Year;

                WeekNumber = "Current week: " + intWeekNumber;

                GetWeekDates(intYear, intWeekNumber);
            }
        }

        public void GetWeekDates(int year, int week)
        {

            var mondayThisWeek = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
            
            string mondayRemoveHours = "Monday: " + mondayThisWeek.Date;
            mondayRemoveHours = mondayRemoveHours.Remove(mondayRemoveHours.Length-8, 8);
            MondayCurrentWeek = mondayRemoveHours;

            string tuesdayRemoveHours = "Tuesday: " + mondayThisWeek.AddDays(1).Date;
            tuesdayRemoveHours = tuesdayRemoveHours.Remove(tuesdayRemoveHours.Length - 8, 8);
            TuesdayCurrentWeek = tuesdayRemoveHours;

            string wednesdayRemoveHours = "Wednesday: " + mondayThisWeek.AddDays(2).Date;
            wednesdayRemoveHours = wednesdayRemoveHours.Remove(wednesdayRemoveHours.Length - 8, 8);
            WednesdayCurrentWeek = wednesdayRemoveHours;

            string thursdayRemoveHours = "Thursday: " + mondayThisWeek.AddDays(3).Date;
            thursdayRemoveHours = thursdayRemoveHours.Remove(thursdayRemoveHours.Length - 8, 8);
            ThursdayCurrentWeek = thursdayRemoveHours;

            string fridayRemoveHours = "Friday: " + mondayThisWeek.AddDays(4).Date;
            fridayRemoveHours = fridayRemoveHours.Remove(fridayRemoveHours.Length - 8, 8);
            FridayCurrentWeek = fridayRemoveHours;

            string saturdayRemoveHours = "Saturday: " + mondayThisWeek.AddDays(5).Date;
            saturdayRemoveHours = saturdayRemoveHours.Remove(saturdayRemoveHours.Length - 8, 8);
            SaturdayCurrentWeek = saturdayRemoveHours;

            string sundayRemoveHours = "Sunday: " + mondayThisWeek.AddDays(6).Date;
            sundayRemoveHours = sundayRemoveHours.Remove(sundayRemoveHours.Length - 8, 8);
            SundayCurrentWeek = sundayRemoveHours;

        }


    }

}

