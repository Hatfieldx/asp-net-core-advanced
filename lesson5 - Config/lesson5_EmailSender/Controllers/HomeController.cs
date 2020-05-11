using Microsoft.AspNetCore.Mvc;

namespace lesson5_EmailSender.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
