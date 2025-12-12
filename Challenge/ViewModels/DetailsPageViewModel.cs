

using Challenge.Data;
using Challenge.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Challenge.ViewModels
{
    [QueryProperty(nameof(City), "City")]
    public partial class DetailsPageViewModel : VMBase, IQueryAttributable
    {
        private readonly IWeatherService _weatherService;
        public DetailsPageViewModel(IWeatherService weatherService) {
            PageTitle = "City details";
            _weatherService = weatherService;
        }
        [ObservableProperty]
        City city;
        [ObservableProperty]
        string cityName;
        [ObservableProperty]
        string temperature;
        [ObservableProperty]
        string condition;
        [ObservableProperty]
        string windSpeed;
        [ObservableProperty]
        List<Forecast> forecasts = new List<Forecast>();//this way, we can add n numbers of day forecasts later on

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey(nameof(City)))
            {
                City _city = query[nameof(City)] as City;
                if (_city != null)
                {
                    City = _city;
                    CityName = _city.Name;
                    Temperature = _city.Root.temperature;
                    Condition = _city.Root.description;
                    WindSpeed = _city.Root.wind;
                    Forecasts = _city.Root.forecast;
                }
                OnPropertyChanged(nameof(City));
            }
        }
        [RelayCommand]
        public async Task Refresh()
        {
            IsBusy = true;
            var result = await _weatherService.GetWeather(City.Name);
            City.Root = result;
            Temperature = result.temperature;
            Condition = result.description;
            WindSpeed = result.wind;
            Forecasts = result.forecast;
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(CityName));
            OnPropertyChanged(nameof(Temperature));
            OnPropertyChanged(nameof(Condition));
            OnPropertyChanged(nameof(Forecasts));
            IsBusy = false;
        }
    }
}
