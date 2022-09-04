﻿using System;
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
    internal class AddStageCommand:UndoBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly IStageService _stageService;
        private readonly AddUpdateStageViewModel _addUpdateStageViewModel;

        public AddStageCommand(AddUpdateStageViewModel viewModel)
        {
            _stageService = DependencyResolver.Resolve<IStageService>();
            _navigationService = DependencyResolver.Resolve<INavigationService>();
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
            _navigationService.NavigateToFestival();
        }

        public override async Task Undo(object parameter)
        {
            await _stageService.Delete(new StageViewModel(new Stage
            {
                StageId = StageId
            }));

            _navigationService.NavigateToFestival();
        }
    }
}
