using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class NavigateEditTimeSlotCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _viewModel;

        public NavigateEditTimeSlotCommand(INavigationService navigationService,TimeSlotListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _log.Info("Execute Navigate Edit Time Slot View Command");
            _navigationService.NavigateToEditTimeStamps(_viewModel.Selected);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
