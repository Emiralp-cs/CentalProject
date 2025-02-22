﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.UserDtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public string ProfilePicture { get; set; }
        public virtual List<UserSocial> UserSocials { get; set; }

    }
}
