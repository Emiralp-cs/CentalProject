using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.TopBarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class TopBarManager : GenericManager<TopBar, ToListTopBarDto, CreateTopBarDto, UpdateTopBarDto> , ITopBarService
    {
        public TopBarManager(IMapper mapper, IGenericDal<TopBar> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
