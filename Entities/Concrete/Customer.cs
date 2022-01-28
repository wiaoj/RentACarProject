using Core.Entities;

namespace Entities.Concrete {
    public class Customer : IEntity {
        public int UserId { get; set; }
        public String? CompanyName { get; set; }
    }
}
