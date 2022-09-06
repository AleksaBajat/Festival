using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.ViewModels;

namespace Client.Commands
{
    internal class AddArtistCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IArtistService _artistService;
        private readonly AddUpdateArtistViewModel _viewModel;

        public AddArtistCommand(INavigationService navigationService, IArtistService artistService, AddUpdateArtistViewModel viewModel)
        {
            _navigationService = navigationService;
            _artistService = artistService;
            _viewModel = viewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            await _artistService.Add(new ArtistViewModel(new Artist
            {
                ArtistId = Guid.NewGuid(),
                Genre = _viewModel.Genre,
                Name = _viewModel.Name,
                Surname = _viewModel.Surname,
                TimeSlotId = _viewModel.ViewModel.TimeSlotId,
                Version = DateTime.Now
            }));

            _navigationService.NavigateToArtists(_viewModel.ViewModel.TimeSlotId);
        }
    }
}
