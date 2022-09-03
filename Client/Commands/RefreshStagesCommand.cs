using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Concretes;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    internal class RefreshStagesCommand : AsyncBaseCommand
    {
        private ObservableCollection<StageViewModel> _collection;
        private StageService _stageService;

        public RefreshStagesCommand(ObservableCollection<StageViewModel> collection)
        {
            _collection = collection;
            _stageService = DependencyResolver.Resolve<StageService>();
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _stageService.GetAll(_collection);
        }
    }
}
