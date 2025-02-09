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

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.Name, to => to.MapFrom(source => source.FirstName));

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.Surname, to => to.MapFrom(source => source.LastName));

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.AdminProfileImageFile, to => to.MapFrom(source => source.ProfilePicture));


            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.Email, to => to.MapFrom(source => source.Email));

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.PhoneNumber, to => to.MapFrom(source => source.PhoneNumber));

            CreateMap<AppUser, ProfileEditDto>().ForMember(destination => destination.Name, to => to.MapFrom(source => source.FirstName));      

        }
    }
}
