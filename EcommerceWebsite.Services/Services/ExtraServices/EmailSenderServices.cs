using EcommerceWebsite.Data.Configurations;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Utilities.Email;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;

namespace EcommerceWebsite.Services.Services.ExtraServices
{
    public class EmailSenderServices : IEmailSenderServices
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSenderServices(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public bool SendMail(EmailMessageSender emailMessage)
        {
            var email = CreateEmail(emailMessage);
            return GoSend(email);
        }

        private bool GoSend(MimeMessage email)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Pass);
                    client.Send(email);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }    
        }

        private MimeMessage CreateEmail(EmailMessageSender emailMessage)
        {
            var newEmail = new MimeMessage();
            newEmail.From.Add(new MailboxAddress(_emailConfig.From));
            newEmail.To.AddRange(emailMessage.Receivers);
            newEmail.Subject = emailMessage.Tilte;
            newEmail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMessage.Content
            };
            return newEmail;
        }
    }
}
