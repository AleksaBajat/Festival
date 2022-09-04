using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    public interface IArtistHandler
    {
        [OperationContract] Task Add(ArtistDto entity);
        [OperationContract] Task Delete(ArtistDto entity);
        [OperationContract] Task Update(ArtistDto entity);
        [OperationContract] Task<List<ArtistDto>> GetAll();
    }
}
