using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.State.Resolver;
using Client.Stores;
using Client.ViewModels;

namespace Client.Services.Concretes
{
    internal class NavigationService:INavigationService
    {
        private NavigationStore _navigationStore;

        public NavigationService()
        {
            
        }

        public void NavigateToAdmin()
        {
            _navigationStore = DependencyResolver.Resolve<NavigationStore>();
            _navigationStore.CurrentViewModel = new AdminViewModel();
        }

        public void NavigateToFestival()
        {
            _navigationStore = DependencyResolver.Resolve<NavigationStore>();
            _navigationStore.CurrentViewModel = new StageListingViewModel(DependencyResolver.Resolve<IAuthenticator>());
        }

        public void NavigateToLogin()
        {
            _navigationStore = DependencyResolver.Resolve<NavigationStore>();
            _navigationStore.CurrentViewModel = new LoginViewModel();
        }
    }
}
