using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ViewModels
{
    public class ArtistViewModel:BaseViewModel
    {
        private readonly Artist _artist;

        public Guid ArtistId => _artist.ArtistId;

        public Guid TimeSlotId => _artist.TimeSlotId;

        public string Genre => _artist.Genre;

        public string Name => _artist.Name;

        public string Surname => _artist.Surname;

        public DateTime Version => _artist.Version;

        public ArtistViewModel(Artist artist)
        {
            _artist = artist;
        }
    }
}
