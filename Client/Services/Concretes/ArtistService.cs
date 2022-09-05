using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Services.Concretes
{
    internal class ArtistService:IArtistService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["artistServerAddress"];
        public Task Add(ArtistViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ArtistViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(ArtistViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task GetAll(ObservableCollection<ArtistViewModel> collection, Guid timeSlotId)
        {
            throw new NotImplementedException();
        }
    }
}
