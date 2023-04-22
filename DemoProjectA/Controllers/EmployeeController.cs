using Domain.Entities;
using Domain.Models.Employees;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProjectA.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DemoDbContext _dbContext;

        public EmployeeController(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNewEmployee()
        {
            ViewBag.Message = "";
            var model = new EmployeeModel();

            ViewBag.Roles = _dbContext.Roles
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.RoleName
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateNewEmployeePOST(EmployeeModel model)
        {
            if (!_dbContext.Users.Where(x => x.UserEmail == model.Email).Any())
            {
                _dbContext.Users.Add(new UserEntity
                {
                    FirstName = model.FirstName!,
                    LastName = model.LastName!,
                    UserEmail = model.Email!,
                    DateOfBirth = model.DateOfBirth,
                    Phone = model.PhoneNumber,
                    RoleId = Guid.Parse(model.RoleId!)
                });

                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Message = "There was an error while attempting to create a new employee";

            return View();
        }
    }
}
