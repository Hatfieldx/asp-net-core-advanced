using System.ComponentModel.DataAnnotations;

namespace lesson5_EmailSender.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Range(10, 99, ErrorMessage = "Возвраст должент быть 10 - 99")]
        public int Age { get; set; }

        public string Country { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Description = "Почтовый адрес")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Description = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        [Required]
        [Display(Description = "Подтверждение пароля")]
        public string ConfirmedPassword { get; set; }

        public string returnUrl { get; set; }

    }
}
