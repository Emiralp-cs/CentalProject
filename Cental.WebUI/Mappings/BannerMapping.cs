using AutoMapper;
using Cental.DTOLayer.BannerDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<Banner, ToListBannerDto>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
        }
    }
}
