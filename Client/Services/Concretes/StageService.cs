using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using Common.Faults;
using Contracts;
using DTO;
using log4net;

namespace Client.Services.Concretes
{
    public class StageService:IStageService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["stageServerAddress"];
        private readonly ILog _log = LogHelper.GetLogger();

        public async Task Add(StageViewModel entity)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(entity);

            await proxy.Add(model);
        }

        public async Task Search(ObservableCollection<StageViewModel> collection, string parameter)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            List<StageDto> stages = await proxy.Search(parameter);

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

        public async Task Duplicate(StageViewModel stage, Guid newId)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            StageDuplicateDto duplicate = new StageDuplicateDto
            {
                StageId = stage.StageId,
                NewId = newId,
                Name = stage.Name,
                Version = stage.Version
            };

            try
            {
                await proxy.Duplicate(duplicate);
            }
            catch (FaultException<ConflictFault>)
            {
                if (MessageBox.Show("The record you attempted to duplicate was modified by another user after you got the original values. The duplication operation was canceled. If you still want to duplicate this record, click 'Yes' button. Otherwise click 'No'.",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _log.Warn("Resolved Stage Duplicate Conflict");
                   await proxy.Duplicate(duplicate, true);
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
                    _log.Warn("Resolved Stage Delete Conflict");
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
                    _log.Warn("Resolved Stage Update Conflict");
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
                Version = viewModel.Version != default ? viewModel.Version : DateTime.Now
            };

            return conversionResult;
        }
    }
}
