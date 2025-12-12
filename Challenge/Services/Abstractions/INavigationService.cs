using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Services.Abstractions
{
    public interface INavigationService
    {
        Task GoToAsync(string page);
        Task GoToAsync(string page, bool animated, IDictionary<string, object> parameters);
        Task GoBackAsync();
    }
}
