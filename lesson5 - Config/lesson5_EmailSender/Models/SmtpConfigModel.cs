
namespace lesson5_EmailSender.Models
{
    public class SmtpConfigModel
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSecureConnection { get; set; }
    }
}
