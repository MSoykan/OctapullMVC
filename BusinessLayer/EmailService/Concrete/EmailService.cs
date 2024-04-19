using BusinessLayer.EmailService.Abstract;
using BusinessLayer.EmailService.Dto;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EmailService.Concrete {
    public class EmailService : IEmailService {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }
        public void SendEmail(EmailDto request) {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config.GetSection("MockEmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body};

            using var smtp = new SmtpClient();
            smtp.Connect(config.GetSection("MockEmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(config.GetSection("MockEmailUsername").Value, config.GetSection("MockEmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
