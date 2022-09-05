using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class NavigateEditTimeSlotCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _viewModel;

        public NavigateEditTimeSlotCommand(INavigationService navigationService,TimeSlotListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationService.NavigateToEditTimeStamps(_viewModel.Selected);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
