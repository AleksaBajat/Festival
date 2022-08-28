using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.Services.Concretes;
using Client.State.Authentication;
using Client.ViewModels;

namespace Client.Commands
{
    public class RegisterCommand:AsyncBaseCommand
    {
        private readonly AdminViewModel _adminViewModel;
        private readonly IRegisterService _registerService;
        public RegisterCommand(AdminViewModel adminViewModel,IRegisterService registerService = null)
        {
            _adminViewModel = adminViewModel;
            _registerService = registerService;
        }
        
        public async override Task ExecuteAsync(object parameter)
        {
            _registerService.Register(_adminViewModel.Username, _adminViewModel.Password, _adminViewModel.FirstName,
                _adminViewModel.LastName, _adminViewModel.IsAdmin);
        }
    }
}