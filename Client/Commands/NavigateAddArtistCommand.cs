using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateAddArtistCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly Guid _timeSlotId;

        public NavigateAddArtistCommand(INavigationService navigationService, Guid timeSlotId)
        {
            _timeSlotId = timeSlotId;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _navigationService.NavigateToAddArtist(new ArtistViewModel(new Artist
            {
                TimeSlotId = _timeSlotId
            }));
        }
    }
}
