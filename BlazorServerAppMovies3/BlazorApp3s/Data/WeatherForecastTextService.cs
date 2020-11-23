using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlazorApp3s.Data
{
    public class WeatherForecastTextService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Reference: https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json
        public async Task<string[]> GetTemperaturesAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44301/data/temperatures.csv");
            string t = await response.Content.ReadAsStringAsync();
            t = t.Substring(0, t.Length - 2);
            return t.Split(',');
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, string[] temperatures)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = int.Parse(temperatures[index-1]),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
