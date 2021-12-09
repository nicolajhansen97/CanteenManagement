using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanteenManagement.ViewModels;
using CanteenManagement.Models;
using System.Collections.Generic;

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

        [Test]
        public void Test2()
        {
            //make data
            List<LunchBooking> list = new List<LunchBooking>();
            list.Add(new LunchBooking { fldLunchBookingID=1,fldEmployeeID=1,fldDate="2021-12-07"});
            list.Add(new LunchBooking { fldLunchBookingID = 2, fldEmployeeID = 1, fldDate = "2021-12-08" });
            list.Add(new LunchBooking { fldLunchBookingID = 3, fldEmployeeID = 2, fldDate = "2021-12-07" });
            list.Add(new LunchBooking { fldLunchBookingID = 4, fldEmployeeID = 1, fldDate = "2021-12-08" });
            //activate mehtod
            LunchPageViewModel lunch = new LunchPageViewModel();
            int testValue = lunch.CalcuateBookingsForDate("2021-12-07",list);

            //assert value
            Assert.IsTrue(testValue == 2);
        }


    }
}