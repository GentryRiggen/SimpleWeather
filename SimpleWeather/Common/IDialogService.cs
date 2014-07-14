using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SimpleWeather.Common
{
    public interface IDialogService
    {
        Visibility LoadingVisibility { get; set; }

        bool ProgressIndeterminate { get; set; }

        void ShowLoading();

        void HideLoading();

        Task ShowDialogAsync(string title, string message);
    }
}
