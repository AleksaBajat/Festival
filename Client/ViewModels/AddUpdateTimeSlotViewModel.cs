using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    public class AddUpdateTimeSlotViewModel:BaseViewModel
    {
        private readonly TimeSlotViewModel _viewModel;

        public TimeSlotViewModel ViewModel => _viewModel;

        private readonly string _type;

        public string WindowType => _type;

        public bool IsEdit => WindowType == "Edit Time Slot";

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private DateTime _from;
        private DateTime _to;

        public DateTime From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public DateTime To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public AddUpdateTimeSlotViewModel(IAuthenticator authenticator,INavigationService navigationService,ITimeSlotService timeSlotService,TimeSlotViewModel viewModel, string type)
        {
            _viewModel = viewModel;

            LogoutCommand = new LogoutCommand(authenticator);
            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);
            _from = viewModel.From;
            _to = viewModel.To;

            if (type == "add")
            {
                _type = "Add Time Slot";
                AddOrUpdateCommand = new AddTimeSlotCommand(navigationService,timeSlotService,this);
            }
            else
            {
                _type = "Edit Time Slot";
                Description = viewModel.Description;
                AddOrUpdateCommand = new UpdateTimeSlotCommand(navigationService,timeSlotService,this);
            }

        }
    }
}
