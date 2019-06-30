﻿using System;
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

        private readonly IFeedbackRepository _feedBackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedBackRepository = feedbackRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedBackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            else
            {
                return View(feedback);
            }

        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
