using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Client.Commands;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    public class StageListingViewModel:BaseViewModel
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

        public ICommand UndoCommand { get; set; }

        public ICommand RedoCommand { get; set; }

        public StageListingViewModel(IAuthenticator authenticator,IStageService stageService,INavigationService navigationService)
        {
            _authenticator = authenticator;
            _stages = new ObservableCollection<StageViewModel>();

            LogoutCommand = new LogoutCommand(authenticator,navigationService);
            RefreshCommand = new RefreshStagesCommand(stageService,_stages);
            NavigateAdminCommand = new NavigateAdminCommand(navigationService);
            TimeStampsCommand = new NavigateTimeSlotsCommand(navigationService,this);
            DuplicateCommand = new DuplicateStageCommand(navigationService,stageService,this);
            DeleteCommand = new DeleteStageCommand(navigationService,stageService,this);
            EditCommand = new NavigateEditStageCommand(navigationService,this);
            AddCommand = new NavigateAddStageCommand(navigationService);
            UndoCommand = new UndoPreviousCommand();
            RedoCommand = new RedoPreviousCommand();

            ((AsyncBaseCommand)UndoCommand).OnCanExecuteChanged();
            ((AsyncBaseCommand)RedoCommand).OnCanExecuteChanged();
            RefreshCommand.Execute(null);
        }
    }
}
