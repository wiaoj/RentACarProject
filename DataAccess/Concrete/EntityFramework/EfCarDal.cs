using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal {
        public List<CarDetailDto> GetCarsDetails() {
            using ReCapContext context = new();
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         select new CarDetailDto {
                             Id = car.Id,
                             Name = car.Name,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                         };
            return result.ToList();
        }
        public List<CarDetailDto> GetCarDetailsById(int id) {
            using ReCapContext context = new();
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         where car.Id.Equals(id)
                         select new CarDetailDto {
                             Id = car.Id,
                             Name = car.Name,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath ?? new String('-', 20)).ToList()
                         };
            return result.ToList();
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId) {
            using ReCapContext context = new();
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         where brand.Id.Equals(brandId)
                         select new CarDetailDto {
                             Id = car.Id,
                             Name = car.Name,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                         };
            return result.ToList();
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId) {
            using ReCapContext context = new();
            var result = from car in context.Cars
                         join brand in context.Brands
                         on car.BrandId equals brand.Id
                         join color in context.Colors
                         on car.ColorId equals color.Id
                         where color.Id.Equals(colorId)
                         select new CarDetailDto {
                             Id = car.Id,
                             Name = car.Name,
                             BrandName = brand.Name,
                             ColorName = color.Name,
                             ModelYear = car.ModelYear,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             //ImagePath = (from image in context.CarImages where image.CarId.Equals(car.Id) select image.ImagePath).FirstOrDefault()
                         };
            return result.ToList();
        }
    }
}