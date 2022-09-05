using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;

namespace Client.ViewModels
{
    internal class ArtistListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<ArtistViewModel> _artists;

        public ICommand RefreshCommand;

        public ICommand NavigateFestivalCommand;

        public ICommand LogoutCommand;

        public ICommand DeleteCommand;

        public ICommand AddCommand;

        public ICommand UpdateCommand;
        public ArtistListingViewModel(Guid timeSlotId)
        {
            _artists = new ObservableCollection<ArtistViewModel>();

            LogoutCommand = new LogoutCommand();

            NavigateFestivalCommand = new NavigateFestivalCommand();

            RefreshCommand = new RefreshArtistsCommand(_artists,timeSlotId);
        }
    }
}
