using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Application.Services
{
    public interface IReviewService
    {
        IEnumerable<Review> GetReviews();       

    }
    public class ReviewService : IReviewService
    {
        private CrudContext _context;
        public ReviewService(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetReviews()
        {
            return _context.Reviews.Include(r => r.Game).Include(r => r.User).Where(r => r.Accepted).ToList();
        }


    }


}
