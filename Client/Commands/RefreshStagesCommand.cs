using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class RefreshStagesCommand : AsyncBaseCommand
    {
        private ObservableCollection<StageViewModel> _collection;
        private IStageService _stageService;

        public RefreshStagesCommand(IStageService stageService,ObservableCollection<StageViewModel> collection)
        {
            _collection = collection;
            _stageService = stageService;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _stageService.GetAll(_collection);
        }
    }
}
