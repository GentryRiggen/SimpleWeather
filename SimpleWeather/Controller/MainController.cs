using SimpleWeather.Common;
using SimpleWeather.Data.Repositories;
using SimpleWeather.Model;
using SimpleWeather.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SimpleWeather.Controller
{
    /// <summary>
    /// The primary controller that aids the HomeView and DailyView views. 
    /// Interacts with the data layer and also contains fields for the views
    /// to bind to. 
    /// </summary>
    public class MainController : ObservableObject
    {
        #region Properties
        private INavigationService _navigationService;

        private IDialogService _dialogService;

        public IDialogService DialogService
        {
            get { return _dialogService; }
            set { Set(ref _dialogService, value); }
        }   

        private CityWeatherRepository _repo;

        private string _selectedCity;
        public string SelectedCity
        {
            get { return _selectedCity; }
            set { Set(ref _selectedCity, value); }
        }

        private DailyWeather _selectedDay;
        public DailyWeather SelectedDay
        {
            get { return _selectedDay; }
            set { Set(ref _selectedDay, value); }
        }

        private CityWeatherForecast _cityWeatherForecast;
        
        public CityWeatherForecast CityWeatherForecast
        {
            get { return _cityWeatherForecast; }
            set { Set(ref _cityWeatherForecast, value); }
        }

        private List<string> _cityNames;
        public List<string> CityNames
        {
            get { return _cityNames; }
            set { Set(ref _cityNames, value); }
        }

        private Dictionary<string, string> _cityNamesToQuery = new Dictionary<string, string>();

        private string _backgroundImage;
        public string BackgroundImage
        {
            get { return _backgroundImage; }
            set { Set(ref _backgroundImage, value); }
        }

        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new RelayCommand(async () => await RefreshAsync(), () => true)); }
        }

        private RelayCommand<DailyWeather> _navigateToDayCommand;
        public RelayCommand<DailyWeather> NavigateToDayCommand
        {
            get { return _navigateToDayCommand ?? (_navigateToDayCommand = new RelayCommand<DailyWeather>(async (dailyWeather) => await NavigateToDay(dailyWeather), (dailyWeather) => true)); }
        }

        private RelayCommand _sortByHighsCommand;
        public RelayCommand SortByHighsCommand
        {
            get { return _sortByHighsCommand ?? (_sortByHighsCommand = new RelayCommand(() => SortByHighs(), () => true)); }
        }

        private RelayCommand _sortByLowsCommand;
        public RelayCommand SortByLowsCommand
        {
            get { return _sortByLowsCommand ?? (_sortByLowsCommand = new RelayCommand(() => SortByLows(), () => true)); }
        }

        private RelayCommand _sortByRainCommand;
        public RelayCommand SortByRainCommand
        {
            get { return _sortByRainCommand ?? (_sortByRainCommand = new RelayCommand(() => SortByRain(), () => true)); }
        }

        private RelayCommand _sortByDateCommand;
        public RelayCommand SortByDateCommand
        {
            get { return _sortByDateCommand ?? (_sortByDateCommand = new RelayCommand(() => SortByDate(), () => true)); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor adds a set list of cities to be picked from and then 
        /// gets the 16 day forecast for the first one
        /// </summary>
        public MainController(Page view)
        {
            _navigationService = new NavigationService(view);
            DialogService = new DialogService();
            _repo = new CityWeatherRepository();
            _cityNamesToQuery.Add("Boulder, USA", "boulder,us");
            _cityNamesToQuery.Add("Banff, Canada", "banff,ca");
            _cityNamesToQuery.Add("Tokyo, Japan", "tokyo");
            _cityNamesToQuery.Add("Seoul, South Korea", "seoul");
            _cityNamesToQuery.Add("Shanghai, China", "shanghai");
            _cityNamesToQuery.Add("New York, USA", "new,york,us");
            _cityNamesToQuery.Add("Mexico City, Mexico", "mexico,city");
            _cityNamesToQuery.Add("Moscow, Russia", "moscow,russia");
            _cityNamesToQuery.Add("Los Angeles, USA", "los,angeles");
            _cityNamesToQuery.Add("Buenos Aires, Argentina", "buenos,aires");
            _cityNamesToQuery.Add("Rio de Janeiro, Brazil", "rio,de,janeiro");
            _cityNamesToQuery.Add("Chicago, USA", "chicago");
             

            CityNames = new List<string>(_cityNamesToQuery.Keys);
            _selectedCity = CityNames.First();
            RefreshAsync();
        }
        #endregion

        private async Task RefreshAsync()
        {
            DialogService.ShowLoading();
            CityWeatherForecast = null;
            CityWeatherForecast = await _repo.GetCityForecast(_cityNamesToQuery[_selectedCity]);
            if (CityWeatherForecast == null)
            {
                await DialogService.ShowDialogAsync("Oops", "Could not retrieve the forecast.");
            }
            SelectedDay = CityWeatherForecast.DailyWeatherForecasts.First();
            BackgroundImage = _selectedDay.BackgroundImage;
            DialogService.HideLoading();
        }

        internal void CityChanged(string cityName)
        {
            SelectedCity = cityName;
            RefreshAsync();
        }

        internal async Task NavigateToDay(DailyWeather dailyWeather)
        {

            if (dailyWeather != null)
            {
                SelectedDay = dailyWeather;
                BackgroundImage = _selectedDay.BackgroundImage;
                _navigationService.NavigateTo(typeof(DayView), this);
            }
            else 
                await _dialogService.ShowDialogAsync("Oops", "A day was not selected.");
        }

        internal void GoToFirstDay()
        {
            SelectedDay = CityWeatherForecast.DailyWeatherForecasts.First();
            BackgroundImage = _selectedDay.BackgroundImage;
        }

        #region Sorting
        /// <summary>
        /// I use a LINQ to do simple sorting on the data with lambda expressions.
        /// </summary>
        private void SortByHighs()
        {
            CityWeatherForecast.DailyWeatherForecasts = CityWeatherForecast.DailyWeatherForecasts.OrderByDescending(d => d.Temp.Max).ToList();
        }

        /// <summary>
        /// I use a LINQ to do simple sorting on the data with lambda expressions.
        /// </summary>
        private void SortByLows()
        {
            CityWeatherForecast.DailyWeatherForecasts = CityWeatherForecast.DailyWeatherForecasts.OrderBy(d => d.Temp.Min).ToList();
        }

        /// <summary>
        /// I use a LINQ to do simple sorting on the data with lambda expressions.
        /// </summary>
        private void SortByRain()
        {
            CityWeatherForecast.DailyWeatherForecasts = CityWeatherForecast.DailyWeatherForecasts.OrderByDescending(d => d.Rain);
        }

        /// <summary>
        /// I use a LINQ to do simple sorting on the data with lambda expressions.
        /// </summary>
        private void SortByDate()
        {
            CityWeatherForecast.DailyWeatherForecasts = CityWeatherForecast.DailyWeatherForecasts.OrderBy(d => d.Date);
        }
        #endregion
    }
}
