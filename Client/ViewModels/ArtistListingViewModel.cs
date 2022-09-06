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
    public class ArtistListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<ArtistViewModel> _artists;

        private ArtistViewModel _selected;

        public ArtistViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
                ((BaseCommand)DeleteCommand).OnCanExecuteChanged();
            }
        }

        public IEnumerable<ArtistViewModel> Artists => _artists;



        public ICommand RefreshCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ArtistListingViewModel(IAuthenticator authenticator,INavigationService navigationService,IArtistService artistService,Guid timeSlotId)
        {
            _artists = new ObservableCollection<ArtistViewModel>();

            LogoutCommand = new LogoutCommand(authenticator,navigationService);

            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);

            RefreshCommand = new RefreshArtistsCommand(artistService,_artists,timeSlotId);

            DeleteCommand = new DeleteArtistCommand(artistService, navigationService, this);

            AddCommand = new NavigateAddArtistCommand(navigationService,timeSlotId);

            EditCommand = new NavigateEditArtistCommand(navigationService, this);

            RefreshCommand.Execute(null);
        }
    }
}
