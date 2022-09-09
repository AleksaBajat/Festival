using Client.Services.Abstractions;

namespace Client.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public BaseViewModel CurrentViewModel { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            CurrentViewModel = _navigationService.NavigationStore.CurrentViewModel;

            _navigationService.NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModel = _navigationService.NavigationStore.CurrentViewModel;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}