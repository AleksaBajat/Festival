using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.State.Authentication;

namespace Client.ViewModels
{
    internal class AddUpdateStageViewModel:BaseViewModel
    {
        private StageViewModel _viewModel;

        private readonly string _type;

        public string WindowType => _type;

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

        public int StageId => _viewModel.StageId;

        public DateTime Version => _viewModel.Version;

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public AddUpdateStageViewModel(StageViewModel viewModel,string type)
        {
            _viewModel = viewModel;

            if (type == "add")
            {
                _type = "Add Festival";
                AddOrUpdateCommand = new AddStageCommand();
            }else if (type == "edit")
            {
                _type = "Edit Festival";
                AddOrUpdateCommand = new UpdateStageCommand();
            }

            LogoutCommand = new LogoutCommand();
            NavigateFestivalCommand = new NavigateFestivalCommand();
        }
    }
}
