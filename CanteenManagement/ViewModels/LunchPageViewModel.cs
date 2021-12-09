using CanteenManagement.Models;
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
        public ICommand ChangeWeekMinusCMD { get; set; }
        public ICommand ChangeWeekPlusCMD { get; set; }
        public ICommand SaveUpdateLunchCMD { get; set; }
        public ICommand FinalizeLunchCMD { get; set; }


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

        public void GetOtherWeeksMinus()
        {
            if(weekSave < 2)
            {
                yearSave--;
                weekSave = 53;
            }        

            weekSave--;
            MessageBox.Show("THis is weeksave -: " + weekSave);
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);


            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
            getLunch();
        }
        public void GetOtherWeeksPlus()
        {
           
            if(weekSave > 51)
            {
                yearSave++;
                weekSave = 0;              
            }
            
           
            weekSave++;
            MessageBox.Show("THis is weeksave +: " + weekSave);
            GetWeekDates(DateTime.Now.Year + yearSave, weekSave);
           

            WeekNumber = "Week: " + weekSave + ", Year: " + (DateTime.Now.Year + yearSave);
            getLunch();
        }


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

        /* Made by Nicolaj and Niels
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
                                //MessageBox.Show("Tirsdag");
                                lunch.FldDate = TuesdayCurrentWeek.Remove(0, 9);
                                lunch.FldMenu = TuesdayLunchTitle;
                                lunch.FldMenuDescription = TuesdayLunchDescription;
      
                            }
                            break;
                        case 2:
                            if (!String.IsNullOrEmpty(WednesdayLunchTitle))
                            {
                                //MessageBox.Show("Onsdag");
                                lunch.FldDate = WednesdayCurrentWeek.Remove(0, 11);
                                lunch.FldMenu = WednesdayLunchTitle;
                                lunch.FldMenuDescription = WednesdayLunchDescription;
                                       
                            }                            
                            break;
                        case 3:
                            
                            if (!String.IsNullOrEmpty(ThursdayLunchTitle))
                            {
                               // MessageBox.Show("Torsdag");
                                lunch.FldDate = ThursdayCurrentWeek.Remove(0, 10);
                                lunch.FldMenu = ThursdayLunchTitle;
                                lunch.FldMenuDescription = ThursdayLunchDescription;
                 
                            }
                            break;
                        case 4:
                            if (!String.IsNullOrEmpty(FridayLunchTitle))
                            {
                                // MessageBox.Show("Fredag");
                                lunch.FldDate = FridayCurrentWeek.Remove(0, 8);
                                lunch.FldMenu = FridayLunchTitle;
                                lunch.FldMenuDescription = FridayLunchDescription;
               
                            }
                            break;
                        case 5:
                            if (!String.IsNullOrEmpty(SaturdayLunchTitle))
                            {
                                // MessageBox.Show("Lørdag");
                                lunch.FldDate = SaturdayCurrentWeek.Remove(0, 10);
                                lunch.FldMenu = SaturdayLunchTitle;
                                lunch.FldMenuDescription = SaturdayLunchDescription;
             
                            }
                            break;
                        case 6:
                            if (!String.IsNullOrEmpty(SundayLunchTitle))
                            {
                                // MessageBox.Show("Søndag");
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

                    

                    foreach (var item in LunchList)
                    {
                        if (commandParam.ToString().Equals("final"))
                        {                                                        
                            foreach (var item2 in tempDateList)
                            {                              
                                //MessageBox.Show(item2 + " | " + item.FldDate + " | Is not finalised? " + !item.FldMenuFinalized + " | Is not empty? " + !String.IsNullOrEmpty(lunch.FldMenu));
                                //MessageBox.Show(item2 + " | " + cunt);
                                if ((item.FldDate.Contains(item2) && !item.FldMenuFinalized
                                  || item.FldDate.Contains(lunch.FldDate) && item.FldMenuFinalized) && !String.IsNullOrEmpty(lunch.FldMenu))
                                {

                                    //MessageBox.Show("Got in! ");
                                    isNotFinalized = true;

                                }
                            }
                            /*
                            if (isNotFinalized != false)
                            {
                                MessageBox.Show(lunch.FldMenu + " : Was just finalized");
                                lunch.FldMenuFinalized = true;
                            }
                            */
                        } else if (commandParam.ToString().Equals("save"))
                        {
                            isNotFinalized = true;
                        }

                       
                        //MessageBox.Show(tempDateList.ElementAt(0) + " <-- Old date | New date --> " + item.FldDate);

                        if ((!String.IsNullOrEmpty(lunch.FldMenu) && item.FldDate.Contains(lunch.FldDate)) && !item.FldMenuFinalized)
                        {                            
                            x = true;
                            if (isNotFinalized == false)
                            {
                                MessageBox.Show("Finalized : In update");
                                lunch.FldMenuFinalized = true;
                            }
                            else if(isNotFinalized == true)
                            {
                                lunch.FldMenuFinalized = item.FldMenuFinalized;
                                MessageBox.Show("Could not finalize : In update");
                            }
                            //MessageBox.Show(lunch.FldMenu + " : Is updated");
                            await UpdateLunchAsync(lunch);
                        }

                        if (!String.IsNullOrEmpty(lunch.FldMenu) && item.FldDate.Contains(lunch.FldDate) && item.FldMenuFinalized)
                        {
                            MessageBox.Show("There is finalized item");
                            finalizedValuesCheck = true;
                            
                        }

                        //Tilføj noget der kan finde ud af om dagen har været finalized!!!!!!!!!!
                    }
                    if (!String.IsNullOrEmpty(lunch.FldMenu) && !x && !finalizedValuesCheck)
                    {
                        if (isNotFinalized == false)
                        {
                            MessageBox.Show("Finalized : In create");
                            lunch.FldMenuFinalized = true;
                        }
                        else if(isNotFinalized == true)
                        {
                            //lunch.FldMenuFinalized = false;
                            MessageBox.Show("Could not finalize : In create");
                        }
                        // MessageBox.Show(lunch.FldMenu + " : Is a new entry");
                        await CreateLunchAsync(lunch);
                    }

                    //MessageBox.Show("New Week");
                      
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        async Task<Lunch> UpdateLunchAsync(Lunch lunch)
        {
            HttpResponseMessage response = await ApiHelper.client.PutAsJsonAsync(ApiHelper.serverUrl + ApiHelper.getLunch + "/" + lunch.FldDate, lunch);

            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            lunch = await response.Content.ReadAsAsync<Lunch>();

            //MessageBox.Show("Lunch is updated: " + lunch.FldDate + " has been succesfully updated!");
            return lunch;
        }

        static async Task<Uri> CreateLunchAsync(Lunch lunch)
        {
            HttpResponseMessage response = await ApiHelper.client.PostAsJsonAsync(
            ApiHelper.serverUrl + ApiHelper.getLunch, lunch);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }  
        
        public List<string> WeekPrior(int year, int week)
        {
            List<string> dateList = new List<string>();
            var mondayThisWeek = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);
            
            //DateTime.ParseExact(str, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            //cunt = DateTime.ParseExact(lunch.FldDate, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");

            string mondayRemoveHours = mondayThisWeek.Date.ToString();
            mondayRemoveHours = mondayRemoveHours.Remove(mondayRemoveHours.Length - 9, 9);   
            mondayRemoveHours = DateTime.ParseExact(mondayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(mondayRemoveHours);

            string tuesdayRemoveHours = mondayThisWeek.AddDays(1).Date.ToString();
            tuesdayRemoveHours = tuesdayRemoveHours.Remove(tuesdayRemoveHours.Length - 9, 9);
            tuesdayRemoveHours = DateTime.ParseExact(tuesdayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(tuesdayRemoveHours);

            string wednesdayRemoveHours = mondayThisWeek.AddDays(2).Date.ToString();
            wednesdayRemoveHours = wednesdayRemoveHours.Remove(wednesdayRemoveHours.Length - 9, 9);
            wednesdayRemoveHours = DateTime.ParseExact(wednesdayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(wednesdayRemoveHours);

            string thursdayRemoveHours = mondayThisWeek.AddDays(3).Date.ToString();
            thursdayRemoveHours = thursdayRemoveHours.Remove(thursdayRemoveHours.Length - 9, 9);
            thursdayRemoveHours = DateTime.ParseExact(thursdayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(thursdayRemoveHours);

            string fridayRemoveHours = mondayThisWeek.AddDays(4).Date.ToString();
            fridayRemoveHours = fridayRemoveHours.Remove(fridayRemoveHours.Length - 9, 9);
            fridayRemoveHours = DateTime.ParseExact(fridayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(fridayRemoveHours);

            string saturdayRemoveHours = mondayThisWeek.AddDays(5).Date.ToString();
            saturdayRemoveHours = saturdayRemoveHours.Remove(saturdayRemoveHours.Length - 9, 9);
            saturdayRemoveHours = DateTime.ParseExact(saturdayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
            dateList.Add(saturdayRemoveHours);

            string sundayRemoveHours = mondayThisWeek.AddDays(6).Date.ToString();
            sundayRemoveHours = sundayRemoveHours.Remove(sundayRemoveHours.Length - 9, 9);
            sundayRemoveHours = DateTime.ParseExact(sundayRemoveHours, "dd-MM-yyyy", null).ToString("yyyy-MM-dd");
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

