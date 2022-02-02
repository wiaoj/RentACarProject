using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete {
    //[SecuredOperation("admin,car.admin")]
    public class CarManager : ICarService {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal) => _carDal = carDal;

        [SecuredOperation("admin,car.admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car) {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("admin,car.admin,car.deleten")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car) {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarRemoved);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll() {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id) {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id.Equals(id)));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails() {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId.Equals(brandId)));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId.Equals(colorId)));
        }

        [SecuredOperation("admin,car.admin,car.update")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}