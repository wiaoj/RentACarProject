// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager = new(new InMemoryCarDal());

foreach (var car in carManager.GetAll()) {
    Console.WriteLine($"{car.Id} {car.BrandId} {car.ColorId} {car.Modelyear} {car.DailyPrice} {car.Description}");
}
