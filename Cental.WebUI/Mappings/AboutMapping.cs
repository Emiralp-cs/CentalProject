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

            CreateMap<About,UIAboutDTO>().ForMember(destination => destination.ExperienceYear,
                                        o => o.MapFrom(source => thisYear - source.StartYear));


        }
    }
}
