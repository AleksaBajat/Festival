using System;
using Client.State.Authentication;
using Client.ViewModels;

namespace Client.Stores
{
    public class NavigationStore
    {
        private IAuthenticator _authenticator;
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        
        public NavigationStore(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _currentViewModel = new LoginViewModel(authenticator, this);
        }
        
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}