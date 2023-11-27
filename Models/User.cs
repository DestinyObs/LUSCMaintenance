using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace LUSCMaintenance.Models
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@lmu\.edu\.ng$")]
        public string WebMail { get; set; }

        public bool IsVerified { get; set; } = false;
        public string Roles { get; set; } = "Student";
        // Foreign key for UserVerification
        public int? UserVerificationId { get; set; }
        public UserVerification UserVerification { get; set; }
    }

}
