using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IUserService {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User?> GetById(int id);
        IDataResult<List<User>> GetAll();
    }
}
