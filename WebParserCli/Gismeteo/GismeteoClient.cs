using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebParserCli.Gismeteo
{
    internal class GismeteoClient
    {
        public void Go()
        {
            using (WebClient webClient = new WebClient())
            {
                // TODO: получить токен
                webClient.Headers.Add("X-Gismeteo-Token", "56b30cb255.3443075");
                var str = webClient.DownloadString("https://api.gismeteo.net/v2/weather/current/4368/?lang=en");
                Console.WriteLine(str);
            }
        }
    }
}
