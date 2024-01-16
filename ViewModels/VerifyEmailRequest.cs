namespace LUSCMaintenance.ViewModels
{
    public class VerifyEmailRequest
    {
        public string UserId { get; set; }
        public string VerificationToken { get; set; }
    }
}
