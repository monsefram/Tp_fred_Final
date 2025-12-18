using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Tp_Final_Fred.Models;


namespace Tp_Final_Fred.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public WeatherService(string apiKey)
        {
            _http = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<List<WeatherDay>> Get7DayForecast(double lat, double lon)
        {
            try
            {
                string url =
                    $"https://api.weatherbit.io/v2.0/forecast/daily" +
                    $"?lat={lat.ToString(CultureInfo.InvariantCulture)}" +
                    $"&lon={lon.ToString(CultureInfo.InvariantCulture)}" +
                    $"&key={_apiKey}&days=7";


                var json = await _http.GetStringAsync(url);

                var result = JsonConvert.DeserializeObject<WeatherbitResponse>(json);

                var list = new List<WeatherDay>();

                foreach (var d in result.data)
                {
                    list.Add(new WeatherDay
                    {
                        Date = d.datetime,
                        TempMax = d.max_temp,
                        TempMin = d.min_temp,
                        Icon = d.weather.icon
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                // Tu pourras afficher une popup dans l’UI plus tard
                Console.WriteLine("ERREUR API : " + ex.Message);
                return new List<WeatherDay>();
            }
        }
    }
}
