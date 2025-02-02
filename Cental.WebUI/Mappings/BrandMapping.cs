using AutoMapper;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, ToListBrandDTO>().ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
        }

    }
}
