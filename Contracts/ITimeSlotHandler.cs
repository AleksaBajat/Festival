using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface ITimeSlotHandler
    {
        [OperationContract] Task Add(TimeSlotDto entity);
        [OperationContract] Task Delete(TimeSlotDto entity, bool confirmed = false);
        [OperationContract] Task Update(TimeSlotDto entity, bool confirmed = false);
        [OperationContract] Task<List<TimeSlotDto>> GetAll(Guid stageId);
    }
}
