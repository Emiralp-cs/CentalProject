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
    public class EfIsApprovedDal : GenericRepository<CheckIsApproved>
    {
        public EfIsApprovedDal(CentalContext context) : base(context)
        {
        }
    }
}
