using System.Collections.Generic;

namespace Tp_Final_Fred.Models
{
    public class WeatherbitResponse
    {
        public List<WeatherbitDay> data { get; set; }
    }

    public class WeatherbitDay
    {
        public string datetime { get; set; }
        public double max_temp { get; set; }
        public double min_temp { get; set; }
        public WeatherbitWeather weather { get; set; }
    }

    public class WeatherbitWeather
    {
        public string icon { get; set; }
    }
}
