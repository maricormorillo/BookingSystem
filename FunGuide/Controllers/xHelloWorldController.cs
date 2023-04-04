using Microsoft.AspNetCore.Mvc;

namespace FunGuide.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
    }
}
