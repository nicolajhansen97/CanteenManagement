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

        [Test,TestCaseSource(nameof(TestSources))]
        public void TestCalculateBookingForDate(string date, List<LunchBooking> lunchBookings, int exptected)
        {
            //make data
            //activate mehtod
            LunchPageViewModel lunch = new LunchPageViewModel();    
            int Result = lunch.CalcuateBookingsForDate(date, lunchBookings);

            //assert value
            Assert.AreEqual(Result, exptected);

            //var result = sut.Add(calcuation);
            //assert
            //Assert.AreEqual(result, expected);
        }
        
        private static IEnumerable<object> TestSources()
        {
            yield return new object[] { "2021-12-07", new List<LunchBooking> { new LunchBooking { fldDate="" } }, 0 };
            yield return new object[] { "", new List<LunchBooking> { new LunchBooking { fldDate = "2021-12-07" } }, 0 };
            yield return new object[] { "2021-12-07", new List<LunchBooking> { new LunchBooking { fldDate = "2021-12-07" } }, 1 };
        }

    }
}