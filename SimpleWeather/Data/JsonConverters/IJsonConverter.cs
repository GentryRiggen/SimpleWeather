﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Data.JsonConverters
{
    public interface IJsonConverter
    {
        Task<T> DeserializeObject<T>(string value);
    }
}
