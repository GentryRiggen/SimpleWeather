using SimpleWeather.Data.JsonConverters;
using SimpleWeather.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.Repositories
{
    public class CityWeatherRepository : BaseRepository<CityWeatherForecast>
    {
        public CityWeatherRepository() : base(new JsonDotNetConverter())
        { }
    }
}
