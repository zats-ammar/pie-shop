using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models.Context;
using BethonysPieShop.Models.Interfaces;

namespace BethonysPieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
