using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    public class RefreshArtistsCommand:AsyncBaseCommand
    {
        private ObservableCollection<ArtistViewModel> _collection;
        private IArtistService _artistService;
        public Guid TimeSlotId { get; set; }

        public RefreshArtistsCommand(ObservableCollection<ArtistViewModel> collection, Guid timeSlotId)
        {
            _collection = collection;
            _artistService = DependencyResolver.Resolve<IArtistService>();
            TimeSlotId = timeSlotId;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _artistService.GetAll(_collection, TimeSlotId);
        }
    }
}
