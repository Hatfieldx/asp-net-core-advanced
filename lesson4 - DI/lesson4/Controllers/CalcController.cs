using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson4.Models.ViewModels;
using lesson4.Services;
using Microsoft.AspNetCore.Mvc;

namespace lesson4.Controllers
{
    [Route("Calc/[action]")]
    public class CalcController : Controller
    {
        private readonly CalculateService _calc;        

        public IActionResult Sum(int a, int b)
        {            
            return View("CalcView", new CalcViewModel {A = a,  B = b, Result = _calc.Sum(a, b)});
        }
        public IActionResult Sub(int a, int b)
        {
            return View("CalcView", new CalcViewModel { A = a, B = b, Result = _calc.Substract(a, b) });
        }
        public IActionResult Mult(int a, int b)
        {
            return View("CalcView", new CalcViewModel { A = a, B = b, Result = _calc.Mult(a, b) });
        }
        
        public IActionResult Div(int a, int b)
        {
            return View("CalcView", new CalcViewModel { A = a, B = b, Result = _calc.Div(a, b) });
        }
        
        public IActionResult CalcView()
        {
            return View("CalcView", new CalcViewModel(0, 0, 0));
        }

        public CalcController(CalculateService calc)
        {
            _calc = calc;
        }
    }
}