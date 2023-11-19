namespace LUSCMaintenance.Models
{
        public class UserVerification
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string VerificationToken { get; set; }
            public bool IsVerified { get; set; }
            public DateTime CreatedAt { get; set; }

            // Navigation property
            public User User { get; set; }
        }
    }
