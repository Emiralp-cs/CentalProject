using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IUserSocialService : IGenericService<UserSocial, ResultUserSocialDto, CreateUserSocialDto, UpdateUserSocialDto>
    {
        List<ResultUserSocialDto> TGetSocialsByUserId(int userId);
    }
}
