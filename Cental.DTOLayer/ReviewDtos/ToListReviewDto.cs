﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.ReviewDtos
{
    public class ToListReviewDto
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }//navigation property
        public virtual AppUser User { get; set; }
        public int UserId { get; set; }
    }
}
