using AutoMapper;
using Cental.DTOLayer.AboutDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class AboutMapping : Profile
    {
        public AboutMapping() 
        {   
            var thisYear = DateTime.Now.Year;

            CreateMap<About,ToListAboutDto>().ForMember(destination => destination.StartYear,
                                        o => o.MapFrom(source => thisYear - source.StartYear));
            CreateMap<About,ToListAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();


        }
    }
}
