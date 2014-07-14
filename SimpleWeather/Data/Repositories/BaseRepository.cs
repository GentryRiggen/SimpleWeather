using SimpleWeather.Data.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private Uri _apiBaseUrl = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily");
        private string _queryStringParams = "&units=imperial&cnt=16&mode=json";
        private HttpClient _httpClient;
        private IJsonConverter _jsonConverter;

        public BaseRepository(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }
                return _httpClient;
            }
        }

        public virtual async Task<T> GetCityForecast(string cityname)
        {
            string requestUrl = _apiBaseUrl + "?q=" + cityname + _queryStringParams;
            HttpResponseMessage response = await HttpClient.GetAsync(requestUrl);
            string getResults = await response.Content.ReadAsStringAsync();
            try
            {
                response.EnsureSuccessStatusCode();
                return await _jsonConverter.DeserializeObject<T>(getResults);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
