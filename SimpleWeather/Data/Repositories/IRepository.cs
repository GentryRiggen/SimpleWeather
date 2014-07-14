using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetCityForecast(string cityName);
    }
}
