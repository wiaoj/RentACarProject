using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
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

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color) {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color) {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorRemoved);
        }
        
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color?> GetById(int id) {
            return new SuccessDataResult<Color?>(_colorDal.Get(c => c.Id.Equals(id)));
        }
        
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color) {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
