using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MonitoreoLogisticoClient.Helpers
{
    public static class ConnectionHelper
    {
        public static HttpClient WebApiClient = new HttpClient();
        public static HttpClient AuthorizeClient = new HttpClient();

        public static HttpClient httpClient { get; set; }

        public static void InitializeClient() {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static ConnectionHelper()
        {
            //WebApiClient.BaseAddress = new Uri("http://localhost:5757/api/");
            ////WebApiClient.BaseAddress = new Uri("http://192.168.0.16:5656/api/"); //mi ip
            WebApiClient.BaseAddress = new Uri("http://localhost:5757/api/"); //mi ip
            AuthorizeClient.BaseAddress = new Uri("http://localhost:5757");
            //AuthorizeClient.BaseAddress = new Uri("http://192.168.43.112:5656/");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AuthorizeClient.DefaultRequestHeaders.Clear();
            AuthorizeClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}