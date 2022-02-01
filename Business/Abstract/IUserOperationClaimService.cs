using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract {
    public interface IUserOperationClaimService {
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IDataResult<UserOperationClaim> GetById(int id);
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<List<UserOperationClaim>> GetUserOperationClaimByUserId(int userId);
        IDataResult<List<UserOperationClaim>> GetUserOperationClaimByOperationClaimId(int operationClaimId);
    }
}