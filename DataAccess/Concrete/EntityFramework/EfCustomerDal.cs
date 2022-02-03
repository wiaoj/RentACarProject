using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal { 
        public List<CustomerDetailDto> GetCustomerDetails() {
            using ReCapContext context = new();
            var result = from customer in context.Customers
                         join user in context.Users
                         on customer.UserId equals user.Id
                         select new CustomerDetailDto {
                             Id = customer.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             EmailAdress = user.EmailAdress,
                             CompanyName = customer.CompanyName
                         };
            return result.ToList();
        }
    }
}