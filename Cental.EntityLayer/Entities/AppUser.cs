using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public virtual List<UserSocial> UserSocials { get; set; }
        public virtual List<Car> Cars { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Review> Reviews { get; set; }



    }
}
