using Client.Services.Abstractions;
using Client.State.Logging;
using log4net;

namespace Client.Commands
{
    internal class NavigateAdminCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;

        public NavigateAdminCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate To Admin View Command");
            _navigationService.NavigateToAdmin();
        }
    }
}
