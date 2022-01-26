using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : ICarDal {
        public void Add(Car entity) {
            using (RecapContext context = new()) {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity) {
            using (RecapContext context = new()) {
                var removedEntity = context.Entry(entity);
                removedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter) {
            using (RecapContext context = new()) {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null) {
            using (RecapContext context = new()) {
                return filter is null ? 
                    context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity) {
            using (RecapContext context = new()) {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
