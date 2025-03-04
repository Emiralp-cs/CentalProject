﻿using Cental.DTOLayer.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.FeatureDtos
{
    public class ToListFeatureDTO : BaseDto
    {
        public int FeatureId { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }
        public string  Icon { get; set; }
    }
}
