using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models;
using BethonysPieShop.Models.Interfaces;
using BethonysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethonysPieShop.Controllers
{
    public class HomeController : Controller
    {
        //a controller will use repository to talk with the model
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)//dependency injection will automatically inject MockPieRepository instance to this constructor when requesting an IPieRepository 
        {
            //if no dependency injection system, we initialize a pie repository for this class in it's constructor like below
            //_pieRepository = new MockPieRepository();

            //setting the MockPieRepository instance to our local pieRepository
            _pieRepository = pieRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //---Method 1--
            //Viewbag is a dynamic object 
            //We can specify dynamic properties to be send to the corresponding view which will share the same viewbag as the controller
            //ViewBag.Title = "Pie Overview";

            //also we can pass strongly typed objects to the view which view will access them through Model property
            //var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            //return View(pies);

            //--Method 2---
            //two ways are used above to pass data to the same view. using VIEWBAG + STRONGLY TYPED MODEL
            //but it's best to have one type that will contain all data that needed by view
            //so we pass a viewmodel to the view
            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethanys Pie Shop!",
                Pies = pies.ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
