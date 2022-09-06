using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    internal class AddUpdateStageViewModel:BaseViewModel
    {
        private readonly StageViewModel _viewModel;

        public StageViewModel ViewModel => _viewModel;

        private readonly string _type;

        public string WindowType => _type;

        public bool IsEdit => WindowType == "Edit Festival";

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Guid StageId => _viewModel.StageId;

        public DateTime Version => _viewModel.Version;

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public AddUpdateStageViewModel(IAuthenticator authenticator, INavigationService navigationService,IStageService stageService, StageViewModel viewModel,string type)
        {
            _viewModel = viewModel;
            _name = _viewModel.Name;

            if (type == "add")
            {
                _type = "Add Festival";
                AddOrUpdateCommand = new AddStageCommand(navigationService,stageService,this);
            }else
            {
                _type = "Edit Festival";
                AddOrUpdateCommand = new UpdateStageCommand(navigationService,stageService,this);
            }

            LogoutCommand = new LogoutCommand(authenticator,navigationService);
            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);
        }
    }
}
