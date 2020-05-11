using lesson5_EmailSender.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using lesson5_EmailSender.Services;
using Microsoft.AspNetCore.Authorization;

namespace lesson5_EmailSender.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailservice;


        [HttpGet]
        [Authorize]
        public IActionResult Send()
        {
            return View("SendMailForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(MailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _emailservice.SendEmailAsync(model.To, model.Subject, model.Body);
            }

            return Content("OKE");
        }

        public EmailController(EmailService emailservice)
        {
            _emailservice = emailservice;
        }
    }
}
