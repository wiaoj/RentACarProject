using Core.Entities;

namespace Entities.Concrete {
    public class Car : IEntity {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int Modelyear { get; set; }
        public decimal DailyPrice { get; set; }
        public String? Description { get; set; }
    }
}