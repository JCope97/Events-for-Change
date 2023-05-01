using Castle.Core.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace OtterProductions_CapstoneProject.Utilities
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
         private readonly ILogger<EmailSender> _logger;
        private readonly SendGridParams _sendGridSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmailSender( IOptions<EmailConfiguration> emailConfig, IOptions<SendGridParams> sendGridSettings, ILogger<EmailSender> logger, UserManager<ApplicationUser> userManager)
        {
            _emailConfig = emailConfig.Value;
            _sendGridSettings = sendGridSettings.Value;
            _logger = logger;
            _userManager = userManager;

        }
        public async Task SendVerifyEmail(VerifyEmail request) //  Method for send verify email
        {
            try
            {
                var apiKey = _sendGridSettings.ApiKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_sendGridSettings.From, _sendGridSettings.FromName);
                var subject = request.Subject;
                var to = new EmailAddress(request.Email);
                var plainTextContent = "";
                var currentYear = DateTime.Now.Year.ToString();
                string FilePath = Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\ConfirmEmailTemplate.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();
                MailText = MailText.Replace("[token]", request.Link).Replace("[year]", currentYear).Replace("[username]", request.Email);
                var htmlContent = MailText;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode.ToString() == "Accepted")
                {
                    _logger.LogInformation($"Verify mail Email was sent to {request?.Email}");
                }
                else
                {
                    _logger.LogError($"Verify mail Email failed to send to {request?.Email}");
                }
            }
            catch (Exception ex)
            {


                _logger.LogError($"Verify mail Email failed to send to {request?.Email}");
                _logger.LogError(ex.Message);

            }
        }


        public async Task<(bool verified, string message)> VerifyEmail(string token, string email)        {
            var user = await _userManager.FindByNameAsync(email);            if (user == null)            {                return (false, "User does not exist");            }            token = token.Replace(" ", "+");            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)            {                return (false, "Invalid token");            }            return (true, " email successfully verified");        }

    }
}
