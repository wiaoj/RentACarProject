using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IRentalService {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetAll();
        //IResult CheckRentalCar(Rental rental);
    }
}
