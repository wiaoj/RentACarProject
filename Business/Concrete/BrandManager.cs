﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class BrandManager : IBrandService {
        readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand) {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand) {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandRemoved);
        }

        public IDataResult<List<Brand>> GetAll() {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand?> GetById(int brandId) {
            return new SuccessDataResult<Brand?>(_brandDal.Get(b => b.Id.Equals(brandId)));
        }

        public IResult Update(Brand brand) {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}