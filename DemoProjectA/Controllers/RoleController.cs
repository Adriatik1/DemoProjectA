﻿using Microsoft.AspNetCore.Mvc;

namespace DemoProjectA.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateRole()
        {

            return View();
        }
    }
}
