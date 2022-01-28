using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class UserManager : IUserService {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal) {
            _userDal = userDal;
        }

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

        public IDataResult<User?> GetById(User userId) {
            return new SuccessDataResult<User?>(_userDal.Get(u => u.Id.Equals(userId)));
        }

        public IResult Update(User user) {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
