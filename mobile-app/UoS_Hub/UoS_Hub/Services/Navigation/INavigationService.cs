using System.Threading.Tasks;
using UoS_Hub.ViewModels.Base;

namespace UoS_Hub.Services.Navigation
{
    public interface INavigationService
    {
        Task InitMainNavigation();
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameters) where TViewModel : BaseViewModel;

        Task ClearTheStackAsync();

        Task PopAsync();

        Task NavigateToModalAsync<TViewModel>(object parameters) where TViewModel : BaseViewModel;
        Task PopModalAsync();
    }
}