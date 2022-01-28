using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface ICustomerService {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer?> GetById(int customerId);
        IDataResult<List<Customer>> GetAll();
        

    }
}
