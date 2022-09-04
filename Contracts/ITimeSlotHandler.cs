using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Contracts
{
    public interface ITimeSlotHandler
    {
        [OperationContract] Task Add(TimeSlotDto entity);
        [OperationContract] Task Delete(TimeSlotDto entity);
        [OperationContract] Task Update(TimeSlotDto entity);
        [OperationContract] Task<List<TimeSlotDto>> GetAll();
    }
}
