using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace LUSCMaintenance.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@lmu\.edu\.ng$")]
        public string WebMail { get; set; }

        public string Password { get; set; }
        public bool IsVerified { get; set; } = false;

        // Foreign key for UserVerification
        public int? UserVerificationId { get; set; }
        public UserVerification UserVerification { get; set; }
    }

}
