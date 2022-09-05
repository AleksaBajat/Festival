using Client.Services.Abstractions;

namespace Client.Commands
{
    internal class NavigateFestivalCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateFestivalCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToFestival();
        }
    }
}
