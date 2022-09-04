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
    public class StageService:IStageService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["stageServerAddress"];

        public async Task Add(StageViewModel entity)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            await proxy.Add(model);
        }

        public async Task Duplicate(StageViewModel stage)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(stage);

            try
            {
                await proxy.Duplicate(model);
            }
            catch (FaultException<ConflictFault>)
            {
                if (MessageBox.Show("The record you attempted to duplicate was modified by another user after you got the original values. The duplication operation was canceled. If you still want to duplicate this record, click 'Yes' button. Otherwise click 'No'.",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                   await proxy.Duplicate(model, true);
                }
            }
        }


        public async Task Delete(StageViewModel stage)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(stage);

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

        public async Task Update(StageViewModel entity)
        {
            ChannelFactory<IStageHandler> factory =
                new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            try
            {
                await proxy.Update(model);
            }
            catch(FaultException<ConflictFault>)
            {
                if (MessageBox.Show("The record you attempted to edit was modified by another user after you got the original values. The edit operation was canceled. If you still want to edit this record, click 'Yes' button. Otherwise click 'No'.",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    await proxy.Update(model,true);
                }
            }
        }

        public async Task GetAll(ObservableCollection<StageViewModel> collection)
        {

            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            List<StageDto> stages = await proxy.GetAll();

            var data = new List<Stage>();

            foreach (var stage in stages)
            {
                data.Add(ConvertToClientModel(stage));
            }

            collection.Clear();

            foreach (Stage stage in data)
            {
                collection.Add(new StageViewModel(stage));
            }
        }

        private Stage ConvertToClientModel(StageDto dto)
        {
            Stage conversionResult = new Stage
            {
                StageId = dto.StageId,
                Name = dto.Name,
                Version = dto.Version
            };

            return conversionResult;
        }

        private StageDto ConvertVmToDto(StageViewModel viewModel)
        {
            StageDto conversionResult = new StageDto
            {
                StageId = viewModel.StageId,
                Name = viewModel.Name,
                Version = DateTime.Now
            };

            return conversionResult;
        }
    }
}
