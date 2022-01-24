﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete {
    public class Car : IEntity{
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int Modelyear { get; set; }
        public decimal DailyPrice { get; set; }
        public String? Description { get; set; }
    }
}