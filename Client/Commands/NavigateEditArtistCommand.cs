using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class NavigateEditArtistCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly ArtistListingViewModel _viewModel;

        public NavigateEditArtistCommand(INavigationService navigationService, ArtistListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }
        public override Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Navigate To Edit Artist View Command");

            _navigationService.NavigateToEditArtist(_viewModel.Selected);

            return Task.CompletedTask;
        }
    }
}
