using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class CityWeatherForecast : ObservableObject
    {
        private City _city;
        public City City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }

        private int _cnt;
        public int Cnt
        {
            get { return _cnt; }
            set { Set(ref _cnt, value); }
        }

        private IEnumerable<DailyWeather> _dailyWeatherForecasts;
        
        // Web service calls the list of daily weathers "list" so I use a friendlier name
        [JsonProperty("list")]
        public IEnumerable<DailyWeather> DailyWeatherForecasts
        {
            get { return _dailyWeatherForecasts; }
            set { Set(ref _dailyWeatherForecasts, value); }
        }
    }
}
