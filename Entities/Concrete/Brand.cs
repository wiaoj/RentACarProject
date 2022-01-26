using Entities.Abstract;

namespace Entities.Concrete {
    public class Brand : IEntity {
        public int Id { get; set; }
        public String? Name { get; set; }
    }
}
