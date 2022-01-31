using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IBrandService {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<Brand?> GetById(int id);
        IDataResult<List<Brand>> GetAll();
    }
}