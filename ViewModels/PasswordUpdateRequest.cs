using System.ComponentModel.DataAnnotations;

namespace LUSCMaintenance.ViewModels
{
    public class PasswordUpdateRequest
    {
        [Required]
        public string ResetToken { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }

}
