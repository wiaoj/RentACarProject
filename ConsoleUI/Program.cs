// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager = new(new InMemoryCarDal());

carManager.GetAll().ForEach(car => Console.WriteLine($"Id: {car.Id} BrandId: {car.BrandId} ColorId: {car.ColorId} ModelYear: {car.Modelyear} Price: ${car.DailyPrice} daily Description: {car.Description}"));


#region 2.seçenek
//foreach (var car in carManager.GetAll()) {
//    Console.WriteLine($"{car.Id} {car.BrandId} {car.ColorId} {car.Modelyear} {car.DailyPrice} {car.Description}");
//}
#endregion