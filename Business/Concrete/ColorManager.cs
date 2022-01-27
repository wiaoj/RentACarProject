using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class ColorManager : IColorService {
        readonly IColorDal _color;

        public ColorManager(IColorDal color) {
            _color = color;
        }

        public void Add(Color color) {
            _color.Add(color);
        }

        public void Delete(Color color) {
            _color.Delete(color);
        }

        public List<Color> GetAll() {
            return _color.GetAll();
        }

        public Color GetById(int id) {
            return _color.Get(c => c.Id.Equals(id));
        }

        public void Update(Color color) {
            _color.Update(color);
        }
    }
}
