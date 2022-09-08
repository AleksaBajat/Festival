using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class UpdateArtistCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly IArtistService _artistService;
        private readonly AddUpdateArtistViewModel _viewModel;

        public UpdateArtistCommand(INavigationService navigationService, IArtistService artistService, AddUpdateArtistViewModel viewModel)
        {
            _navigationService = navigationService;
            _artistService = artistService;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _artistService.Update(new ArtistViewModel(new Artist
            {
                ArtistId = _viewModel.ViewModel.ArtistId,
                Genre = _viewModel.Genre,
                Name = _viewModel.Name,
                Surname = _viewModel.Surname,
                TimeSlotId = _viewModel.ViewModel.TimeSlotId,
                Version = _viewModel.ViewModel.Version
            }));

            _log.Info("Executed Update Artist Command");

            _navigationService.NavigateToArtists(_viewModel.ViewModel.TimeSlotId);
        }
    }
}
