using System;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class DeleteArtistCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly IArtistService _artistService;
        private readonly INavigationService _navigationService;
        private readonly ArtistListingViewModel _viewModel;

        public DeleteArtistCommand(IArtistService artistService, INavigationService navigationService,
            ArtistListingViewModel viewModel)
        {
            _artistService = artistService;
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _artistService.Delete(_viewModel.Selected);
            _log.Info("Executed Delete Artist Command");
            _navigationService.NavigateToArtists(_viewModel.Selected.TimeSlotId);
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
