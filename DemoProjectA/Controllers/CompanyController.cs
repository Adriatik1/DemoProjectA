using DemoProjectA.Models.Company;
using DemoProjectA.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace DemoProjectA.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            var returnModel = new CompanyModel()
            {
                Name = "Comitas AG",
                Address = "Musine Kokalari 10",
                Employees = new List<EmployeeModel>
                {
                    new EmployeeModel()
                    {
                        FirstName = "Adriatik",
                        LastName = "Ademi",
                        Position = "Head of dev",
                        Salary = 10,
                        JoinedDate = DateTime.Now.AddYears(-1),
                    },
                    new EmployeeModel()
                    {
                        FirstName = "Muharrem",
                        LastName = "Demiri",
                        Position = "Tech lead",
                        Salary = 30000,
                         JoinedDate = DateTime.Now.AddMonths(-16),
                    },
                    new EmployeeModel()
                    {
                        FirstName = "Njomza",
                        LastName = "Shatrolli",
                        Position = "Tech lead",
                        Salary = 90000,
                        JoinedDate = DateTime.Now.AddYears(-5),
                    }
                }
            };

            return View(returnModel);
        }
    }
}
