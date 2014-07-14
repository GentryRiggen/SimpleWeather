using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SimpleWeather.Common
{
    public interface INavigationService
    {
        Page Page { get; set; }
        Frame Frame { get; }

        void NavigateTo(Type type);

        void NavigateTo(Type type, Object param);
    }
}
