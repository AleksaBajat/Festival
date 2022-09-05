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
    public class NavigateArtistsCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _timeSlotListingViewModel;
        public NavigateArtistsCommand(TimeSlotListingViewModel timeSlotListingViewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _timeSlotListingViewModel = timeSlotListingViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationService.NavigateToArtists(_timeSlotListingViewModel.Selected.TimeSlotId);
        }

        public override bool CanExecute(object parameter)
        {
            return _timeSlotListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
