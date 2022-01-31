using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework {
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal {
        public List<CarRentalDetailDto> GetRentalDetails() {
            using (ReCapContext context = new()) {
                var result = from car in context.Cars
                             join rental in context.Rentals on car.Id equals rental.CarId
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new CarRentalDetailDto {
                                 RentalId = rental.Id,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CustomerCompanyName = customer.CompanyName,
                                 CarName = car.Name,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
