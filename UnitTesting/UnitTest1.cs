using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanteenManagement.ViewModels;
using CanteenManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace CanteenTest
{
    public class Tests
    {
        string serverUrl;
        string getLunch;
        HttpClient client;

        [SetUp]
        public void Setup()
        {
            serverUrl = "https://localhost:5001/"; //44355
            getLunch = "api/TblLunches";
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        async public Task Test1()
        {
            HttpResponseMessage response = await client.GetAsync(serverUrl + getLunch);
            response.EnsureSuccessStatusCode();

            string message = response.ToString();

            Assert.IsTrue(message.Contains("200"));
        }


        /// <summary>
        /// Made by Rasmus
        /// This is our whitebox test, here we test a method that gets a date and a list, 
        ///and checks how many times that date is in the list. We use the method to see how many people have 
        ///booked lunch on the different days of the week. The test works in a way that we make an object array 
        ///that holds 1 test worth of values and then I just make more object arrays. if i want more tests. 
        ///We had to test this method 3 times to see if all the conditions worked as intended. 
        ///We first test if the list does not have any real values. then if the date we give is empty, 
        ///and lastly we test to see if it can compare 2 dates and return an increased number.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lunchBookings"></param>
        /// <param name="exptected"></param>
        [Test,TestCaseSource(nameof(TestSources))]
        public void TestCalculateBookingForDate(string date, List<LunchBooking> lunchBookings, int exptected)
        {
            //activate mehtod
            LunchPageViewModel lunch = new LunchPageViewModel();    
            int Result = lunch.CalcuateBookingsForDate(date, lunchBookings);

            //assert value
            Assert.AreEqual(Result, exptected);
        }
        
        private static IEnumerable<object> TestSources()
        {
            yield return new object[] { "2021-12-07", new List<LunchBooking> { new LunchBooking { fldDate="" } }, 0 };
            yield return new object[] { "", new List<LunchBooking> { new LunchBooking { fldDate = "2021-12-07" } }, 0 };
            yield return new object[] { "2021-12-07", new List<LunchBooking> { new LunchBooking { fldDate = "2021-12-07" } }, 1 };
        }


        /// <summary>
        /// Made by Rasmus
        /// </summary>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <param name="exptected"></param>
        [Test,TestCaseSource(nameof(TestSources2))]
        public void TestGetWeekDates(int year,int week,List<string> exptected)
        {
            LunchPageViewModel lunch = new LunchPageViewModel();
            List<string> Result = lunch.WeekPrior(year,week);

            Assert.AreEqual(Result, exptected);
        }

        private static IEnumerable<object> TestSources2()
        {
            yield return new object[] {2021, 52, new List<string> { "2021-12-27", "2021-12-28", "2021-12-29", "2021-12-30", "2021-12-31", "2022-01-01", "2022-01-02" } };
        }

    }
}