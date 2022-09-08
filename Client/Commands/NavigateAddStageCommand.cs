using Client.Services.Abstractions;
using Client.State.Logging;
using log4net;

namespace Client.Commands
{
    internal class NavigateAddStageCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;

        public NavigateAddStageCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate To Add Stage View Command");
            _navigationService.NavigateToAddStage();
        }
    }
}
