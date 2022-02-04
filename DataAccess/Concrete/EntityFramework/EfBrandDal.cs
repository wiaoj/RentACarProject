using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework {
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal { }
}
