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