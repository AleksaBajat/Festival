using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.History;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class UpdateStageCommand:UndoBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly AddUpdateStageViewModel _addUpdateStageViewModel;
        private readonly StageViewModel _stageViewModel;
        

        public UpdateStageCommand(INavigationService navigationService,IStageService stageService,AddUpdateStageViewModel addUpdateStageViewModel)
        {
            _addUpdateStageViewModel = addUpdateStageViewModel;
            _navigationService = navigationService;
            _stageService = stageService;
            _stageViewModel = _addUpdateStageViewModel.ViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                StageId = _addUpdateStageViewModel.StageId;
                await _stageService.Update(new StageViewModel(new Stage
                {
                    Version = _addUpdateStageViewModel.Version,
                    Name = _addUpdateStageViewModel.Name,
                    StageId = _addUpdateStageViewModel.StageId
                }));
                if (parameter != null)
                {
                    if ((int)parameter != 0)
                    {
                        History.AddToUndo(this);
                    }
                }
                else
                {
                    History.AddToUndo(this);
                }
            }
            finally
            {
                _log.Info("Executed Update Stage Command");
                _navigationService.NavigateToFestival();
            }
        }

        public override async Task Undo(object parameter)
        {
            await _stageService.Update(new StageViewModel(new Stage
            {
                Name = _stageViewModel.Name,
                StageId = _stageViewModel.StageId
            }));

            _navigationService.NavigateToFestival();
        }
    }
}
