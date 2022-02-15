using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface ICreditCardService {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);

        IResult Payment(CreditCard creditCard);

        IDataResult<CreditCard> GetById(int id);
        IDataResult<List<CreditCard>> GetAll();
    }
}