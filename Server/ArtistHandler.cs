using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DTO;

namespace Server
{
    internal class ArtistHandler:IArtistHandler
    {
        public Task Add(ArtistDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ArtistDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(ArtistDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArtistDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
