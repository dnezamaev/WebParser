using OpenWeatherAPI;

namespace WebParserCli.OpenWeatherMap
{
    internal class OpenWeatherMapClient
    {
        public void Go()
        {
            var apiKey = File.ReadAllText(@"OpenWeatherMap\ApiKey.txt");

            // Координаты Москвы
            string lat = "55.751244";
            string lon = "37.618423";

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

            using (var client = new HttpClient())
            {
                var httpResponse = client.GetAsync(url).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonContent = httpResponse.Content.ReadAsStringAsync().Result;
                    var queryResponse = new QueryResponse(jsonContent);
                    Console.WriteLine(jsonContent);
                }
            }
        }
    }
}
