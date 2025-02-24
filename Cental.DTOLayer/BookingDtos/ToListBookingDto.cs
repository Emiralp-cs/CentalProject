using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.BookingDtos
{
    public class ToListBookingDto
    {
        public int BookingId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public bool? IsApproved { get; set; }
        public int Price { get; set; }
        public int PriceTimesBookingDays { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
    }
}
