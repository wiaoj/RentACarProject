using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract {
    public interface IRentalService {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<CarRentalDetailDto>> GetRentalDetails();
        IResult CheckIfCarIsAvailable(int carId, DateTime rentDate, DateTime returnDate);
        //IResult CheckRentalCar(Rental rental);
    }
}