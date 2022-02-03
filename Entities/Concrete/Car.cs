using Core.Entities.Abstract;

namespace Entities.Concrete {
    public class Car : IEntity {
        public int Id { get; set; }
        public String Name { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public String Description { get; set; }
    }
}