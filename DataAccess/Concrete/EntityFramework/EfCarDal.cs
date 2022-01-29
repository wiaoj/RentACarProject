using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal {
        public List<CarDetailDto> GetCarDetails() {
            using (RecapContext context = new()) {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto {
                                 Name = car.Name,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 ModelYear = car.Modelyear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                             };
                return result.ToList();
            }
        }
    }
}
