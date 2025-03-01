using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Car : BaseEntity
    {
        public int CarId { get; set; }
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
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public virtual AppRole Role { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Brand Brand { get; set; } //navigation Property
        public bool IsRented { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public bool? IsApproved { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        // Bitiş Tarihinden Başlangıç Tarihi Çıkartılarak Aradaki gün sayısı x günlük kiralanma bedeli
        // 






    }
}
