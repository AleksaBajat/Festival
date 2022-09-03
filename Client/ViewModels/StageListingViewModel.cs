using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Models;
using Client.State.Authentication;
using GalaSoft.MvvmLight.Command;

namespace Client.ViewModels
{
    internal class StageListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<StageViewModel> _stages;

        private readonly IAuthenticator _authenticator;

        private bool _isAdmin;

        public IEnumerable<StageViewModel> Stages => _stages;

        public bool IsAdmin
        {
            get
            {
                return _authenticator.IsAdmin;
            }

            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public ICommand NavigateAdminCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand Refresh { get; set; }

        public StageListingViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _stages = new ObservableCollection<StageViewModel>();
            LogoutCommand = new LogoutCommand();
            Refresh = new RefreshStagesCommand(_stages);
        }
    }
}
