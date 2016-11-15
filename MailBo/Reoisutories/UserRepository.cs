using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailBo
{
    public class UserRepository
    {
        //uups some realy bad code
        public string Login(string username, string password)
        {
            using (var client = new MailBoServiceRef.SignOnServiceClient())
            {
                var result = client.Login(username, password);
                var sb = new StringBuilder();
                if (result)
                {
                    var messages = client.GetNews();
                    foreach (var message in messages)
                    {
                        sb.Append("Absender: ")
                            .Append(message.Sender)
                            .Append(" Empfänger: ")
                            .Append(message.Reciever)
                              .Append(" Betreff: ")
                            .Append(message.Subject)
                            .Append(" Text: ")
                            .Append(message.MessageBody)
                            .Append(Environment.NewLine);
                    }
                }
                return sb.ToString();
            }
        }
    }
}
