using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;
using Common.Faults;
using Contracts;
using DTO;

namespace Client.Services.Concretes
{
    internal class ArtistService:IArtistService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["artistServerAddress"];
        public async Task Add(ArtistViewModel entity)
        {
            ChannelFactory<IArtistHandler> factory = new ChannelFactory<IArtistHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            await proxy.Add(model);
        }

        public async Task Delete(ArtistViewModel entity)
        {
            ChannelFactory<IArtistHandler> factory = new ChannelFactory<IArtistHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            try
            {
                await proxy.Delete(model);
            }
            catch (FaultException<ConflictFault>)
            {
                if (MessageBox.Show("The record you attempted to delete was modified by another user after you got the original values. The delete operation was canceled. If you still want to delete this record, click 'Yes' button. Otherwise click 'No'.",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await proxy.Delete(model, true);
                }
            }
        }

        public async Task Update(ArtistViewModel entity)
        {
            ChannelFactory<IArtistHandler> factory =
                new ChannelFactory<IArtistHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            try
            {
                await proxy.Update(model);
            }
            catch (FaultException<ConflictFault>)
            {
                if (MessageBox.Show("The record you attempted to edit was modified by another user after you got the original values. The edit operation was canceled. If you still want to edit this record, click 'Yes' button. Otherwise click 'No'.",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await proxy.Update(model, true);
                }
            }
        }

        public async Task GetAll(ObservableCollection<ArtistViewModel> collection, Guid timeSlotId)
        {
            ChannelFactory<IArtistHandler> factory = new ChannelFactory<IArtistHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            List<ArtistDto> artists = await proxy.GetAll(timeSlotId);

            var data = new List<Artist>();

            foreach (var artist in artists)
            {
                data.Add(ConvertToClientModel(artist));
            }

            collection.Clear();

            foreach (Artist artist in data)
            {
                collection.Add(new ArtistViewModel(artist));
            }
        }

        private Artist ConvertToClientModel(ArtistDto artist)
        {
            return new Artist
            {
                ArtistId = artist.ArtistId,
                Genre = artist.Genre,
                Name = artist.Name,
                Surname = artist.Surname,
                TimeSlotId = artist.TimeSlotId,
                Version = artist.Version
            };
        }

        private ArtistDto ConvertVmToDto(ArtistViewModel entity)
        {
            return new ArtistDto
            {
                ArtistId = entity.ArtistId,
                Genre = entity.Genre,
                Name = entity.Name,
                Surname = entity.Surname,
                TimeSlotId = entity.TimeSlotId,
                Version = entity.Version
            };
        }
    }
}
