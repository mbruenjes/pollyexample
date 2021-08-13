using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastService;

namespace PollyExample.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(string httpClientName)
        {
            var httpClient = _httpClientFactory.CreateClient(httpClientName);

            return await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("https://localhost:5001/WeatherForecast");
        }
    }
}