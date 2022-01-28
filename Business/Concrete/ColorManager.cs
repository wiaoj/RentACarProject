using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class ColorManager : IColorService {
        private readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal) {
            _colorDal = colorDal;
        }

        public IResult Add(Color color) {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color) {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorRemoved);
        }

        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color?> GetById(int colorId) {
            return new SuccessDataResult<Color?>(_colorDal.Get(c => c.Id.Equals(colorId)));
        }

        public IResult Update(Color color) {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
