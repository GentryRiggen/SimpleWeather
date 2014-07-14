using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.JsonConverters
{
    public class JsonDotNetConverter : IJsonConverter
    {
        public async Task<T> DeserializeObject<T>(string value)
        {
            return await JsonConvert.DeserializeObjectAsync<T>(value);
        }
    }
}
