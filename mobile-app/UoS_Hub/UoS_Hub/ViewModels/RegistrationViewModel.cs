using System;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;

namespace UoS_Hub.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(RegistrationView);
        public RegistrationViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}