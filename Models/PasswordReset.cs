namespace LUSCMaintenance.Models
{
    public class PasswordReset
    {
        public int Id { get; set; }
        public int  UserId { get; set; } // Foreign key to the User table
        public string ResetToken { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property to the associated user
        public User User { get; set; }
    }


}
