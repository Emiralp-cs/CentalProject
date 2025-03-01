using Cental.DTOLayer.IsApprovedDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IIsApprovedService : IGenericService<CheckIsApproved,ToListIsApprovedDto,CreateIsApprovedDto,UpdateIsApprovedDto>
    {
    }
}
