using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Know_Your_Nation_Speedy.Controllers
{
    public class RattingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}