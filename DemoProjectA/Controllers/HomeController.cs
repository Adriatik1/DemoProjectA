using DemoProjectA.Models;
using DemoProjectA.Models.Company;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoProjectA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            // db connection
            // find by id
            // map data


            var model = new UserModel
            {
                FirstName = "Adriatik",
                LastName = "Ademi",
                Age = 25,
                Company = new CompanyModel()
                {
                    Name = "Comitas AG",
                    Address = "Rruga Musine Kokalari, Dardani"
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}