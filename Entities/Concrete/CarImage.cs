using Core.Entities.Abstract;

namespace Entities.Concrete {
    public class CarImage : IEntity {
        public int Id { get; set; }
        public int CarId { get; set; }
        public String ImagePath { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}