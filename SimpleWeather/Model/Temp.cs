using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class Temp : ObservableObject
    {
        private double _day;
        public double Day
        {
            get { return Math.Round(_day); }
            set { Set(ref _day, value); }
        }

        private double _min;
        public double Min
        {
            get { return Math.Round(_min); }
            set { Set(ref _min, value); }
        }

        private double _max;
        public double Max
        {
            get { return Math.Round(_max); }
            set { Set(ref _max, value); }
        }

        private double _night;
        public double Night
        {
            get { return Math.Round(_night); }
            set { Set(ref _night, value); }
        }

        private double _eve;
        public double Eve
        {
            get { return Math.Round(_eve); }
            set { Set(ref _eve, value); }
        }

        private double _morn;
        public double Morn
        {
            get { return Math.Round(_morn); }
            set { Set(ref _morn, value); }
        }
    }
}
