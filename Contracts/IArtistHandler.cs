using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface IArtistHandler
    {
        [OperationContract] Task Add(ArtistDto entity);
        [OperationContract] Task Delete(ArtistDto entity, bool confirmed = false);
        [OperationContract] Task Update(ArtistDto entity, bool confirmed = false);
        [OperationContract] Task<List<ArtistDto>> GetAll(Guid timeSlotId);
    }
}
