using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    public class NavigateEditTimeSlotCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _viewModel;

        public NavigateEditTimeSlotCommand(TimeSlotListingViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
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
