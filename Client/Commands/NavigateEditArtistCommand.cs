using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateEditArtistCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly ArtistListingViewModel _viewModel;

        public NavigateEditArtistCommand(INavigationService navigationService, ArtistListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }
        public override Task ExecuteAsync(object parameter)
        {
            _navigationService.NavigateToEditArtist(_viewModel.Selected);

            return Task.CompletedTask;
        }
    }
}
