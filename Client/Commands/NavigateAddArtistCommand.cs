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
    internal class NavigateAddArtistCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly Guid _timeSlotId;

        public NavigateAddArtistCommand(INavigationService navigationService, Guid timeSlotId)
        {
            _timeSlotId = timeSlotId;
            _navigationService = navigationService;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Navigate To Add Artist View Command");

            _navigationService.NavigateToAddArtist(new ArtistViewModel(new Artist
            {
                TimeSlotId = _timeSlotId
            }));

            return Task.CompletedTask;
        }
    }
}
