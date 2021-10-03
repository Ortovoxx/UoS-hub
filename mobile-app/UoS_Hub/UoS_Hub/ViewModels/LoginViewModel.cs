using System;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;

namespace UoS_Hub.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(LoginView);

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        
    }
}