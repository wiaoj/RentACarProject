using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
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

        [SecuredOperation("admin,color.admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color) {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [SecuredOperation("admin,color.admin,color.delete")]
        public IResult Delete(Color color) {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorRemoved);
        }

        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id) {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id.Equals(id)));
        }

        [SecuredOperation("admin,color.admin,color.update")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color) {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}