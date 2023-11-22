using System.ComponentModel.DataAnnotations;

namespace LUSCMaintenance.ViewModels
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string WebMail { get; set; }
    }

}
