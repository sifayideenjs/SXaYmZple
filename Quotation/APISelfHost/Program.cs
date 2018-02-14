using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace APISelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:13037/"; // change based on your domain setting

            using (WebApp.Start<Startup>(url: baseUrl))
            {
                HttpClient client = new HttpClient();
                var resp = client.GetAsync(baseUrl).Result;

                Console.WriteLine(resp);
                Console.WriteLine(resp.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }

            Console.ReadKey();
        }
    }
}
