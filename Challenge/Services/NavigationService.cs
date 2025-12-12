using Challenge.Services.Abstractions;

namespace Challenge.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task GoBackAsync(IDictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync("..", true, parameters);
        }

        public async Task GoToAsync(string page)
        {
            await Shell.Current.GoToAsync($"{page}");
        }

        public async Task GoToAsync(string page, bool animated, IDictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync($"{page}", animated, parameters);
        }
    }
}
