using Core.Entities.Abstract;

namespace Entities.DTOs {
    public class CustomerDetailDto : IDto {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAdress { get; set; }
        public String CompanyName { get; set; }
    }
}