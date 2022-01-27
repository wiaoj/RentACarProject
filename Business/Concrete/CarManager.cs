using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete {
    public class CarManager : ICarService {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public void Add(Car car) {
            if (car.Description?.Length < 2)
                Console.WriteLine("Car name must be at least 2 characters");
            else if (car.DailyPrice <= 0)
                Console.WriteLine("Car daily price must be greate than 0");
            else {
                _carDal.Add(car);
                Console.WriteLine("Car Added!");
            }
        }

        public void Delete(Car car) {
            _carDal.Delete(car);
            Console.WriteLine("Car Deleted!");
        }

        public List<Car> GetAll() {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails() {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id) {
            return _carDal.GetAll(c => c.BrandId.Equals(id));
        }

        public List<Car> GetCarsByColorId(int id) {
            return _carDal.GetAll(c => c.ColorId.Equals(id));
        }

        public void Update(Car car) {
            _carDal.Update(car);
            Console.WriteLine("Car Updated!");
        }
    }
}
