using Business.Abstract;
using Business.Aspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;

namespace Business.Concrete {
    //[SecuredOperation("admin,operationClaims.admin")]
    public class OperationClaimManager : IOperationClaimService {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal) => _operationClaimDal = operationClaimDal;

        [SecuredOperation("operationClaims.add")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim) {
            IResult? result = BusinessRules.Run(CheckIfOperationClaimNameExists(operationClaim.Name));
            if (result != null) {
                return result;
            }
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimAdded*/);
        }

        [SecuredOperation("operationClaims.delete")]
        public IResult Delete(OperationClaim operationClaim) {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimDeleted)*/);
        }

        public IDataResult<List<OperationClaim>> GetAll() {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll()/*,Messages.OperationClaimListed*/);
        }

        public IDataResult<OperationClaim> GetById(int id) {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(u => u.Id.Equals(id))/*,Messages.OperationClaimListed*/);
        }

        [SecuredOperation("operationClaims.update")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim operationClaim) {
            IResult? result = BusinessRules.Run(CheckIfOperationClaimNameExists(operationClaim.Name));
            if (result != null) {
                return result;
            }
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(/*Messages.OperationClaimUpdated*/);
        }

        private IResult CheckIfOperationClaimNameExists(string operationClaimName) {
            return _operationClaimDal.GetAll(o => o.Name.Equals(operationClaimName)).Any() ?
                new ErrorResult(/*Messages.OperationClaimNameExists*/) :
                new SuccessResult();
        }
    }
}