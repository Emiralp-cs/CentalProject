using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.CarDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager : GenericManager<Car, ToListCarDto, CreateCarDto, UpdateCarDto>,ICarService
    {

        private readonly ICarDal _cardal;

       

        public CarManager(IMapper mapper, IGenericDal<Car> genericDal,ICarDal cardal) : base(mapper, genericDal)
        {
            _cardal = cardal;
        }

        public List<Car> TGetCarsWithBrands()
        {
             return _cardal.GetCarsWithBrands();
        }
    }
}
