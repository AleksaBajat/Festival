using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels;

namespace Client.Services.Abstractions
{
    public interface IArtistService:IEntityService<ArtistViewModel>
    {
        Task GetAll(ObservableCollection<ArtistViewModel> collection, Guid timeSlotId);
    }
}
