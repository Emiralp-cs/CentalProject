﻿using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrate
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {   

        public EfCarDal(CentalContext context) : base(context)
        {
        }
        //Eager Loading
        public List<Car> GetCarsWithBrands()
        {
          return  _context.Cars.Include(x => x.Brand).ToList();
        }
    }
}
