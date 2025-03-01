using Cental.DTOLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cental.BusinessLayer.Abstract
{
    public interface IReviewService : IGenericService<Review,ToListReviewDto,CreateReviewDto,UpdateReviewDto>
    {
        public List<SelectListItem> TGetStarList();

    }
}
