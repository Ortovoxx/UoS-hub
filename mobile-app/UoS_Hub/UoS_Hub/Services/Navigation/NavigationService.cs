using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UoS_Hub.Helpers;
using UoS_Hub.Models;
using UoS_Hub.Services.UserConfigManager;
using UoS_Hub.ViewModels;
using UoS_Hub.ViewModels.Base;
using UoS_Hub.Views;
using Xamarin.Forms;

namespace UoS_Hub.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IUserConfigManager _configManager;

        public NavigationService(IUserConfigManager configManager)
        {
            _configManager = configManager;
        }

        public async Task InitMainNavigation()
        {
            UserConfig userConfig = await _configManager.GetConfigAsync();
            //check if the user has initialized an app
            if (!userConfig.IsInit)
            {
                var initViewModel = SuperContainer.Resolve<InitNavViewModel>();
                var initNavPage = (NavigationPage)ViewLocator.ResolvePageFromViewModel(initViewModel);
                //need init before creating a page
                //since the XAML layout is generated from the the model
                //see InitWorkingDaysPage.xaml and InitPageTemplateSelector class
                var loginvm = SuperContainer.Resolve<LoginViewModel>();
                await loginvm.Init(null);
                var loginPage = ViewLocator.ResolvePageFromViewModel(loginvm);
                await initNavPage.PushAsync(loginPage);
                Application.Current.MainPage = initNavPage;
            }
            else
            {
                //too lazy to do it manually, so instead deliver a list of viewModels to be resolved automatically
                var tabs = await ResolveNavigation(new List<Type>()
                {
                    typeof(MainViewModel),
                    typeof(TimetableViewModel)

                });

                var mainPageViewModel = SuperContainer.Resolve<MainNavigationViewModel>();
                mainPageViewModel.Tabs = tabs;

                var mainPage = ViewLocator.ResolvePageFromViewModel(mainPageViewModel);
                Application.Current.MainPage = mainPage;
                await (Application.Current.MainPage.BindingContext as MainNavigationViewModel)?.Init("Welcome");
            }
        }


        private async Task<ObservableCollection<Page>> ResolveNavigation(List<Type> viewModels)
        {
            ObservableCollection<Page> pages = new ObservableCollection<Page>();
            foreach (var viewModelType in viewModels)
            {
                var viewModel = (BaseViewModel)SuperContainer.Resolve(viewModelType);
                await viewModel.Init(null);
                var page = ViewLocator.ResolvePageFromViewModel(viewModel);

                //wrap each page into a nav page in case we need to do some "in-tab" navigation
                //see https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/tabbed-page#navigate-within-a-tab
                var navPage = new NavigationPage(page)
                {
                    Title = page.Title,
                    IconImageSource = page.IconImageSource
                };
                pages.Add(navPage);
            }

            return pages;
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            await NavigateToHelper<TViewModel>(null);
        }

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            await NavigateToHelper<TViewModel>(parameter);
        }

        private async Task NavigateToHelper<TViewModel>(object param) where TViewModel : BaseViewModel
        {
            //resolve page's viewmodel
            var viewModel = SuperContainer.Resolve<TViewModel>();
            var page = ViewLocator.ResolvePageFromViewModel(viewModel);

            //check if the main navigation has been init
            if (Application.Current.MainPage is TabbedPage tabbedPage)
            {
                if (tabbedPage.CurrentPage is NavigationPage navigationPage)
                {
#pragma warning disable 8602
                    await (page.BindingContext as BaseViewModel).Init(param);
#pragma warning restore 8602
                    await navigationPage.PushAsync(page);
                }
            }
            else if (Application.Current.MainPage is InitNavPage navPage)
            {
#pragma warning disable 8602
                await viewModel.Init(param);
                //await (page.BindingContext as BaseViewModel).Init(param);
#pragma warning restore 8602
                await navPage.PushAsync(page);
            }
            else
            {
                await InitMainNavigation();
            }
        }

        public Task ClearTheStackAsync()
        {
            for (int i = 0; i < Application.Current.MainPage.Navigation.NavigationStack.Count - 1; i++)
            {
                Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation
                    .NavigationStack[i]);
            }

            return Task.CompletedTask;
        }

        public async Task NavigateToModalAsync<TViewModel>(object parameters) where TViewModel : BaseViewModel
        {
            var viewModel = SuperContainer.Resolve<TViewModel>();
            await viewModel.Init(parameters);
            var page = ViewLocator.ResolvePageFromViewModel(viewModel);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task PopAsync()
        {
            if (Application.Current.MainPage is TabbedPage tabbedPage)
            {
                if (tabbedPage.CurrentPage is NavigationPage navigationPage)
                {
                    await navigationPage.PopAsync(true);
                }
            }
            else if (Application.Current.MainPage is InitNavPage navPage)
            {
                await navPage.PopAsync(true);
            }
        }
    }
}