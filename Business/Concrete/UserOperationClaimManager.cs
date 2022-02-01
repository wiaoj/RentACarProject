﻿using Business.Abstract;
using Business.Aspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;

namespace Business.Concrete {
    public class UserOperationClaimManager : IUserOperationClaimService {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal) => _userOperationClaimDal = userOperationClaimDal;

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Add(UserOperationClaim userOperationClaim) {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimAdded*/);
        }

        [SecuredOperation("admin")]
        //[ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Delete(UserOperationClaim userOperationClaim) {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimDeleted*/);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetAll() {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll()/*,Messages.UserOperationClaimsListed*/); 
        }

        [SecuredOperation("admin")]
        public IDataResult<UserOperationClaim> GetById(int id) {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id.Equals(id))/*, Messages.UserOperationClaimListed*/);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetUserOperationClaimByOperationClaimId(int operationClaimId) {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.OperationClaimId.Equals(operationClaimId)));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetUserOperationClaimByUserId(int userId) {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.UserId.Equals(userId)));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim) {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(/*Messages.UserOperationClaimUpdated*/);
        }
    }
}