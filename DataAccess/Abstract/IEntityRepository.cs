using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract {
    public interface IEntityRepository<Type> where Type : class, IEntity, new() {
        List<Type> GetAll(Expression<Func<Type, bool>>? filter = null);
        Type Get(Expression<Func<Type, bool>> filter);
        void Add(Type entity);
        void Update(Type entity);
        void Delete(Type entity);
    }
}
