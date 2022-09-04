using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }

        public string Genre { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Version { get; set; } = DateTime.Now;
    }
}
