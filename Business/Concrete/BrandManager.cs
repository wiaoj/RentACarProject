using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    //[SecuredOperation("admin,brand.admin")]
    public class BrandManager : IBrandService {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal) {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin,brand.admin,brand.add")]//Business.Constant.SecuredOperationClaims.Brand
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand) {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin,brand.admin,brand.delete")]
        public IResult Delete(Brand brand) {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandRemoved);
        }
        public IDataResult<List<Brand>> GetAll() {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id) {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id.Equals(id)));
        }

        [SecuredOperation("admin,brand.admin,brand.update")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand) {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}