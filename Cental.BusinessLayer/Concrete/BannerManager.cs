using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BannerManager : GenericManager<Banner, ToListBannerDto, CreateBannerDto, UpdateBannerDto>, IBannerService
    {
        public BannerManager(IMapper mapper, IGenericDal<Banner> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
