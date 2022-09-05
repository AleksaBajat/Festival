using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class RefreshArtistsCommand:AsyncBaseCommand
    {
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
            return _artistService.GetAll(_collection, TimeSlotId);
        }
    }
}
