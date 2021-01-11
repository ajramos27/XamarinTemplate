using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTracker.Services.Navigation;
using TimeTracker.ViewModels.Base;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ICommand _signInCommand;
  
        public ICommand SignInCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }

        private INavigationService _navigationService;
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new Command(OnSingInAction);
        }

        private void OnSingInAction(object obj)
        {
            _navigationService.NavigateToAsync<DashboardViewModel>();
        }
    }
}
