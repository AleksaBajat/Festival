using Client.State.Authentication;
using Client.Stores;
using Client.ViewModels;

namespace Client.Factories
{
    public class LoginViewModelFactory:IViewModelFactory
    {
        public BaseViewModel CreateViewModel()
        {
            return new LoginViewModel();
        }
    }
}