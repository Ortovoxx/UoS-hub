using System;
using System.Threading.Tasks;
using UoS_Hub.Services.Navigation;
using UoS_Hub.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UoS_Hub
{
    public partial class App : Application
    {
        private INavigationService _navigationService;
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            MainPage = new ContentPage();
            InitApp(false);
        }

        protected override async void OnStart()
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync("Getting your stuff together"))
            {
                await InitNavigation();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async Task InitNavigation()
        {
            _navigationService = SuperContainer.Resolve<INavigationService>();
            await _navigationService.InitMainNavigation();
        }

        private void InitApp(bool useMocks)
        {
            SuperContainer.UpdateDependencies(useMocks);
        }
    }
}