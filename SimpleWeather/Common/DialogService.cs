using SimpleWeather.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SimpleWeather.Common
{
    public class DialogService : ObservableObject, IDialogService
    {
        public async Task ShowDialogAsync(string title, string message)
        {
            var dialog = new MessageDialog(message, title);
            dialog.ShowAsync();
        }

        private Visibility _loadingVisibility;
        public Visibility LoadingVisibility
        {
            get { return _loadingVisibility; }
            set { Set(ref _loadingVisibility, value); }
        }

        private bool _progressIndeterminate;
        public bool ProgressIndeterminate
        {
            get { return _progressIndeterminate; }
            set { Set(ref _progressIndeterminate, value); }
        }

        public void ShowLoading()
        {
            LoadingVisibility = Visibility.Visible;
            ProgressIndeterminate = true;
        }

        public void HideLoading()
        {
            LoadingVisibility = Visibility.Collapsed;
            ProgressIndeterminate = false;
        }


        
    }
}
