using System;
using System.Threading.Tasks;
using TimeTracker.Services.Navigation;
using TimeTracker.ViewModels;
using TimeTracker.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = ViewModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginViewModel>();
        }

        protected override void OnStart()
        {
            InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
