using System;
using Client.Factories;
using Client.State.Authentication;
using Client.ViewModels;

namespace Client.Stores
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        private readonly IViewModelFactory _viewModelFactory;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        
        public NavigationStore()
        {
            _currentViewModel = new LoginViewModel();
        }
        
        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}