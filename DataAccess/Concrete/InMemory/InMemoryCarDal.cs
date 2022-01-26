using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryCarDal : ICarDal {

        List<Car> _cars;

        public InMemoryCarDal() {

            _cars = new List<Car> {
                new Car{ Id = 1, BrandId = 1,ColorId = 1, DailyPrice=260, Modelyear = 2002, Description = "Nefret ediyorum.."},
                new Car{ Id = 2, BrandId = 2,ColorId = 3, DailyPrice=250, Modelyear = 2000, Description = "Arabam"},
                new Car{ Id = 3, BrandId = 1,ColorId = 2, DailyPrice=380, Modelyear = 2022, Description = "Yeni aldığım araba :P"},
                new Car{ Id = 4, BrandId = 3,ColorId = 4, DailyPrice=200, Modelyear = 1990, Description = "İkinci Arabam"},
                new Car{ Id = 5, BrandId = 3,ColorId = 5, DailyPrice=180, Modelyear = 1980, Description = "Eski model"},
            };
        }
        public void Add(Car car) {
            _cars.Add(car);
        }

        public void Delete(Car car) {
            Car? carToDelete = _cars.SingleOrDefault(c => c.Id.Equals(car.Id));
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter) {
            throw new NotImplementedException();
        }

        public List<Car> GetAll() {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null) {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId) {
            return _cars.Where(c => c.Id.Equals(carId)).ToList();
        }

        public void Update(Car car) {
            Car? carToUpdate = _cars.SingleOrDefault(c => c.Id.Equals(car.Id));

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Modelyear = car.Modelyear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
