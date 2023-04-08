using Microsoft.AspNetCore.Mvc;

namespace DemoProjectA.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNewRole()
        {
            return View();
        }
    }
}
