using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UoS_Hub.Models;
using UoS_Hub.Services;
using UoS_Hub.Services.Navigation;
using UoS_Hub.Services.Network;
using UoS_Hub.Services.UserConfigManager;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace UoS_Hub.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {

        private readonly INetworkService _networkService;
        private readonly IUserConfigManager _userConfigManager;
        
        public override Type WiredPageType => typeof(RegistrationView);
        private string _tag;
        public string Tag
        {
            get => _tag;
            set => SetValue(ref _tag, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetValue(ref _name, value);
        }
        

        public ObservableCollection<string> Schools { get; set; }
        
        private int _schoolsIndex;

        public int SchoolIndex
        {
            get => _schoolsIndex;
            set => SetValue(ref _schoolsIndex, value);
        }

        private string _ical;

        public string iCal
        {
            get => _ical;
            set => SetValue(ref _ical, value);
        }

        private string _hall;

        public string Hall
        {
            get => _hall;
            set => SetValue(ref _hall, value);
        }

        public ICommand BackCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegistrationViewModel(INavigationService navigationService, INetworkService networkService, IUserConfigManager userConfigManager) : base(navigationService)
        {
            _networkService = networkService;
            _userConfigManager = userConfigManager;
            BackCommand = new Command(GoBack);
            RegisterCommand = new Command(Register);
            Schools = new ObservableCollection<string>(new[] { "ECS" });
        }

        private async void Register()
        {
            if (await _networkService.RegisterNewUser(new User()
            {
                Hall = _hall,
                iCal = _ical,
                Name = _name,
                School = Schools[_schoolsIndex],
                Tag = _tag
            }))
            {
                await _userConfigManager.SetConfigAsync(new UserConfig()
                {
                    IsInit = true,
                    RefreshRateMin = 30
                });
                await _navigationService.InitMainNavigation();
            }
        }

        private async void GoBack()
        {
            await _navigationService.PopAsync();
        }
    }
}