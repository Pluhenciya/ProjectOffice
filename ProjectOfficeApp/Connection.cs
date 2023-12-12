using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfficeApp
{
    public static class Connection
    {
        public static HttpClient Client {  get; set; } = new HttpClient
        { 
            BaseAddress = new Uri("http://localhost:5038")
        };
    }
}
