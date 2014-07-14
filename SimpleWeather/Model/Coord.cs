using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class Coord : ObservableObject
    {
        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { Set(ref _lat, value); }
        }

        private double _lon;
        public double Lon
        {
            get { return _lon; }
            set { Set(ref _lon, value); }
        }
    }
}
