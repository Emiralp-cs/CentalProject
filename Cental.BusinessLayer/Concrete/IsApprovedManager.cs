using AutoMapper;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.IsApprovedDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class IsApprovedManager : GenericManager<CheckIsApproved, ToListIsApprovedDto, CreateIsApprovedDto, UpdateIsApprovedDto>
    {
        public IsApprovedManager(IMapper mapper, IGenericDal<CheckIsApproved> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
