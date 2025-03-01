using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.ReviewDtos
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }//navigation property
        public int BookingId { get; set; }
    }
}
