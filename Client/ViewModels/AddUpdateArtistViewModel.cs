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
    internal class AddUpdateArtistViewModel:BaseViewModel
    {
        private readonly ArtistViewModel _viewModel;

        public ArtistViewModel ViewModel => _viewModel;

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

        private string _surname;
        private string _genre;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public ICommand AddOrUpdateCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public AddUpdateArtistViewModel(IAuthenticator authenticator, INavigationService navigationService,IArtistService artistService, ArtistViewModel viewModel, string type)
        {
            _viewModel = viewModel;

            LogoutCommand = new LogoutCommand(authenticator,navigationService);
            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);
            _name = viewModel.Name;
            _surname = viewModel.Surname;
            _genre = viewModel.Genre;

            if (type == "add")
            {
                _type = "Add Artist";
                AddOrUpdateCommand = new AddArtistCommand(navigationService, artistService, this);
            }
            else
            {
                _type = "Edit Artist";
                AddOrUpdateCommand = new UpdateArtistCommand(navigationService, artistService, this);
            }
        }
    }
}
