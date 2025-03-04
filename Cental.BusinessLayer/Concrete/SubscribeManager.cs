using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.SubscribeDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class SubscribeManager : GenericManager<Subscribe, ToListSubscribeDto, CreateSubscribeDto, UpdateSubscribeDto>, ISubscribeService
    {
        public SubscribeManager(IMapper mapper, IGenericDal<Subscribe> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
