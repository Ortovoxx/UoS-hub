using System;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;

namespace UoS_Hub.ViewModels
{
    public class InitNavViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(InitNavPage);
        
        public InitNavViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}