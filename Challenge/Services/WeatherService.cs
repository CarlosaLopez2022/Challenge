using Challenge.Data;
using Challenge.Services.Abstractions;
using Newtonsoft.Json;

namespace Challenge.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _client = new HttpClient();
        private Root lastRoot;//optional 1 cache root when offline
        public Root LastRoot
        {
            get { return lastRoot; }
        }
        private DateTime lastCheck;
        public async Task<Root> GetWeather(string cityName)
        {
            Root rootObj = null;
            if (DateTime.Now - lastCheck < TimeSpan.FromMinutes(15) && LastRoot != null)//cached for 15 minutes. Can be edited as needed
            {
                return LastRoot;
            }
            lastCheck = DateTime.Now;
            try
            {
                string url = "https://goweather.herokuapp.com/weather/" + "{" + cityName + "}";
                using HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var myJsonResponse = await response.Content.ReadAsStringAsync();
                rootObj = JsonConvert.DeserializeObject<Root>(myJsonResponse);
                lastRoot = rootObj;
                return rootObj;
            }
            catch (Exception ex)
            {
                //Log to cloud or logger service
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return LastRoot;//returning last root cached
            }
        }
    }
}
