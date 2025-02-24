﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.CarDtos
{
    public class UICarDto
    {
        
        public string ModelName { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int SeatCount { get; set; }
        public string GearType { get; set; }
        public string GasType { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public int Kilometer { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; } //navigation Property
    }
}
