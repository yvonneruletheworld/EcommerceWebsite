using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceWebsite.Utilities.Email
{
    public  class EmailMessageSender
    {
        public List<MailboxAddress> Receivers { get; set; }
        public string Tilte { get; set; }
        public string Content { get; set; }

        public EmailMessageSender(IEnumerable<string> receivers, string tilte, string content)
        {
            Receivers = new List<MailboxAddress>();
            Receivers.AddRange(receivers.Select(r => new MailboxAddress(r)));
            Tilte = tilte;
            Content = content;
        }
    }
}
