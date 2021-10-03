using System;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;

namespace UoS_Hub.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(MainView);

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}