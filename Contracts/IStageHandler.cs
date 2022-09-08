using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Faults;
using DTO;

namespace Contracts
{
    [ServiceContract]
    public interface IStageHandler
    {
        [OperationContract] Task Add(StageDto entity,bool confirmed = false);
        [OperationContract] [FaultContract(typeof(ConflictFault))] Task Duplicate(StageDuplicateDto entity, bool confirmed = false);
        [OperationContract] [FaultContract(typeof(ConflictFault))] Task Delete(StageDto entity, bool confirmed = false);
        [OperationContract] [FaultContract(typeof(ConflictFault))] Task Update(StageDto entity, bool confirmed = false);
        [OperationContract] Task<List<StageDto>> GetAll();

        [OperationContract] Task<List<StageDto>> Search(string parameter);
    }
}
