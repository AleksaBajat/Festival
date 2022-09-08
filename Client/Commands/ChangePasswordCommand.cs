using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class ChangePasswordCommand:AsyncBaseCommand
    {
        private readonly IRegisterService _registerService;
        private readonly ProfileViewModel _profileViewModel;

        public ChangePasswordCommand(ProfileViewModel profileViewModel,IRegisterService registerService)
        {
            _profileViewModel = profileViewModel;
            _registerService = registerService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _registerService.ChangePassword(_profileViewModel.Username, _profileViewModel.Password);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_profileViewModel.Password) && base.CanExecute(parameter);
        }
    }
}
