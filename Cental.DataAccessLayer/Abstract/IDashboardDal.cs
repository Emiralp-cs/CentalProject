using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IDashboardDal 
    {
        public int TotalUserCount();
        public int TotalBrandCount();
        public int TotalCarCount();
        public int TotalMessageCount();
        public int TotalBookingCount();
        public int ApprovedBookingCount();
        public int DeclinedBookingCount();
        public int WaitingBookingCount();
        public int TotalReviewCount();
        public double UserReviewAverage();
        public List<Booking> WaitingBookingsList();
        public List<Car> LastAddedCars();
        public List<Review> LastReviews();





    }
}
