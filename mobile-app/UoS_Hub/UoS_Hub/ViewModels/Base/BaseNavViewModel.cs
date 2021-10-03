using UoS_Hub.Services.Navigation;

namespace UoS_Hub.ViewModels.Base
{
    public abstract class BaseNavViewModel : BaseViewModel
    {
        public virtual string IconSource { get; set; }
        public BaseNavViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}