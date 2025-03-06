using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrate
{
    public class EfTopBarDal : GenericRepository<TopBar> , ITopBarDal
    {
        public EfTopBarDal(CentalContext context) : base(context)
        {
        }
    }
}
