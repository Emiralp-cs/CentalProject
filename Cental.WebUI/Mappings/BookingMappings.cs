using AutoMapper;
using Cental.DTOLayer.BookingDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BookingMappings : Profile
    {
        public BookingMappings()
        {
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, ToListBookingDto>().ReverseMap();

        }

    }
}
