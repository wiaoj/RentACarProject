using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete {
    public class RentalManager : IRentalService {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal) {
            _rentalDal = rentaldal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental) {
            if (rental.ReturnDate.Equals(null))
                return new ErrorResult(Messages.RentalAddingFailed);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalRemoved);
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<Rental?> GetById(int id) {
            return new SuccessDataResult<Rental?>(_rentalDal.Get(r => r.Id.Equals(id)));
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails() {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
