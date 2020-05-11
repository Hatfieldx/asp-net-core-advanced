using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lesson2.Controllers
{
    [Route("c2")]
    public class HomeTwoController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}