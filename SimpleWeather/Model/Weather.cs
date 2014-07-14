using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Model
{
    public class Weather : ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _main;
        public string Main
        {
            get { return _main; }
            set { Set(ref _main, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { Set(ref _icon, value); }
        }
    }
}
