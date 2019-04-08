using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace PersonalSite.Areas.Identity.Models
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //TODO: implement email verification
            throw new NotImplementedException();
        }
    }
}
