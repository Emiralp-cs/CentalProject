using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.FooterDtos
{
    public class UpdateFooterDto
    {
        public int FooterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
