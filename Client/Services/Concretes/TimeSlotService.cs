using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.ServiceModel;
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
    internal class TimeSlotService:ITimeSlotService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["timeSlotServerAddress"];

        public async Task Add(TimeSlotViewModel entity)
        {
            ChannelFactory<ITimeSlotHandler> factory = new ChannelFactory<ITimeSlotHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            await proxy.Add(model);
        }

        public async Task Delete(TimeSlotViewModel entity)
        {
            ChannelFactory<ITimeSlotHandler> factory = new ChannelFactory<ITimeSlotHandler>(new NetTcpBinding(), _endpointAddress);

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

        public async Task Update(TimeSlotViewModel entity)
        {
            ChannelFactory<ITimeSlotHandler> factory =
                new ChannelFactory<ITimeSlotHandler>(new NetTcpBinding(), _endpointAddress);

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

        public async Task GetAll(ObservableCollection<TimeSlotViewModel> collection, Guid stageId)
        {
            ChannelFactory<ITimeSlotHandler> factory = new ChannelFactory<ITimeSlotHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            List<TimeSlotDto> timeSlots = await proxy.GetAll(stageId);

            var data = new List<TimeSlot>();

            foreach (var timeSlot in timeSlots)
            {
                data.Add(ConvertToClientModel(timeSlot));
            }

            collection.Clear();

            foreach (TimeSlot timeSlot in data)
            {
                collection.Add(new TimeSlotViewModel(timeSlot));
            }
        }

        private TimeSlot ConvertToClientModel(TimeSlotDto timeSlot)
        {
            return new TimeSlot
            {
                Description = timeSlot.Description,
                From = timeSlot.From,
                StageId = timeSlot.StageId,
                TimeSlotId = timeSlot.TimeSlotId,
                To = timeSlot.To,
                Version = timeSlot.Version
            };
        }

        private TimeSlotDto ConvertVmToDto(TimeSlotViewModel entity)
        {
            return new TimeSlotDto
            {
                Description = entity.Description,
                From = entity.From,
                StageId = entity.StageId,
                TimeSlotId = entity.TimeSlotId,
                To = entity.To,
                Version = DateTime.Now
            };
        }
    }
}
