using System;
using System.Windows.Input;
using UoS_Hub.Services.Navigation;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;
using Xamarin.Forms;

namespace UoS_Hub.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public override Type WiredPageType => typeof(LoginView);

        private string _tag;
        public string Tag
        {
            get => _tag;
            set => SetValue(ref _tag, value);
        }

        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginCommand = new Command(Login);
            SignUpCommand = new Command(SignUp);
        }


        private void Login()
        {
            
        }

        private async void  SignUp()
        {
            await _navigationService.NavigateToAsync<RegistrationViewModel>();
        }
    }
}