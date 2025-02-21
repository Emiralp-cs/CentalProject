using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.CarDtos
{
    public class BookingCarDto
    {
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public int SeatCount { get; set; }
        public string GearType { get; set; }
        public string GasType { get; set; }
        public int Year { get; set; }
        public int Kilometer { get; set; }
        public string BrandAndModel { get; set; }
    }
}
