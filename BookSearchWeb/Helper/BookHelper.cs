using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookSearchWeb
{
    public class BookHelper
    {
        public HttpClient BookAPI { get; set; }

        public BookHelper ()
        {
           BookAPI = new HttpClient();
           BookAPI.BaseAddress = new Uri("http://localhost:53658");
           

        }
    }
}
