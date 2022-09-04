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
    internal class UpdateStageCommand:UndoBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly AddUpdateStageViewModel _addUpdateStageViewModel;

        public UpdateStageCommand(AddUpdateStageViewModel addUpdateStageViewModel)
        {
            _addUpdateStageViewModel = addUpdateStageViewModel;
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _stageService = DependencyResolver.Resolve<IStageService>();
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _stageService.Update(new StageViewModel(new Stage
                {
                    Name = _addUpdateStageViewModel.Name,
                    StageId = _addUpdateStageViewModel.StageId
                }));
            }
            finally
            {
                _navigationService.NavigateToFestival();
            }
        }

        public override Task Undo(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
