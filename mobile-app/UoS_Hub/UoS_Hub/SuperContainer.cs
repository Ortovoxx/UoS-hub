using System;
using TinyIoC;
using UoS_Hub.Services.Navigation;
using UoS_Hub.Services.UserConfigManager;
using UoS_Hub.ViewModels;
using Xamarin.Forms;

namespace UoS_Hub
{
    public static class SuperContainer
    {
        private static readonly TinyIoCContainer Container;

        static SuperContainer()
        {
            Container = TinyIoCContainer.Current;
            Container.Register<MainViewModel>();
            Container.Register<LoginViewModel>();
            Container.Register<RegistrationViewModel>();
            Container.Register<MainNavigationViewModel>();
            
            Container.Register<INavigationService, NavigationService>();
        }

        public static void UpdateDependencies(bool useMocks)
        {
            Container.Register<IUserConfigManager, UserConfigManager>();
        }
        
        public static T Resolve<T>() where T : class
        {
            if (Container.CanResolve<T>()) return Container.Resolve<T>();
            return default;
        }

        public static object Resolve<T>(T objType) where T : Type
        {
            if (Container.CanResolve(objType)) return Container.Resolve(objType);
            return default;
        }

        public static void Register<T>() where T : class
        {
            Container.Register<T>();
        }
    }
}