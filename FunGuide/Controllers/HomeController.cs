using FunGuide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using FunGuide.Areas.Data;
using Microsoft.EntityFrameworkCore;

namespace FunGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private UserManager<AppUser> _userManager;

        public HomeController(ILogger<UserController> logger, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult Index()
        //{
        //    return Redirect("~/Activities/Index");
        //}

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Career()
        {
            return View();
        }


        //public async Task<IActionResult> ActivityList(int? id)
        //{
        //    if (id == null || _context.Activities == null)
        //    {
        //        return NotFound();
        //    }

        //    var activities = await _context.Activities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (activities == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(activities);
        //}


        //public IActionResult Users()
        //{
        //    return View(_userManager.Users.ToList());
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}