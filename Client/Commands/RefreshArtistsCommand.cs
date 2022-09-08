using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class RefreshArtistsCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private ObservableCollection<ArtistViewModel> _collection;
        private IArtistService _artistService;
        public Guid TimeSlotId { get; set; }

        public RefreshArtistsCommand(IArtistService artistService,ObservableCollection<ArtistViewModel> collection, Guid timeSlotId)
        {
            _collection = collection;
            _artistService = artistService;
            TimeSlotId = timeSlotId;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Refresh Artists Command");
            return _artistService.GetAll(_collection, TimeSlotId);
        }
    }
}
