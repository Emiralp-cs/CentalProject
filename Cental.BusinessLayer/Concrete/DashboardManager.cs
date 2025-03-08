using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager(IDashboardDal _dashboardDal) : IDashboardService
    {
        public int ApprovedBookingCountT()
        {
           return _dashboardDal.ApprovedBookingCount();
        }

        public int DeclinedBookingCountT()
        {
            return _dashboardDal.DeclinedBookingCount();
        }

        public List<Car> LastAddedCarsT()
        {
            return _dashboardDal.LastAddedCars();
        }

        public List<Review> LastReviewsT()
        {
            return _dashboardDal.LastReviews();
        }

        public int TotalBookingCountT()
        {
           return _dashboardDal.TotalBookingCount();
        }

        public int TotalBrandCountT()
        {
           return _dashboardDal.TotalBrandCount();
        }

        public int TotalCarCountT()
        {
            return _dashboardDal.TotalCarCount();
        }

        public int TotalMessageCountT()
        {
           return _dashboardDal.TotalMessageCount();
        }

        public int TotalReviewCountT()
        {
           return _dashboardDal.TotalReviewCount();
        }

        public int TotalUserCountT()
        {
            return _dashboardDal.TotalUserCount();  
        }

        public double UserReviewAverageT()
        {
            return _dashboardDal.UserReviewAverage();
        }

        public int WaitingBookingCountT()
        {
            return _dashboardDal.WaitingBookingCount();
        }

        public List<Booking> WaitingBookingsListT()
        {
           return _dashboardDal.WaitingBookingsList();
        }
    }
}
