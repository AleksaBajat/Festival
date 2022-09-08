using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class SearchStagesCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private ObservableCollection<StageViewModel> _collection;
        private IStageService _stageService;
        private StageListingViewModel _viewModel;

        public SearchStagesCommand(IStageService stageService, ObservableCollection<StageViewModel> collection,StageListingViewModel viewModel)
        {
            _viewModel = viewModel;
            _collection = collection;
            _stageService = stageService;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Refresh Stages Command");
            return _stageService.Search(_collection,_viewModel.Search);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Search) && base.CanExecute(parameter);
        }
    }
}
