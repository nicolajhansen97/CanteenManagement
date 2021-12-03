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
        public ICommand ChangeWeekCMD { get; set; }

        private string weekNumber;
        public string WeekNumber
        {
            get { return weekNumber; }
            set { weekNumber = value; propertyIsChanged(); }
        }

        private string mondayCurrentWeek;
        public string MondayCurrentWeek { 
            get { return mondayCurrentWeek; } 
            set { mondayCurrentWeek = value; propertyIsChanged(); }
        }
        private string tuesdayCurrentWeek;
        public string TuesdayCurrentWeek
        {
            get { return tuesdayCurrentWeek; }
            set { tuesdayCurrentWeek = value; propertyIsChanged(); }
        }
        private string wednesdayCurrentWeek;
        public string WednesdayCurrentWeek
        {
            get { return wednesdayCurrentWeek; }
            set { wednesdayCurrentWeek = value; propertyIsChanged(); }
        }
        private string thursdayCurrentWeek;
        public string ThursdayCurrentWeek
        {
            get { return thursdayCurrentWeek; }
            set { thursdayCurrentWeek = value; propertyIsChanged(); }
        }
        private string fridayCurrentWeek;
        public string FridayCurrentWeek
        {
            get { return fridayCurrentWeek; }
            set { fridayCurrentWeek = value; propertyIsChanged(); }
        }
        private string saturdayCurrentWeek;
        public string SaturdayCurrentWeek
        {
            get { return saturdayCurrentWeek; }
            set { saturdayCurrentWeek = value; propertyIsChanged(); }
        }
        private string sundayCurrentWeek;
        public string SundayCurrentWeek
        {
            get { return sundayCurrentWeek; }
            set { sundayCurrentWeek = value; propertyIsChanged(); }
        }

        public int yearSave = 0;
        public int weekSave = 0;
        public bool gotCurrentWeek;

        public LunchPageViewModel()
        {
            ChangeToHomePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            ChangeWeekCMD = new RelayCommand(() => {
                GetOtherWeeks();
            });
            weekSave = GetCurrentWeek();
            AddYearAndUIWeeks();
        }

        public int GetCurrentWeek()
        {
            
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int intWeekNumber = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            return intWeekNumber;
        }

        public void AddYearAndUIWeeks()
        {
            int intWeekNumber = GetCurrentWeek();
            int intYear = DateTime.Now.Year;

            WeekNumber = "Current week: " + intWeekNumber;

            GetWeekDates(intYear, intWeekNumber);
        }

        public void GetOtherWeeks()
        {
           
            if(weekSave > 52)
            {
                yearSave++;
                weekSave = 1;              
                
            }
            weekSave++;
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);
           // int calculatedYear = ;
            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
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

