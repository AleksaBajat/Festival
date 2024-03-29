﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class RefreshStagesCommand : AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private ObservableCollection<StageViewModel> _collection;
        private IStageService _stageService;

        public RefreshStagesCommand(IStageService stageService,ObservableCollection<StageViewModel> collection)
        {
            _collection = collection;
            _stageService = stageService;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Refresh Stages Command");
            return _stageService.GetAll(_collection);
        }
    }
}
