using Client.Services.Abstractions;

namespace Client.Commands
{
    internal class NavigateAdminCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateAdminCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToAdmin();
        }
    }
}
