using System.ComponentModel.DataAnnotations;

namespace lesson5_EmailSender.Models.ViewModels
{
    public class MailViewModel
    {
        [Display(Description ="Текст письма")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Текст сообщения не может быть пустым")]
        public string Body { get; set; }
        
        [Display(Description = "Получатель")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string To { get; set; }
        [Display(Description = "Тема письма")]
        public string Subject { get; set; }
    }
}
