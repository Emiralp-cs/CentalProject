﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.IsApprovedDtos
{
    public class UpdateIsApprovedDto
    {
        public int CheckIsApprovedId { get; set; }

        public bool IsApprovedP { get; set; }

        public int CarIdP { get; set; }

        public int BookingIdP { get; set; }
    }
}
