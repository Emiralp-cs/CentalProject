using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.BookingDtos
{
    public class CreateBookingDto
    {
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public bool? IsApproved { get; set; }
        public int Price { get; set; }
        public int PriceTimesBookingDays { get; set; }
        public string? PickUpLocation { get; set; }
        public string? DropOffLocation { get; set; }
        public virtual AppUser? User { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
    }
}
