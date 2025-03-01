using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Cental.DataAccessLayer.Concrate
{
    public class EfReviewDal : GenericRepository<Review>, IReviewDal
    {
        public EfReviewDal(CentalContext context) : base(context)
        {
        }

        public List<SelectListItem> GetStarList()
        {
            var selectList = (from x in _context.RatingStars.ToList()
                              select new SelectListItem // Doğru SelectListItem sınıfı
                              {
                                  Text = x.RatingStarSelectable,
                                  Value = x.RatingStarsCounter.ToString()
                              }).ToList();

            return selectList;
        }
    }
}