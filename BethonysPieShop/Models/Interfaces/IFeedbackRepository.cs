using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethonysPieShop.Models.Interfaces
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
