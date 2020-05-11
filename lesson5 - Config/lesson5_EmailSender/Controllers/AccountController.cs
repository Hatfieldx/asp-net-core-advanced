using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson5_EmailSender.Models;
using lesson5_EmailSender.Models.ViewModels;

namespace lesson5_EmailSender.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
           return View(new LoginViewModel { returnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            User user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Пользователя с такой почтой не существует");
                return View(login);
            }
            
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Неправильный пользователь или пароль");

                return View(login);
            }

            if (string.IsNullOrWhiteSpace(login.returnUrl) && !Url.IsLocalUrl(login.returnUrl))
            {
                return StatusCode(404);
            }
            
            return Redirect(login.returnUrl);
        }

        [HttpGet]
        public IActionResult Register(string retUrl = null)
        {
            retUrl = retUrl ?? Url.Content("~/");

            return View(new RegisterViewModel {UserName = "Nik", Age = 22, Country = "Nvkz", Email = "123@321.ru", returnUrl = retUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (string.IsNullOrWhiteSpace(registerModel.returnUrl) && !Url.IsLocalUrl(registerModel.returnUrl))
            {
                return StatusCode(404);
            }
            
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            User user = await _userManager.FindByEmailAsync(registerModel.Email);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Пользователь с такой почтой уже существует");
                return View(registerModel);
            }

            user = new User {UserName = registerModel.UserName, Age = registerModel.Age, Email = registerModel.Email,  Country = registerModel.Country};

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(registerModel);
            }

            await _signInManager.SignInAsync(user, false);

            return Redirect(registerModel.returnUrl);
        }
    }
}
