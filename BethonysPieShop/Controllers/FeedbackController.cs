using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models;
using BethonysPieShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethonysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {

        //feedback controller of course will going to have a dependency on feedback repository
        private readonly IFeedbackRepository _feedBackRepository;

        //and we inject that feedback repository dependency via constructor injection
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedBackRepository = feedbackRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //validation on model triggered when modelbinding is happening
        //so before the index post method is going to be invoked
        //when model binding happens a side product is been produced name ModelState
        //ModelState includes all the errors of the model and an IsValid property
        [HttpPost]
        public IActionResult Index(Feedback feedback)//from modelbinding form data became available to us via parameter without us having manually retrieve the data from form fields
        {
            if (ModelState.IsValid)
            {
            _feedBackRepository.AddFeedback(feedback);
            return RedirectToAction("FeedbackComplete");
            }
            else
            {
                return View(feedback);//if form invalid return the form with errors
            }
            
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
