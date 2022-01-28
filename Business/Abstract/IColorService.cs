using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IColorService {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color?> GetById(int colorId);
        IDataResult<List<Color>> GetAll();
    }
}
