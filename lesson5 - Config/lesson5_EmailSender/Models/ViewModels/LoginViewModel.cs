using System.ComponentModel.DataAnnotations;

namespace lesson5_EmailSender.Models.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Description = "Почтовый адрес")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Description = "Пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string returnUrl { get; set; }
    }
}
