using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult CreateNewProduct(ProductModel model)
        {
            _demoDbContext.Products.Add(new ProductEntity
            {
                Name = model.Name,
                CompanyOrigin = model.CompanyOrigin,
                Description = model.Description,
                Stock = model.Stock,
                UnitId = Guid.Parse("b24348fb-0724-4681-95b6-215659debb82")
            });

            _demoDbContext.SaveChanges();

            return View();
        }
    }
}
