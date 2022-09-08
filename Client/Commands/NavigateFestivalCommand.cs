using Client.Services.Abstractions;
using Client.State.Logging;
using log4net;

namespace Client.Commands
{
    internal class NavigateFestivalCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;

        public NavigateFestivalCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate To Festivals View Command");
            _navigationService.NavigateToFestival();
        }
    }
}
