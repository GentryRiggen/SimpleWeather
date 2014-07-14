using SimpleWeather.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class DailyWeather : ObservableObject
    {
        private int _dt;
        public int Dt
        {
            get { return _dt; }
            set { Set(ref _dt, value); }
        }

        public DateTime Date 
        {
            get { return _dt == 0 ? DateTime.UtcNow : Utils.ConvertFromEpochTime(_dt); }
        }

        private Temp _temp;
        public Temp Temp
        {
            get { return _temp; }
            set { Set(ref _temp, value); }
        }

        private double _pressure;
        public double Pressure
        {
            get { return _pressure; }
            set { Set(ref _pressure, value); }
        }

        private int _humidity;
        public int Humidity
        {
            get { return _humidity; }
            set { Set(ref _humidity, value); }
        }

        private IEnumerable<Weather> _weather;
        public IEnumerable<Weather> Weather
        {
            get { return _weather; }
            set { Set(ref _weather, value); }
        }

        public Weather TheWeather
        {
            get
            {
                return Weather.FirstOrDefault();
            }
        }

        public string WeatherIcon
        {
            get
            {
                return TheWeather != null ?
                    "http://openweathermap.org/img/w/" + TheWeather.Icon + ".png" :
                    "http://openweathermap.org/img/w/10d.png";
            }
        }

        public string DayWeatherIcon
        {
            get 
            { 
                return TheWeather != null ? 
                    "http://openweathermap.org/img/w/" + TheWeather.Icon.Replace("n", "d") + ".png" : 
                    "http://openweathermap.org/img/w/10d.png"; 
            }
        }

        public string NightWeatherIcon
        {
            get
            {
                return TheWeather != null ?
                    "http://openweathermap.org/img/w/" + TheWeather.Icon.Replace("d", "n") + ".png" :
                    "http://openweathermap.org/img/w/10d.png";
            }
        }

        public string BackgroundImage
        {
            get { return TheWeather != null ? "/Assets/" + TheWeather.Icon + ".png" : "/Assets/01d.png"; }
        }

        private double _speed;
        public double Speed
        {
            get { return _speed; }
            set { Set(ref _speed, value); }
        }

        private int _deg;
        public int Deg
        {
            get { return _deg; }
            set { Set(ref _deg, value); }
        }

        private int _clouds;
        public int Clouds
        {
            get { return _clouds; }
            set { Set(ref _clouds, value); }
        }

        private double _rain;
        public double Rain
        {
            get { return Math.Round(_rain); }
            set { Set(ref _rain, value); }
        }
    }
}
