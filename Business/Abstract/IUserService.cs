using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IUserService {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User?> GetById(User userId);
        IDataResult<List<User>> GetAll();
    }
}
