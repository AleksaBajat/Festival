using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;
using Contracts;
using DTO;

namespace Client.Services.Concretes
{
    public class StageService:IStageService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["stageServerAddress"];

        public Task Add(StageViewModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task Duplicate(StageViewModel stage)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(stage);

            await proxy.Duplicate(model);
        }

        public async Task Delete(StageViewModel stage)
        {
            ChannelFactory<IStageHandler> factory = new ChannelFactory<IStageHandler>(new NetTcpBinding(), _endpointAddress);

            var proxy = factory.CreateChannel();

            var model = ConvertVmToDto(stage);

            await proxy.Delete(model);
        }

        public Task Update(StageViewModel entity)
        {
            throw new NotImplementedException();
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
                Version = viewModel.Version
            };

            return conversionResult;
        }
    }
}
