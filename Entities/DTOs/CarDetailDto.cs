﻿using Core.Entities.Abstract;

namespace Entities.DTOs {
    public class CarDetailDto : IDto {
        public int Id { get; set; }
        public String Name { get; set; }
        public String BrandName { get; set; }
        public String ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public String Description { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public List<String> ImagePath { get; set; }
    }
}