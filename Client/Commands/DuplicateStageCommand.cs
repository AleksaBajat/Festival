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
    internal class DuplicateStageCommand:UndoBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly StageListingViewModel _viewModel;
        private int _stageId;

        public DuplicateStageCommand(StageListingViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _stageService = DependencyResolver.Resolve<IStageService>();
            _viewModel = viewModel;
        }


        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await _stageService.Duplicate(_viewModel.Selected);
                _stageId = (int)parameter;
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
            throw new NotImplementedException();
        }
    }
}
