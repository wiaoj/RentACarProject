using Core.Entities.Abstract;

namespace Entities.Concrete {
    public class Color : IEntity {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}