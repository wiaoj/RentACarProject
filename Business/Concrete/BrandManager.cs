using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class BrandManager : IBrandService {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal) {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand) {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand) {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandRemoved);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<List<Brand>> GetAll() {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand?> GetById(int id) {
            return new SuccessDataResult<Brand?>(_brandDal.Get(b => b.Id.Equals(id)));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand) {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
