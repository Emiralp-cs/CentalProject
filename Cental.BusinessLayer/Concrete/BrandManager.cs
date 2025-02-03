using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BrandManager : GenericManager<Brand, ToListBrandDTO, CreateBrandDTO, UpdateBrandDTO>,IBrandService
    {
        public BrandManager(IMapper mapper, IGenericDal<Brand> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
