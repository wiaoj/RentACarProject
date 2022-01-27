using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework {
    public class EfEntityRepositoryBase<TypeEntity, TypeContext> : IEntityRepository<TypeEntity>
        where TypeEntity : class, IEntity, new()
        where TypeContext : DbContext, new() {
        public void Add(TypeEntity entity) {
            using (TypeContext context = new()) {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TypeEntity entity) {
            using (TypeContext context = new()) {
                var removedEntity = context.Entry(entity);
                removedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TypeEntity Get(Expression<Func<TypeEntity, bool>> filter) {
            using (TypeContext context = new()) {
                return context.Set<TypeEntity>().SingleOrDefault(filter);
            }
        }

        public List<TypeEntity> GetAll(Expression<Func<TypeEntity, bool>>? filter = null) {
            using (TypeContext context = new()) {
                return filter is null ?
                    context.Set<TypeEntity>().ToList() :
                    context.Set<TypeEntity>().Where(filter).ToList();
            }
        }

        public void Update(TypeEntity entity) {
            using (TypeContext context = new()) {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
