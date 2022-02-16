using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Internal;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete {
    //[SecuredOperation("admin")]
    public class RentalManager : IRentalService {
        private readonly IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal) => _rentalDal = rentaldal;

        //[SecuredOperation("admin,rental.admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental) {
            if (rental.ReturnDate.Equals(null))
                return new ErrorResult(Messages.RentalAddingFailed);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("admin,rental.admin,rental.delete")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalRemoved);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id) {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id.Equals(id)));
        }

        [CacheAspect]
        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails() {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult CheckIfCarIsAvailable(int carId, DateTime rentDate, DateTime returnDate) {
            var result = _rentalDal.GetAll(r => r.CarId.Equals(carId) && r.ReturnDate >= rentDate);

            return result.IsNullOrEmpty() ? new SuccessResult("This car is available") :
                new ErrorResult($"This car is not available. It is going to be available in: { result[result.Count - 1].ReturnDate.Value.ToString("yyyy-MM-dd") }");
        }

        [SecuredOperation("admin,rental.admin,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}