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
    public interface IStageHandler
    {
        [OperationContract] Task Add(StageDto entity);
        [OperationContract] Task Duplicate(StageDto entity);
        [OperationContract] Task Delete(StageDto entity);
        [OperationContract] Task Update(StageDto entity);
        [OperationContract] Task<List<StageDto>> GetAll();
    }
}
