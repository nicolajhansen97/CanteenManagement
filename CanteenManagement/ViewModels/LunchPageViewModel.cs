﻿using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public class LunchPageViewModel : Bindable, ILunchPageViewModel
    {
        
        private ObservableCollection<Lunch> lunchList = LunchSingelton.getInstance();

        public ObservableCollection<Lunch> LunchList
        {
            get { return lunchList; }
            set { lunchList = value; propertyIsChanged(); }
        }
        public ICommand ChangeToHomePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }
        public ICommand ChangeWeekMinusCMD { get; set; }
        public ICommand ChangeWeekPlusCMD { get; set; }
        public ICommand SaveUpdateLunchCMD { get; set; }
        public ICommand FinalizeLunchCMD { get; set; }

        private string _mondayNumber;
        public string mondayNumber
        {
            get { return _mondayNumber; }
            set { _mondayNumber = value; propertyIsChanged(); }
        }
        private string _tuesdayNumber;
        public string tuesdayNumber
        {
            get { return _tuesdayNumber; }
            set { _tuesdayNumber = value; propertyIsChanged(); }
        }
        private string _wensdayNumber;
        public string wensdayNumber
        {
            get { return _wensdayNumber; }
            set { _wensdayNumber = value; propertyIsChanged(); }
        }
        private string _thursdayNumber;
        public string thursdayNumber
        {
            get { return _thursdayNumber; }
            set { _thursdayNumber = value; propertyIsChanged(); }
        }
        private string _fridayNumber;
        public string fridayNumber
        {
            get { return _fridayNumber; }
            set { _fridayNumber = value; propertyIsChanged(); }
        }
        private string _saturdayNumber;
        public string saturdayNumber
        {
            get { return _saturdayNumber; }
            set { _saturdayNumber = value; propertyIsChanged(); }
        }
        private string _sundayNumber;
        public string sundayNumber
        {
            get { return _sundayNumber; }
            set { _sundayNumber = value; propertyIsChanged(); }
        }

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
        public int yearSaveForFinal = 0;

        public LunchPageViewModel()
        {
            ChangeToHomePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            ChangeWeekMinusCMD = new RelayCommand(() => {
                GetOtherWeeksMinus();
            });

            ChangeWeekPlusCMD = new RelayCommand(() => {
                GetOtherWeeksPlus();
            });

            SaveUpdateLunchCMD = new RelayCommand(() =>
            {
                SaveAndUpdateLunch("save");
            });

            FinalizeLunchCMD = new RelayCommand(() =>
            {
                SaveAndUpdateLunch("final");
            });

            weekSave = GetCurrentWeek();
            AddYearAndUIWeeks();
            getLunch();

            Task.Run(async () => {
                //store lunchbooking in array
                LunchBookings = await GetNumberOfEmployeesLunchOrderDate();
                foreach (var item in LunchBookings)
                {
                    item.fldDate = item.fldDate.Replace("T00:00:00", "");
                }
                CalculateAmounteOfBookingForWeek(GetCurrentWeek(), DateTime.Now.Year);
            });
        }

        /// <summary>
        /// @author: Rasmus og Monir
        /// </summary>
        /// <param name="week"></param>
        /// <param name="year"></param>
        public void CalculateAmounteOfBookingForWeek(int week, int year)
        {
            //NEEDS TO BE MOVED DOWN TO OWN METHOD LATER
            //date to weeknumber
            List<string> weekDates = new List<string>(); 
            weekDates.AddRange(WeekPrior(year, week));

            for (int i = 0; i < weekDates.Count; i++)
            {
                string test = weekDates[i];
                int amount = CalcuateBookingsForDate(test, LunchBookings);
                //if / switch get week and day. input amount
                switch (i)
                {
                    case 0:
                        mondayNumber = amount+"";
                        break;
                    case 1:
                        tuesdayNumber = amount + "";
                        break;
                    case 2:
                        wensdayNumber = amount + "";
                        break;
                    case 3:
                        thursdayNumber = amount + "";
                        break;
                    case 4:
                        fridayNumber = amount + "";
                        break;
                    case 5:
                        saturdayNumber = amount + "";
                        break;
                    case 6:
                        sundayNumber = amount + "";
                        break;
                }
            }
        }

        /// <summary>
        /// @author: Rasmus og Monir
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lunchBookings"></param>
        /// <returns></returns>
        public int CalcuateBookingsForDate(string date,List<LunchBooking> lunchBookings)
        {
            int count = 0;
            foreach (var item in lunchBookings)
            {
                if (item.fldDate == date)
                {
                    count++;
                }
            }
            return count;
        } 

        public List<LunchBooking> LunchBookings = new List<LunchBooking>();

        /// <summary>
        /// @author: Rasmus og Monir
        /// </summary>
        /// <returns></returns>
        public async Task<List<LunchBooking>> GetNumberOfEmployeesLunchOrderDate()
        {
            //make api lunchbooking call
            List<LunchBooking> lunchBookings = new List<LunchBooking>();
            try
            {
                HttpResponseMessage response = await ApiHelper.client.GetAsync(ApiHelper.serverUrl + ApiHelper.getLunchBooking);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var lunchbooking = JsonConvert.DeserializeObject<List<LunchBooking>>(responseBody);

                foreach (var item in lunchbooking)
                {
                    lunchBookings.Add(new LunchBooking { fldLunchBookingID = item.fldLunchBookingID, fldEmployeeID = item.fldEmployeeID, fldDate = item.fldDate });
                }

                Task.WaitAll();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return await Task.FromResult(lunchBookings);
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

        /*
         * Made by Nicolaj and Niels
        * 
        * Checks if the week is higher than the weeks each year. If its higher, it will add a year, and set the week to 0 again.
        * When its called again it will begin the new year and week 1. 
       */
        public void GetOtherWeeksMinus()
        {
            if(weekSave < 2)
            {
                yearSave--;
                weekSave = 53;
            }        

            weekSave--;
            //MessageBox.Show("THis is weeksave -: " + weekSave);
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);


            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
            getLunch();
            CalculateAmounteOfBookingForWeek(weekSave, DateTime.Now.Year + yearSave);
        }

        /// <summary>
        /// Niels and Nicolaj
        /// Sets year and date to increase when the forward button is clicked
        /// </summary>
        public void GetOtherWeeksPlus()
        {
           
            if(weekSave > 51)
            {
                yearSave++;
                weekSave = 0;              
            }
            
           
            weekSave++;
            //MessageBox.Show("THis is weeksave +: " + weekSave);
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);
           

            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
            getLunch();
            CalculateAmounteOfBookingForWeek(weekSave, DateTime.Now.Year + yearSave);
        }

        /// <summary>
        /// @Niels and Nicolaj
        /// This is a repeat code that that makes sure to not change variable in the week and year count
        /// THis is something to be fixed later with more time, but it effects to many functions to fix now
        /// </summary>
        /// <returns name="tempWeek"></returns>
        public int SetWeekDown()
        {
            yearSaveForFinal = yearSave;
            int tempWeek = weekSave;
            if (weekSave < 2)
            {              
                yearSaveForFinal--;
                tempWeek = 52;
            }

            tempWeek--;
            return tempWeek;
        }

        /*
        * Made by Nicolaj and Niels
        * 
        * Used ISOWeek to get the date of the Monday in a year and week given as a parameter.
        * Then all the other day is calculated just by adding 1 days for each day away from Monday.
        * The output for DateTime is yyyy:mm:dd hh:mm:ss, so delete the last 8 characters to remove the time.
       */
        public void GetWeekDates(int year, int week)
        {

            var mondayThisWeek = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
            
            string mondayRemoveHours = mondayThisWeek.Date.ToString();
            mondayRemoveHours = mondayRemoveHours.Remove(mondayRemoveHours.Length -9, 9);
            MondayCurrentWeek = "Monday: " + mondayRemoveHours;
            

            string tuesdayRemoveHours = mondayThisWeek.AddDays(1).Date.ToString();
            tuesdayRemoveHours = tuesdayRemoveHours.Remove(tuesdayRemoveHours.Length -9, 9);
            TuesdayCurrentWeek = "Tuesday: " + tuesdayRemoveHours;


            string wednesdayRemoveHours = mondayThisWeek.AddDays(2).Date.ToString();
            wednesdayRemoveHours = wednesdayRemoveHours.Remove(wednesdayRemoveHours.Length -9, 9);
            WednesdayCurrentWeek = "Wednesday: " + wednesdayRemoveHours;


            string thursdayRemoveHours = mondayThisWeek.AddDays(3).Date.ToString();
            thursdayRemoveHours = thursdayRemoveHours.Remove(thursdayRemoveHours.Length -9, 9);
            ThursdayCurrentWeek = "Thursday: " + thursdayRemoveHours;


            string fridayRemoveHours = mondayThisWeek.AddDays(4).Date.ToString();
            fridayRemoveHours = fridayRemoveHours.Remove(fridayRemoveHours.Length -9, 9);
            FridayCurrentWeek = "Friday: " + fridayRemoveHours;
   

            string saturdayRemoveHours = mondayThisWeek.AddDays(5).Date.ToString();
            saturdayRemoveHours = saturdayRemoveHours.Remove(saturdayRemoveHours.Length -9, 9);
            SaturdayCurrentWeek = "Saturday: " + saturdayRemoveHours;


            string sundayRemoveHours = mondayThisWeek.AddDays(6).Date.ToString();
            sundayRemoveHours = sundayRemoveHours.Remove(sundayRemoveHours.Length -9, 9);
            SundayCurrentWeek = "Sunday: " + sundayRemoveHours;
 
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

        /*
         * Niels and Nicolaj
         * This method will check if the current week exsists in the data from API, and if it matches with dates of the week being looked at
         * When it finds a match it will insert the data from the list into the relevant week
         */
        public void CheckDates()
        {
            ClearAllProps();
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

        /*
         * Niels and Nicolaj
         * Clearing the propoties for when selecting new weeks so they are ready to be repopulated.
         */
        public void ClearAllProps()
        {
            MondayLunchTitle = "";
            MondayLunchDescription = "";
            TuesdayLunchTitle = "";
            TuesdayLunchDescription = "";
            WednesdayLunchTitle = "";
            WednesdayLunchDescription = "";
            ThursdayLunchTitle = "";
            ThursdayLunchDescription = "";
            FridayLunchTitle = "";
            FridayLunchDescription = "";
            SaturdayLunchTitle = "";
            SaturdayLunchDescription = "";
            SundayLunchTitle = "";
            SundayLunchDescription = "";
        }

        /*
         * Niels and Nicolaj
         * This method can save and finalize lunch added by the canteen staff. Depending on the button they press the
         * commandParam will get a unique string that is used to select a path through the logic so we dont have to loop through
         * the data more than needed
         */
        async Task SaveAndUpdateLunch(object commandParam)
        {          
            try
            {
                bool finalizedValuesCheck = false;
                bool isNotFinalized = false;
                // Update the product
                for (int i = 0; i < 7; i++)
                {
                    bool x = false;
                    Lunch lunch = new Lunch();
                    switch (i)
                    {
                        case 0:
                            if (!String.IsNullOrEmpty(MondayLunchTitle))
                            {
                                
                                lunch.FldDate = MondayCurrentWeek.Remove(0, 8);
                                lunch.FldMenu = MondayLunchTitle;
                                lunch.FldMenuDescription = MondayLunchDescription;
                                       
                            }                            
                            break;
                        case 1:                          
                            if (!String.IsNullOrEmpty(TuesdayLunchTitle))
                            {
     
                                lunch.FldDate = TuesdayCurrentWeek.Remove(0, 9);
                                lunch.FldMenu = TuesdayLunchTitle;
                                lunch.FldMenuDescription = TuesdayLunchDescription;
      
                            }
                            break;
                        case 2:
                            if (!String.IsNullOrEmpty(WednesdayLunchTitle))
                            {
                             
                                lunch.FldDate = WednesdayCurrentWeek.Remove(0, 11);
                                lunch.FldMenu = WednesdayLunchTitle;
                                lunch.FldMenuDescription = WednesdayLunchDescription;
                                       
                            }                            
                            break;
                        case 3:
                            
                            if (!String.IsNullOrEmpty(ThursdayLunchTitle))
                            {
                            
                                lunch.FldDate = ThursdayCurrentWeek.Remove(0, 10);
                                lunch.FldMenu = ThursdayLunchTitle;
                                lunch.FldMenuDescription = ThursdayLunchDescription;
                 
                            }
                            break;
                        case 4:
                            if (!String.IsNullOrEmpty(FridayLunchTitle))
                            {
                           
                                lunch.FldDate = FridayCurrentWeek.Remove(0, 8);
                                lunch.FldMenu = FridayLunchTitle;
                                lunch.FldMenuDescription = FridayLunchDescription;
               
                            }
                            break;
                        case 5:
                            if (!String.IsNullOrEmpty(SaturdayLunchTitle))
                            {
                      
                                lunch.FldDate = SaturdayCurrentWeek.Remove(0, 10);
                                lunch.FldMenu = SaturdayLunchTitle;
                                lunch.FldMenuDescription = SaturdayLunchDescription;
             
                            }
                            break;
                        case 6:
                            if (!String.IsNullOrEmpty(SundayLunchTitle))
                            {
                           
                                lunch.FldDate = SundayCurrentWeek.Remove(0, 8);
                                lunch.FldMenu = SundayLunchTitle;
                                lunch.FldMenuDescription = SundayLunchDescription;                          
                            }
                            break;
                        default:
                                MessageBox.Show("DEFAULT");
                            break;
                    }
                    
                    lunch.FldDate = DateTime.ParseExact(lunch.FldDate, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                    List<string> tempDateList = new List<string>();

                    int tempDate = SetWeekDown();
                    tempDateList = WeekPrior(DateTime.Now.Year + yearSaveForFinal, tempDate);

                    
                    //There is a bug when you try and finalize a week when you reach a new year
                    //so that it can finalize a week with no prior finalized weak
                    foreach (var item in LunchList)
                    {
                        if (commandParam.ToString().Equals("final"))
                        {                                                        
                            foreach (var item2 in tempDateList)
                            {                              

                                if ((item.FldDate.Contains(item2) && !item.FldMenuFinalized
                                  || item.FldDate.Contains(lunch.FldDate) && item.FldMenuFinalized) && !String.IsNullOrEmpty(lunch.FldMenu))
                                {

                                    isNotFinalized = true;

                                }
                            }
                        } else if (commandParam.ToString().Equals("save"))
                        {
                            isNotFinalized = true;
                        }


                        if ((!String.IsNullOrEmpty(lunch.FldMenu) && item.FldDate.Contains(lunch.FldDate)) && !item.FldMenuFinalized)
                        {                            
                            x = true;
                            if (isNotFinalized == false)
                            {
                                lunch.FldMenuFinalized = true;
                            }
                            else if(isNotFinalized == true)
                            {
                                lunch.FldMenuFinalized = item.FldMenuFinalized;
                            }
                            await UpdateLunchAsync(lunch);
                        }

                        if (!String.IsNullOrEmpty(lunch.FldMenu) && item.FldDate.Contains(lunch.FldDate) && item.FldMenuFinalized)
                        {
                            finalizedValuesCheck = true;                          
                        }
                    }
                    if (!String.IsNullOrEmpty(lunch.FldMenu) && !x && !finalizedValuesCheck)
                    {
                        if (isNotFinalized == false)
                        {
                            lunch.FldMenuFinalized = true;
                        }
                        await CreateLunchAsync(lunch);
                    } 
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /*
         * Niels and Nicolaj
         * This method will update values to the web API
         */
        async Task<Lunch> UpdateLunchAsync(Lunch lunch)
        {
            HttpResponseMessage response = await ApiHelper.client.PutAsJsonAsync(ApiHelper.serverUrl + ApiHelper.getLunch + "/" + lunch.FldDate, lunch);

            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            lunch = await response.Content.ReadAsAsync<Lunch>();

            //MessageBox.Show("Lunch is updated: " + lunch.FldDate + " has been succesfully updated!");
            return lunch;
        }

        /*
         * Niels and Nicolaj
         * This method will post values to the web API
         */
        static async Task<Uri> CreateLunchAsync(Lunch lunch)
        {
            HttpResponseMessage response = await ApiHelper.client.PostAsJsonAsync(
            ApiHelper.serverUrl + ApiHelper.getLunch, lunch);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }  
        

        /*
         * Niels and Nicolaj
         * This method recieves a year and a week and returns the dates of each day of the week as a list. 
         * This type of method has been used at the function at line 461, but that method is tied to other
         * variables so it could not be used twice, this is something to fix later and unite them into one method
         */
        public List<string> WeekPrior(int year, int week)
        {
            List<string> dateList = new List<string>();
            var mondayThisWeek = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
            string[] formats = { "dd-MM-yyyy", "dd/MM/yyyy" };


            //DateTime.ParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //cunt = DateTime.ParseExact(lunch.FldDate, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");
            string mondayRemoveHours = mondayThisWeek.Date.ToString();
            mondayRemoveHours = mondayRemoveHours.Remove(mondayRemoveHours.Length - 9, 9);
            mondayRemoveHours = DateTime.ParseExact(mondayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(mondayRemoveHours);

            string tuesdayRemoveHours = mondayThisWeek.AddDays(1).Date.ToString();
            tuesdayRemoveHours = tuesdayRemoveHours.Remove(tuesdayRemoveHours.Length - 9, 9);
            tuesdayRemoveHours = DateTime.ParseExact(tuesdayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(tuesdayRemoveHours);

            string wednesdayRemoveHours = mondayThisWeek.AddDays(2).Date.ToString();
            wednesdayRemoveHours = wednesdayRemoveHours.Remove(wednesdayRemoveHours.Length - 9, 9);
            wednesdayRemoveHours = DateTime.ParseExact(wednesdayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(wednesdayRemoveHours);

            string thursdayRemoveHours = mondayThisWeek.AddDays(3).Date.ToString();
            thursdayRemoveHours = thursdayRemoveHours.Remove(thursdayRemoveHours.Length - 9, 9);
            thursdayRemoveHours = DateTime.ParseExact(thursdayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(thursdayRemoveHours);

            string fridayRemoveHours = mondayThisWeek.AddDays(4).Date.ToString();
            fridayRemoveHours = fridayRemoveHours.Remove(fridayRemoveHours.Length - 9, 9);
            fridayRemoveHours = DateTime.ParseExact(fridayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(fridayRemoveHours);

            string saturdayRemoveHours = mondayThisWeek.AddDays(5).Date.ToString();
            saturdayRemoveHours = saturdayRemoveHours.Remove(saturdayRemoveHours.Length - 9, 9);
            saturdayRemoveHours = DateTime.ParseExact(saturdayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(saturdayRemoveHours);

            string sundayRemoveHours = mondayThisWeek.AddDays(6).Date.ToString();
            sundayRemoveHours = sundayRemoveHours.Remove(sundayRemoveHours.Length - 9, 9);
            sundayRemoveHours = DateTime.ParseExact(sundayRemoveHours, formats, null).ToString("yyyy-MM-dd");
            dateList.Add(sundayRemoveHours);

            return dateList;
        }

        public DateTime DateConvertion(string Input)
        {
            DateTime DateValue = DateTime.ParseExact(Input, "dd-MM-yyyy", null);
            return DateValue;
        }
    }
}

