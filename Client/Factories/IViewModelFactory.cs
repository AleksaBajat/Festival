using Client.ViewModels;

namespace Client.Factories
{
    public interface IViewModelFactory
    {
        public BaseViewModel CreateViewModel();
    }
}