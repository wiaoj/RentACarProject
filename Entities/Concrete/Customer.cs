﻿using Core.Entities.Abstract;

namespace Entities.Concrete {
    public class Customer : IEntity {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String CompanyName { get; set; }
    }
}