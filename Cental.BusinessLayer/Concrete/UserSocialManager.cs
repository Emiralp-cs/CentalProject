using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class UserSocialManager : GenericManager<UserSocial, ResultUserSocialDto, CreateUserSocialDto, UpdateUserSocialDto>, IUserSocialService
    {

        private readonly IUserSocialDal _userSocialDal;

        private readonly IMapper _mapper;


        public UserSocialManager(IMapper mapper, IGenericDal<UserSocial> genericDal, IUserSocialDal userSocialDal) : base(mapper, genericDal)
        {
            _mapper = mapper;
            _userSocialDal = userSocialDal;
        }

        public List<ResultUserSocialDto> TGetSocialsByUserId(int userId)
        {
            var values = _userSocialDal.GetSocialsByUserId(userId);

            return _mapper.Map<List<ResultUserSocialDto>>(values);


        }

    }
}
