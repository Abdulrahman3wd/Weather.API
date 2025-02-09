using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.API.services;

namespace Weather.API.ViewModels
{
    public partial class WeatherPageViewModel : ObservableObject
    {
        private readonly WeatherApiServices _apiServices;
        public WeatherPageViewModel()
        {
            _apiServices = new WeatherApiServices();
        }
        [ObservableProperty]
        private string latitude;
        [ObservableProperty]
        private string longitude;
        [ObservableProperty]
        private string weatherIcon;
        [ObservableProperty]
        private string temperature;
        [ObservableProperty]
        private string weatherDescription;
        [ObservableProperty]
        private string location;
        [ObservableProperty]
        private string humidity;
        [ObservableProperty]
        private string cloudCoverLevel;
        [ObservableProperty]
        private string isDay;
        private readonly WeatherApiServices apiServices;

        [RelayCommand]

        public async Task FetchWeatherApiCommand()
        {
            var weatherApiResponse = await _apiServices.GetWeatherInfo(Latitude, Longitude);
            if (weatherApiResponse is not null)
            {
                WeatherIcon = weatherApiResponse.Current.weather_icons[0];
                Temperature = $"{weatherApiResponse.Current.temperature}C";
                Location = $"{weatherApiResponse.Location.name},{weatherApiResponse.Location.region},{weatherApiResponse.Location.country}";
                WeatherDescription = weatherApiResponse.Current.weather_descriptions[0];
                Humidity = weatherApiResponse.Current.humidity.ToString();
                CloudCoverLevel = $"{weatherApiResponse.Current.cloudcover}%"; 
                IsDay = weatherApiResponse.Current.is_day.ToString().ToUpper();
            }


        }


    }
}
