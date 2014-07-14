using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class City : ObservableObject
    {
        private int _id;
        public int Id 
        {
            get { return _id; }
            set { Set(ref _id, value);  }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private Coord _coord;
        public Coord Coord
        {
            get { return _coord; }
            set { Set(ref _coord, value); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { Set(ref _country, value); }
        }
    }
}
