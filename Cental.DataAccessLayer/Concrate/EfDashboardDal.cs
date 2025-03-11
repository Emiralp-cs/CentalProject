using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrate
{
    public class EfDashboardDal(CentalContext _context) : IDashboardDal
    {
        public int ApprovedBookingCount()
        {

            return _context.Bookings.Count();
        }

        public int DeclinedBookingCount()
        {

            return _context.Bookings.Where(x => x.IsApproved == false).Count();
        }

        public List<Car> LastAddedCars()
        {

            return _context.Cars.OrderByDescending(x => x.CarId).Take(5).ToList();
        }

        public List<Review> LastReviews()
        {

            return _context.Reviews.OrderByDescending(x => x.ReviewId).Take(3).ToList();
        }

        public int TotalBookingCount()
        {
            return _context.Bookings.Count();
        }

        public int TotalBrandCount()
        {
            return _context.Brands.Count();
        }

        public int TotalCarCount()
        {
            return _context.Cars.Count();
        }

        public int TotalMessageCount()
        {
            return _context.Contacts.Count();
        }

        public int TotalReviewCount()
        {
            return _context.Reviews.Count();
        }

        public int TotalUserCount()
        {
            return _context.Users.Count();
        }

        public double UserReviewAverage()
        {
            if (_context.Reviews == null || !_context.Reviews.Any())
            {
                return 0;
            }


            return _context.Reviews.Average(x => x.Rating);
        }

        public int WaitingBookingCount()
        {
            return _context.Bookings.Where(x => x.IsApproved == null).Count();
        }

        public List<Booking> WaitingBookingsList()
        {
            return _context.Bookings.Where(x => x.IsApproved == null).ToList();
        }


    }
}
