using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fStats.Executor
{    

    public class WikiController
    {

        private static readonly HttpClient HttpClient;

        static WikiController()
        {
            HttpClient = new HttpClient();
        }

        public static async Task<string> GetPageAsync(string uri)
        {
            try
            {
                string responseBody = await HttpClient.GetStringAsync(uri);

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                throw e;
            }
        }

    }

}
