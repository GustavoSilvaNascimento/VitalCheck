using System;
using System.Collections.Generic;
using System.Text;

namespace VitalCheck.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigationAsync(string route);
        Task NavigationAsync(string route, object parameter);


    }
}
