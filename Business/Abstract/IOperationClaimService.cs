using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract {
    public interface IOperationClaimService {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IDataResult<OperationClaim> GetById(int id);
        IDataResult<List<OperationClaim>> GetAll();
    }
}