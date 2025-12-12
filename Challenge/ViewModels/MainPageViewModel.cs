using Challenge.Data;
using Challenge.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace Challenge.ViewModels
{
    public partial class MainPageViewModel : VMBase
    {
        private readonly IWeatherService _weatherService;
        private readonly INavigationService _navigationService;
        public MainPageViewModel(IWeatherService weatherService,
                                 INavigationService navigationService) {
            PageTitle = "Root page";
            Cities.Add(new City("Tokio"));
            Cities.Add(new City("Buenos Aires"));
            Cities.Add(new City("Puebla"));
            Cities.Add(new City("Monterrey"));
            Cities.Add(new City("Los Angeles"));
            _weatherService = weatherService;
            _navigationService = navigationService;
        }
        [ObservableProperty]
        public ObservableCollection<City> cities = new ObservableCollection<City>();

        [ObservableProperty]
        City selectedCity;

        [RelayCommand]
        public async Task GetWeather()
        {
            IsBusy = true;
            var updatedCities = new List<City>(Cities);
            foreach (var city in updatedCities)
            {
                var result = await _weatherService.GetWeather(city.Name);
                city.Root = result;
                city.LastUpdated = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            }
            Cities = new ObservableCollection<City>(updatedCities);
            IsBusy = false;
        }
        [RelayCommand]
        public async Task GoToDetails(City city)
        {
            if (city == null || IsBusy) {return;}
            var navigationParameter = new Dictionary<string, object>()
            {
                { "City", city }
            };
            await _navigationService.GoToAsync(nameof(DetailsPage), true, navigationParameter);
            SelectedCity = null;
        }
    }
}
