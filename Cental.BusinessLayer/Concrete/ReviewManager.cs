using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cental.BusinessLayer.Concrete
{
    public class ReviewManager : GenericManager<Review, ToListReviewDto, CreateReviewDto, UpdateReviewDto>, IReviewService
    {
        private readonly IReviewDal _reviewDal;

        public ReviewManager(IMapper mapper, IGenericDal<Review> genericDal,IReviewDal reviewDal) : base(mapper, genericDal)
        {
            _reviewDal = reviewDal;
        }

        public List<SelectListItem> TGetStarList()
        {
            return _reviewDal.GetStarList();
        }
    }
}
