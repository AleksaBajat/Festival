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

        private StageViewModel _selected;

        public StageViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
                ((BaseCommand)TimeStampsCommand).OnCanExecuteChanged();
                ((UndoBaseCommand)DeleteCommand).OnCanExecuteChanged();
                ((UndoBaseCommand)DuplicateCommand).OnCanExecuteChanged();
                ((BaseCommand)EditCommand).OnCanExecuteChanged();
            }
        }

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

        public ICommand RefreshCommand { get; set; }

        public ICommand TimeStampsCommand { get; set; }

        public ICommand DuplicateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public StageListingViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _stages = new ObservableCollection<StageViewModel>();

            LogoutCommand = new LogoutCommand();
            RefreshCommand = new RefreshStagesCommand(_stages);
            NavigateAdminCommand = new NavigateAdminCommand();
            TimeStampsCommand = new TimeStampsCommand(this);
            DuplicateCommand = new DuplicateStageCommand(this);
            DeleteCommand = new DeleteStageCommand(this);
            EditCommand = new NavigateEditStageCommand(this);
            AddCommand = new NavigateAddStageCommand();

            RefreshCommand.Execute(null);
        }
    }
}
