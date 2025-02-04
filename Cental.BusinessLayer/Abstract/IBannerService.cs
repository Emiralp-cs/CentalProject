using Cental.DTOLayer.BannerDtos;
using Cental.DTOLayer.CarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IBannerService : IGenericService<Banner, ToListBannerDto, CreateBannerDto, UpdateBannerDto>
    {
    }
}
