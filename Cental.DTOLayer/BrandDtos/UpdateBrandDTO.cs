﻿using Cental.DTOLayer.BaseDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.BrandDtos
{
    public class UpdateBrandDTO : BaseDto
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }


    }
}
