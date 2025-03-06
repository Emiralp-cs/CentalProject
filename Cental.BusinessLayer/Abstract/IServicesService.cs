using Cental.DTOLayer.ServicesDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IServicesService : IGenericService<Service, ToListServicesDto, CreateServiceDto, UpdateServiceDto>
    {
    }
}
