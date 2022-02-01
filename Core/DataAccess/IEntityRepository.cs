using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess {
    public interface IEntityRepository<Type> where Type : class, IEntity, new() {
        void Add(Type entity);
        void Update(Type entity);
        void Delete(Type entity);
        Type Get(Expression<Func<Type, bool>> filter);
        List<Type> GetAll(Expression<Func<Type, bool>>? filter = null);
    }
}
