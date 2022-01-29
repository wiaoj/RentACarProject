using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;



GetCar();
Console.WriteLine(new String('-', 20));
AddRental();

static void GetCar() {
    CarManager carManager = new(new EfCarDal());

    carManager.GetCarDetails().Data.ForEach(car => Console.WriteLine($"Car: {car.Name} Brand: {car.BrandName} Color: {car.ColorName} Price: ${car.DailyPrice} daily"));

}

static void AddRental() {
    Rental rental = new() {
        CarId = 1,
        CustomerId = 1,
        RentDate = DateTime.Now,
        //ReturnDate = Convert.ToDateTime("10.12.2021"),
    };
    RentalManager rentalManager = new(new EfRentalDal());
    rentalManager.Add(rental);

    rentalManager.GetRentalDetails().Data.ForEach(rental => Console.WriteLine($"{rental.RentalId} {rental.CarName} {rental.CustomerFirstName} {rental.CustomerLastName} {rental.CustomerCompanyName} ${rental.DailyPrice} {rental.BrandName} {rental.ColorName} {rental.RentDate} {rental.ReturnDate}"));
}