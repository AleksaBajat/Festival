using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.History;
using Client.ViewModels;

namespace Client.Commands
{
    internal class DeleteStageCommand:UndoBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly StageListingViewModel _viewModel;

        public DeleteStageCommand(INavigationService navigationService,IStageService stageService,StageListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _stageService = stageService;
            _viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                StageId = _viewModel.Selected.StageId;
                await _stageService.Delete(_viewModel.Selected);
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
                _navigationService.NavigateToFestival();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.Selected != null && base.CanExecute(parameter);
        }

        public override async Task Undo(object parameter)
        {
             await _stageService.Add(new(new Stage
            {
                StageId = StageId
            }));

            _navigationService.NavigateToFestival();
        }
    }
}
