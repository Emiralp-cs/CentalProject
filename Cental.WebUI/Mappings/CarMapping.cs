using AutoMapper;
using Cental.DTOLayer.CarDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car ,ToListCarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
        }

    }
}
