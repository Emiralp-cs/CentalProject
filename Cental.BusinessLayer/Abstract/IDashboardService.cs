using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IDashboardService 
    {
        public int TotalUserCountT();
        public int TotalBrandCountT();
        public int TotalCarCountT();
        public int TotalMessageCountT();
        public int TotalBookingCountT();
        public int ApprovedBookingCountT();
        public int DeclinedBookingCountT();
        public int WaitingBookingCountT();
        public int TotalReviewCountT();
        public double UserReviewAverageT();
        public List<Booking> WaitingBookingsListT();
        public List<Car> LastAddedCarsT();
        public List<Review> LastReviewsT();
    }
}
