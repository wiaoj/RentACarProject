using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete {
    public class CarImageManager : ICarImageService {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper) : this(carImageDal) => _fileHelper = fileHelper;
        public CarImageManager(ICarImageDal carImageDal) => _carImageDal = carImageDal;

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage) {
            IResult? result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null) return result;
            carImage.ImagePath = _fileHelper.Upload(file, Paths.ImagesPath);
            //carImage.Date = DateTime.Now; //Entities/CarImage.cs içinde default değer atandı
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage) {
            _fileHelper.Delete($"{ Paths.ImagesPath + carImage.ImagePath }");
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll() {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        public IDataResult<CarImage> GetById(int id) {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carImage => carImage.Id.Equals(id)));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId) {
            var result = BusinessRules.Run(CheckCarImage(carId));
            return result is not null ? 
                new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data) :
                new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(carImage => carImage.CarId.Equals(carId)));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage) {
            carImage.ImagePath = _fileHelper.Update(file, $"{ Paths.ImagesPath + carImage.ImagePath }", Paths.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        //static yapıldı resimde hata olursa bak
        private static IDataResult<List<CarImage>> GetDefaultImage(int carId) {
            List<CarImage> carImage = new();
            carImage.Add(new CarImage {
                CarId = carId,
                //Date = DateTime.Now, //Entities/CarImage.cs içinde default değer atandı
                ImagePath = $"{Paths.DefaultImagePath}"
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImage(int carId) {
            var result = _carImageDal.GetAll(carImage => carImage.CarId.Equals(carId)).Any();
            return result ? new SuccessResult() : new ErrorResult();
        }

        private IResult CheckIfCarImageLimitExceded(int carId) {
            var result = _carImageDal.GetAll(carImage => carImage.CarId.Equals(carId)).Count;
            return result >= 5 ? new ErrorResult(Messages.CarImageLimitExceded) : new SuccessResult();
        }
    }
}