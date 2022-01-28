using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;



GetCar();


static void GetCar() {
    CarManager carManager = new(new EfCarDal());

    carManager.GetCarDetails().Data.ForEach(car => Console.WriteLine($"Car: {car.Name} Brand: {car.BrandName} Color: {car.ColorName} Price: ${car.DailyPrice} daily"));

}