using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UserRegisterDto>().ReverseMap();

            CreateMap<AppUser, ProfileEditDto>().ReverseMap();

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.ImageUrl, o => o.MapFrom(source => source.ProfilePicture));

            CreateMap<AppUser, ResultUserDto>().ReverseMap();
        }
    }
}
