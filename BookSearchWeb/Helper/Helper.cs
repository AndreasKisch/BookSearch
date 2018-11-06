using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookSearchWeb
{
    public class Helper
    {
        public static HttpClient BookAPI { get; set; }

        public static void InitializeClients()
        {
            BookAPI = new HttpClient();
            BookAPI.BaseAddress = new Uri("http://localhost:53658");
            BookAPI.DefaultRequestHeaders.Accept.Clear();
            BookAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
