using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IReviewDal : IGenericDal<Review>
    {
        List<SelectListItem> GetStarList();


    }
}
