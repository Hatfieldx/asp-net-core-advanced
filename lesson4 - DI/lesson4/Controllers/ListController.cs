using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson4.Services;
using Microsoft.AspNetCore.Mvc;

namespace lesson4.Controllers
{
    public class ListController : Controller
    {
        [Route("List")]
        public IActionResult Index([FromServices] IList stringList)
        {       
            return View(stringList.GetList());
        }

    }
}