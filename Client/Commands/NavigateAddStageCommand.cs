using Client.Services.Abstractions;

namespace Client.Commands
{
    internal class NavigateAddStageCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateAddStageCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToAddStage();
        }
    }
}
