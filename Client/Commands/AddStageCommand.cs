using System;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.History;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class AddStageCommand:UndoBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly AddUpdateStageViewModel _addUpdateStageViewModel;

        public AddStageCommand(INavigationService navigationService, IStageService stageService,AddUpdateStageViewModel viewModel)
        {
            _stageService = stageService;
            _navigationService = navigationService;
            _addUpdateStageViewModel = viewModel;
            StageId = Guid.NewGuid();
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _stageService.Add(new StageViewModel(new Stage
            {
                Name = _addUpdateStageViewModel.Name,
                StageId = StageId
            }));
            if (parameter != null)
            {
                if ((int) parameter != 0)
                {
                    History.AddToUndo(this);
                }
            }
            else
            {
                History.AddToUndo(this);
            }

            _log.Info("Executed Add Stage Command.");

            _navigationService.NavigateToFestival();
        }

        public override async Task Undo(object parameter)
        {
            await _stageService.Delete(new StageViewModel(new Stage
            {
                StageId = StageId
            }));

            _log.Info("Undo - Executed Add Stage Command");

            _navigationService.NavigateToFestival();
        }
    }
}
