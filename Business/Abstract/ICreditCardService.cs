using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Abstract {
    public interface ICreditCardService {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);

        IResult Payment(CreditCard creditCard, int carId);

        IDataResult<CreditCard> GetByCustomerId(int customerId);
        //IDataResult<List<CreditCard>> GetAll();
    }
}