using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.History;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    internal class DeleteStageCommand:UndoBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly StageListingViewModel _viewModel;

        public DeleteStageCommand(StageListingViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _stageService = DependencyResolver.Resolve<IStageService>();
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
