using AutoMapper;
using Cental.DTOLayer.RoleDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<AppRole,ResultRoleDto>().ReverseMap();
            CreateMap<AppRole,CreateRoleDto>().ReverseMap();
            CreateMap<AppRole,UpdateRoleDto>().ReverseMap();
        }

    }
}
