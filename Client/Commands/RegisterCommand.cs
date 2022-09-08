using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class RegisterCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly AdminViewModel _adminViewModel;
        private readonly IRegisterService _registerService;
        public RegisterCommand(IRegisterService registerService,AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _registerService = registerService;
        }
        
        public override async Task ExecuteAsync(object parameter)
        {
            _log.Info("Executed Register Command");

            await _registerService.Register(_adminViewModel.Username, _adminViewModel.Password, _adminViewModel.FirstName,
                _adminViewModel.LastName, _adminViewModel.IsAdmin);
        }
    }
}