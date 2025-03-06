using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.ServicesDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ServicesManager : GenericManager<Service, ToListServicesDto, CreateServiceDto, UpdateServiceDto> , IServicesService
    {
        public ServicesManager(IMapper mapper, IGenericDal<Service> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
