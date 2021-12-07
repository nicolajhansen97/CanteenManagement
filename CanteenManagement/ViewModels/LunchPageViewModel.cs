﻿using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    class LunchPageViewModel : Bindable, ILunchPageViewModel
    {
        private ObservableCollection<Lunch> lunchList = LunchSingelton.getInstance();
        public ObservableCollection<Lunch> LunchList
        {
            get { return lunchList; }
            set { lunchList = value; propertyIsChanged(); }
        }
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

        private string mondayLunchTitle;
        public string MondayLunchTitle
        {
            get { return mondayLunchTitle; }
            set { mondayLunchTitle = value; propertyIsChanged(); }
        }

        private string tuesdayLunchTitle;
        public string TuesdayLunchTitle
        {
            get { return tuesdayLunchTitle; }
            set { tuesdayLunchTitle = value; propertyIsChanged(); }
        }

        private string wednesdayLunchTitle;
        public string WednesdayLunchTitle
        {
            get { return wednesdayLunchTitle; }
            set { wednesdayLunchTitle = value; propertyIsChanged(); }
        }

        private string thursdayLunchTitle;
        public string ThursdayLunchTitle
        {
            get { return thursdayLunchTitle; }
            set { thursdayLunchTitle = value; propertyIsChanged(); }
        }

        private string fridayLunchTitle;
        public string FridayLunchTitle
        {
            get { return fridayLunchTitle; }
            set { fridayLunchTitle = value; propertyIsChanged(); }
        }

        private string saturdayLunchTitle;
        public string SaturdayLunchTitle
        {
            get { return saturdayLunchTitle; }
            set { saturdayLunchTitle = value; propertyIsChanged(); }
        }

        private string sundayLunchTitle;
        public string SundayLunchTitle
        {
            get { return sundayLunchTitle; }
            set { sundayLunchTitle = value; propertyIsChanged(); }
        }

        private string mondayLunchDescription;
        public string MondayLunchDescription
        {
            get { return mondayLunchDescription; }
            set { mondayLunchDescription = value; propertyIsChanged(); }
        }

        private string tuesdayLunchDescription;
        public string TuesdayLunchDescription
        {
            get { return tuesdayLunchDescription; }
            set { tuesdayLunchDescription = value; propertyIsChanged(); }
        }

        private string wednesdayLunchDescription;
        public string WednesdayLunchDescription
        {
            get { return wednesdayLunchDescription; }
            set { wednesdayLunchDescription = value; propertyIsChanged(); }
        }

        private string thursdayLunchDescription;
        public string ThursdayLunchDescription
        {
            get { return thursdayLunchDescription; }
            set { thursdayLunchDescription = value; propertyIsChanged(); }
        }

        private string fridayLunchDescription;
        public string FridayLunchDescription
        {
            get { return fridayLunchDescription; }
            set { fridayLunchDescription = value; propertyIsChanged(); }
        }

        private string saturdayLunchDescription;
        public string SaturdayLunchDescription
        {
            get { return saturdayLunchDescription; }
            set { saturdayLunchDescription = value; propertyIsChanged(); }
        }

        private string sundayLunchDescription;
        public string SundayLunchDescription
        {
            get { return sundayLunchDescription; }
            set { sundayLunchDescription = value; propertyIsChanged(); }
        }


        //Used to store week and year values when you move between the weeks.
        public int yearSave = 0;
        public int weekSave = 0;

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

            getLunch();
          
        }



        /* Made by Nicolaj and Niels
         * 
         * Gets the current week. CultureInfo is to check what Calender is used. 
        */ 
        public int GetCurrentWeek()
        {
            
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int intWeekNumber = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            return intWeekNumber;
        }

        /* Made by Nicolaj and Niels
        * 
        * Is called first time you enter the view, to be sure that you always start on the current week.
       */
        public void AddYearAndUIWeeks()
        {
            int intWeekNumber = GetCurrentWeek();
            int intYear = DateTime.Now.Year;

            WeekNumber = "Current week: " + intWeekNumber;

            GetWeekDates(intYear, intWeekNumber);
        }

        /* Made by Nicolaj and Niels
        * 
        * Checks if the week is higher than the weeks each year. If its higher, it will add a year, and set the week to 0 again.
        * When its called again it will begin the new year and week 1. 
       */
        public void GetOtherWeeks()
        {
           
            if(weekSave > 51)
            {
                yearSave++;
                weekSave = 0;              
            }

            weekSave++;
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);

            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
        }

        /* Made by Nicolaj and Niels
        * 
        * Used ISOWeek to get the date of the Monday in a year and week given as a parameter.
        * Then all the other day is calculated just by adding 1 days for each day away from Monday.
        * The output for DateTime is yyyy:mm:dd hh:mm:ss, so delete the last 8 characters to remove the time.
       */
        public void GetWeekDates(int year, int week)
        {

            var mondayThisWeek = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
            
            string mondayRemoveHours = "Monday: " + mondayThisWeek.Date;
            mondayRemoveHours = mondayRemoveHours.Remove(mondayRemoveHours.Length -9, 9);
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

        async Task getLunch()
        {
            try
            {
                LunchList.Clear();

                HttpResponseMessage response = await ApiHelper.client.GetAsync(ApiHelper.serverUrl + ApiHelper.getLunch);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var lunch = JsonConvert.DeserializeObject<List<Lunch>>(responseBody);
                lunch.ForEach((l) => LunchList.Add(l));

                CheckDates();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CheckDates()
        {
            foreach (var item in LunchList)
            {

               string timefromDB = item.FldDate;
               timefromDB = timefromDB.Remove(timefromDB.Length - 9, 9);
               timefromDB = DateTime.ParseExact(timefromDB, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");


                if(MondayCurrentWeek.Contains(timefromDB))
                {
                    MondayLunchTitle = item.FldMenu;
                    MondayLunchDescription = item.FldMenuDescription;
                }
                else if(TuesdayCurrentWeek.Contains(timefromDB))
                {
                    TuesdayLunchTitle = item.FldMenu;
                    TuesdayLunchDescription = item.FldMenuDescription;
                }
                else if(WednesdayCurrentWeek.Contains(timefromDB))
                {
                    WednesdayLunchTitle = item.FldMenu;
                    WednesdayLunchDescription = item.FldMenuDescription;
                }
                else if (ThursdayCurrentWeek.Contains(timefromDB))
                {
                    ThursdayLunchTitle = item.FldMenu;
                    ThursdayLunchDescription = item.FldMenuDescription;
                }
                else if (FridayCurrentWeek.Contains(timefromDB))
                {
                    FridayLunchTitle = item.FldMenu;
                    FridayLunchDescription = item.FldMenuDescription;
                }
                else if (SaturdayCurrentWeek.Contains(timefromDB))
                {
                    SaturdayLunchTitle = item.FldMenu;
                    SaturdayLunchDescription = item.FldMenuDescription;
                }
                else if (SundayCurrentWeek.Contains(timefromDB))
                {
                    SundayLunchTitle = item.FldMenu;
                    SundayLunchDescription = item.FldMenuDescription;
                }
            }
        }
    }
}

