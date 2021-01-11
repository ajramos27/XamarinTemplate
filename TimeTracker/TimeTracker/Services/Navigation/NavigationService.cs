using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.ViewModels.Base;
using Xamarin.Forms;

namespace TimeTracker.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        //Grab the navigation form the current page and just pop async
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        //Navigation between pages
        public async Task NavigateToAsync<TViewModelBase>(object navigationData = null, bool setRoot = false)
        {
            var page = ViewModelLocator.CreatePageFor(typeof(TViewModelBase));

            if (setRoot)
            {
                App.Current.MainPage = new NavigationPage(page);
            } else
            {
                if(App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page); //Go to next page
                } else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if (page.BindingContext is ViewModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
            
        }
    }
}
