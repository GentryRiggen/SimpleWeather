using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Common
{
    public class Utils
    {
        public static DateTime ConvertFromEpochTime(int epochTime)
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return epochStart.AddSeconds(epochTime);
        }
    }
}
