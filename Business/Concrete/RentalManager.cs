using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class RentalManager : IRentalService {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal) {
            _rentalDal = rentaldal;
        }
        public IResult Add(Rental rental) {
            if (rental.ReturnDate.Equals(null))
                return new ErrorResult(Messages.RentalAddingFailed);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalRemoved);
        }

        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId) {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id.Equals(rentalId)));
        }

        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
