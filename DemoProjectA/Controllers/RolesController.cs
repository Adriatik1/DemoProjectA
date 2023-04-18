using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoProjectA.Controllers
{
    public class RolesController : Controller
    {
        private readonly DemoDbContext _dbContext;

        public RolesController(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var roles = _dbContext.Roles
                .Select(x => new RoleModel
                {
                    Id = x.Id,
                    Name = x.RoleName
                }).ToList();

            return View(roles);
        }

        public IActionResult UpSertRole(Guid? roleId)
        {
            var model = new RoleModel();

            if (roleId.HasValue)
            {
                model = _dbContext.Roles
                    .Where(x => x.Id == roleId)
                    .Select(x => new RoleModel
                    {
                        Id = x.Id,
                        Name = x.RoleName
                    })
                    .FirstOrDefault();

                if (model is null)
                {
                    ViewBag.ErrorMessage = "Role not found!";
                }

                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSertRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id.HasValue)
                {
                    var entity = _dbContext.Roles
                        .Where(x => x.Id == model.Id)
                        .FirstOrDefault();

                    if (entity is null)
                    {
                        ViewBag.Message = "Role Not Found!";
                        return RedirectToAction("UpSertRole", new { roleId = model.Id });
                    }

                    entity!.RoleName = model.Name;
                    _dbContext.SaveChanges();
                }
                else
                {
                    var entity = new RoleEntity()
                    {
                        RoleName = model.Name
                    };

                    _dbContext.Roles.Add(entity);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index", model);
            }

            ViewBag.ErrorMessage = "Model is not valid";

            return View(model);
        }


        public IActionResult Delete(Guid roleId)
        {
            var entity = _dbContext.Roles
                        .Where(x => x.Id == roleId)
                        .FirstOrDefault();
            if (entity is null)
            {
                ViewBag.ErrorMessage = "Role not found!";
                return RedirectToAction("Index");
            }

            _dbContext.Roles.Remove(entity!);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}
