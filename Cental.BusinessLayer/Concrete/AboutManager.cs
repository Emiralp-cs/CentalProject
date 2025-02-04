using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class AboutManager : GenericManager<About,ToListAboutDto,CreateAboutDto,UpdateAboutDto>,IAboutService
    {
       

        public AboutManager(IMapper mapper, IGenericDal<About> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
