using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract {
    public interface IUserService {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(String emailAdress);
    }
}