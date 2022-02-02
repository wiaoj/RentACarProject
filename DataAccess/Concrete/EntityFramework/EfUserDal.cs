using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework {
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal { 
        public List<OperationClaim> GetClaims(User user) {
            using var context = new ReCapContext();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId.Equals(user.Id)
                         select new OperationClaim {
                             Id = userOperationClaim.Id,
                             Name = operationClaim.Name
                         };
            //if (result.ToList().Any()) {
            //    new OperationClaim {
            //        Id = 3,
            //        Name = "User"
            //    };
            //}
            return result.ToList();
        }
    }
}