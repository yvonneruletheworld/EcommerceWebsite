using EcommerceWebsite.Utilities.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceWebsite.Services.Interfaces.ExtraServices
{
    public interface IEmailSenderServices
    {
        bool SendMail (EmailMessageSender emailMessage);
    }
}
