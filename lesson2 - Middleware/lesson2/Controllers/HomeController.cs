using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lesson2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Count = HttpContext.Items.ContainsKey("CurrentCounts") ? HttpContext.Items["CurrentCounts"] : 0;

            return View();
        }
    }
}
