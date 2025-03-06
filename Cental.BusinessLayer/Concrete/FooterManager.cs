using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Repositories;
using Cental.DTOLayer.FooterDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class FooterManager : GenericManager<Footer, ToListFooterDto, CreateFooterDto, UpdateFooterDto> , IFooterService
    {
        public FooterManager(IMapper mapper, IGenericDal<Footer> genericDal) : base(mapper, genericDal)
        {
        }
    }

}
