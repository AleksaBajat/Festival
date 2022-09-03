using Client.Models;

namespace Client.ViewModels
{
    internal class StageViewModel:BaseViewModel
    {
        private readonly Stage _stage;

        public int StageId => _stage.StageId;
        public string Name => _stage.Name;

        public StageViewModel(Stage stage)
        {
            _stage = stage;
        }
    }
}
