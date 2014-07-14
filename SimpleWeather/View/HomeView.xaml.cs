using SimpleWeather.Common;
using SimpleWeather.Controller;
using SimpleWeather.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SimpleWeather
{
    public sealed partial class HomeView : Page
    {
        private readonly NavigationHelper navigationHelper;
        MainController mainController;
        public HomeView()
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (mainController == null)
            {
                mainController = new MainController(this);
                this.DataContext = mainController;
            }
            else
            {
                mainController.GoToFirstDay();
            }
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        private void CitySelected_Event(object sender, SelectionChangedEventArgs e)
        {
            mainController.CityChanged((string)(sender as ComboBox).SelectedItem);
        }

        private void DailyWeatherClicked_Event(object sender, ItemClickEventArgs e)
        {
            mainController.NavigateToDay((DailyWeather)e.ClickedItem);
        }
    }
}
