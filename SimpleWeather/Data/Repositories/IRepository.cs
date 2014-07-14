using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.Repositories
{
    /// <summary>
    /// Interface that defines all fields and methods for interaction 
    /// with the Weather Web Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<T> GetCityForecast(string cityName);
    }
}
