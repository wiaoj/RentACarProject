using Core.Entities;

namespace Entities.DTOs {
    public class CarDetailDto : IDto {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? BrandName { get; set; }
        public String? ColorName { get; set; }
        public int Modelyear { get; set; }
        public decimal DailyPrice { get; set; }
        public String? Description { get; set; }
    }
}
