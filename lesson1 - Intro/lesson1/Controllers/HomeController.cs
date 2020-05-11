using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace lesson1.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _webHostEnv;
        
        public IActionResult Index()
        {
            var os = Environment.OSVersion;

            string Is64Bit = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            
            return Content($"OS: {os.VersionString}, is {Is64Bit}");
        }
        public HomeController(IWebHostEnvironment env)
        {
            _webHostEnv = env;
        }
    }
}