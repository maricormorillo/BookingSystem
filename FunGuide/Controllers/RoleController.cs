using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunGuide.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Role()
        {
            return View();
        }
    }
}
