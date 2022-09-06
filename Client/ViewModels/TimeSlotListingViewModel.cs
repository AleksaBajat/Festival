using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    public class TimeSlotListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<TimeSlotViewModel> _timeSlots;

        public IEnumerable<TimeSlotViewModel> TimeSlots => _timeSlots;

        public ICommand RefreshCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand ArtistsCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        private TimeSlotViewModel _selected;

        public TimeSlotViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
                ((BaseCommand)EditCommand).OnCanExecuteChanged();
                ((AsyncBaseCommand)DeleteCommand).OnCanExecuteChanged();
                ((BaseCommand)ArtistsCommand).OnCanExecuteChanged();
            }
        }

        public TimeSlotListingViewModel(ITimeSlotService timeSlotService,INavigationService navigationService,IAuthenticator authenticator,Guid stageId)
        {
            _timeSlots = new ObservableCollection<TimeSlotViewModel>();

            RefreshCommand = new RefreshTimeSlotsCommand(timeSlotService,_timeSlots, stageId);
            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);
            LogoutCommand = new LogoutCommand(authenticator,navigationService);
            ArtistsCommand = new NavigateArtistsCommand(navigationService,this);
            DeleteCommand = new DeleteTimeSlotCommand(timeSlotService,navigationService,this);
            AddCommand = new NavigateAddTimeSlotCommand(navigationService,stageId);
            EditCommand = new NavigateEditTimeSlotCommand(navigationService, this);
            RefreshCommand.Execute(null);
        }
    }
}
