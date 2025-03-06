using Cental.DTOLayer.FooterDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IFooterService : IGenericService<Footer,ToListFooterDto,CreateFooterDto,UpdateFooterDto>
    {
    }
}
