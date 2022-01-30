using Core.Entities;

namespace Entities.Concrete {
    public class User : IEntity {
        public int Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? EmailAdress { get; set; }
        public String? Password { get; set; }
    }
}
