using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp3s.Data
{
    public class WeatherForecastJsonService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Reference: https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json
        public async Task<WeatherTemperatures> GetTemperaturesAsync()
        {
            string[] t = new string[5];
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44301");
            var response = await client.GetFromJsonAsync<WeatherTemperatures>("/data/temperatures.json");
            return response;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, WeatherTemperatures temperatures)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = temperatures.values[index-1],
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
