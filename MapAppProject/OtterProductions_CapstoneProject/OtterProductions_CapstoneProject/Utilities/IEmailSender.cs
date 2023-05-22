using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Utilities
{
   public interface  IEmailSender
    {
        Task SendVerifyEmail(VerifyEmail request);
        Task<(bool verified, string message)> VerifyEmail(string token, string email);
    }
}
