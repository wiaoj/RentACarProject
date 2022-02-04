using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract {
    public interface ICarDal : IEntityRepository<Car>{
        List<CarDetailDto> GetCarsDetails();
        List<CarDetailDto> GetCarDetailsById(int id);
        List<CarDetailDto> GetCarsDetailsByBrandId(int brandId);
        List<CarDetailDto> GetCarsDetailsByColorId(int colorId);
    }
}