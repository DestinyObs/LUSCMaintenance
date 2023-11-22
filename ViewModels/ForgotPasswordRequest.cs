using System.ComponentModel.DataAnnotations;

namespace LUSCMaintenance.ViewModels
{
    public class ForgotPasswordRequest
    {
        [Required]

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@lmu\.edu\.ng$")]
        public string WebMail { get; set; }
    }

}
