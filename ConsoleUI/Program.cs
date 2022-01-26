using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new(new EfCarDal());

carManager.GetAll().ForEach(car => Console.WriteLine($"Id: {car.Id} BrandId: {car.BrandId} ColorId: {car.ColorId} ModelYear: {car.Modelyear} Price: ${car.DailyPrice} daily Description: {car.Description}"));

#region Second choise
//foreach (var car in carManager.GetAll()) {
//    Console.WriteLine($"{car.Id} {car.BrandId} {car.ColorId} {car.Modelyear} {car.DailyPrice} {car.Description}");
//}
#endregion