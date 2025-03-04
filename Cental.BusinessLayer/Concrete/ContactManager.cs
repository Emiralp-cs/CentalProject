using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.ContactDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ContactManager : GenericManager<Contact, ToListContactDto, CreateContactDto, UpdateContactDto>,IContactService
    {
        public ContactManager(IMapper mapper, IGenericDal<Contact> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
