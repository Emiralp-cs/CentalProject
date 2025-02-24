using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BookingManager : GenericManager<Booking, ToListBookingDto, CreateBookingDto, UpdateBookingDto>, IBookingService
    {
        public BookingManager(IMapper mapper, IGenericDal<Booking> genericDal) : base(mapper, genericDal)
        {
        }
    }
}
