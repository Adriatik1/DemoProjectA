using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProjectA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DemoDbContext _demoDbContext;

        public ProductsController(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        public IActionResult Index()
        {
            if (ViewBag.Message == null)
            {
                ViewBag.Message = "";
            }

            var products = _demoDbContext.Products
                .Select(x => new ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CompanyOrigin = x.CompanyOrigin,
                    Stock = x.Stock,
                    Description = x.Description,
                    UnitId = x.UnitId,
                    UnitName = x.Unit!.Name
                }).ToList();

            return View(products);
        }

        public IActionResult CreateOrEditProduct(Guid? id)
        {
            ViewBag.Message = "";
            ViewBag.Units = _demoDbContext.Units
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            var model = new ProductModel();

            if (id != null && id != Guid.Empty)
            {
                var product = _demoDbContext.Products
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                if (product == null)
                {
                    ViewBag.Message = "Product not found!";
                }
                else
                {
                    model.Id = product.Id;
                    model.Name = product.Name;
                    model.CompanyOrigin = product.CompanyOrigin;
                    model.Stock = product.Stock;
                    model.Description = product.Description;
                    model.UnitId = product.UnitId;
                }
            }

            return View(model);
        }

        public IActionResult DeleteProduct(Guid id)
        {
            var product = _demoDbContext.Products
                   .Where(x => x.Id == id)
                   .SingleOrDefault();

            if (product == null)
            {
                ViewBag.Message = "Product not found!";
            } 
            else
            {
                _demoDbContext.Products.Remove(product);
                _demoDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateOrEditProductPOST(ProductModel model)
        {
            if (model.Id != Guid.Empty)
            {
                var product = _demoDbContext.Products
                   .Where(x => x.Id == model.Id)
                   .SingleOrDefault();

                if (product == null)
                {
                    ViewBag.Message = "Product not found!";
                }
                else
                {
                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.CompanyOrigin = model.CompanyOrigin;
                    product.Stock = model.Stock;
                    product.Description = model.Description;
                    product.UnitId = model.UnitId;

                    ViewBag.Message = $"Product {product.Name} updated successfully";

                    _demoDbContext.SaveChanges();
                }
            }
            else
            {
                _demoDbContext.Products.Add(new ProductEntity
                {
                    Name = model.Name,
                    CompanyOrigin = model.CompanyOrigin,
                    Description = model.Description,
                    Stock = model.Stock,
                    UnitId = model.UnitId
                });

                _demoDbContext.SaveChanges();

                ViewBag.Message = $"Product {model.Name} added successfully";
            }

            return RedirectToAction("Index");
        }
    }
}
