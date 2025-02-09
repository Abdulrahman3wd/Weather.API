using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Weather.API.ApiModels;

namespace Weather.API.services
{
    public class WeatherApiServices
    {
        private readonly HttpClient _httpClient;
        public WeatherApiServices( )
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.Base_Url);
           
        }
        public async Task<WeatherAPIResponse> GetWeatherInfo(string latitude , string longitude)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            return await _httpClient.GetFromJsonAsync<WeatherAPIResponse>($"current?access_key{Constants.API_Key}&query={latitude},{longitude}");
            
               
        }

    }
}
