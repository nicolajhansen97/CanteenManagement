using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanteenManagement.ViewModels;

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

            //activate mehtod
            LunchPageViewModel lunch = new LunchPageViewModel();
            lunch.CalcuateBookingsForDate("");
          

            //assert value
        }


    }
}