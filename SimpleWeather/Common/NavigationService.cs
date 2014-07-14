using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SimpleWeather.Common
{
    public class NavigationService : INavigationService
    {
        public Page Page { get; set; }
        public Frame Frame { get { return this.Page.Frame; } }

        public NavigationService(Page page)
        {
            this.Page = page;
        }

        public void NavigateTo(Type type)
        {
            Frame.Navigate(type);
        }

        public void NavigateTo(Type type, Object param)
        {
            Frame.Navigate(type, param);
        }
    }
}
