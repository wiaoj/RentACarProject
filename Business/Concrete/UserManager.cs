using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;

namespace Business.Concrete {
    public class UserManager : IUserService {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal) {
            _userDal = userDal;
        }

        //[SecuredOperation("admin,user.admin,user.add")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user) {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user) {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll() {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id) {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id.Equals(id)));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user) {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user) {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string emailAdress) {
            return new SuccessDataResult<User>(_userDal.Get(u => u.EmailAdress.Equals(emailAdress)));
        }
    }
}