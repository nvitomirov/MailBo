using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailBoService.Models
{

    public class Message
    {
        public bool Status { get; set; }

        public string Sender { get; set; }

        public List<Guid> Recievers { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public virtual List<User> RecieverUsers { get; set; }

    }
}