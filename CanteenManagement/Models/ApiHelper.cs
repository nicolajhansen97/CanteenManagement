using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    //Made by Nicolaj
    class ApiHelper
    {
        public static string serverUrl = "https://localhost:44355/";
        public static string getItems = "api/TblItemInfoes";
       // public static string createItem = "api/"


        public static HttpClient client { get; set; }

        public static void InitializeClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
