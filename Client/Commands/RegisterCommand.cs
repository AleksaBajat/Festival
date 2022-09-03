using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.Services.Concretes;
using Client.State.Authentication;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    public class RegisterCommand:AsyncBaseCommand
    {
        private readonly AdminViewModel _adminViewModel;
        private readonly IRegisterService _registerService;
        public RegisterCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _registerService = DependencyResolver.Resolve<IRegisterService>();
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            await _registerService.Register(_adminViewModel.Username, _adminViewModel.Password, _adminViewModel.FirstName,
                _adminViewModel.LastName, _adminViewModel.IsAdmin);
        }
    }
}