using MailBo.Contracts;
using System;
using System.Text;

namespace MailBo
{
    public class UserRepositoryImpl : UserRepository
    {

        public bool Login(string username, string password)
        {
            using (var client = new MailBoServiceRef.SignOnServiceClient())
            {
                return client.Login(username, password);
            }
        }
        
        public  string GetMessages(string username)
        {
            var sb = new StringBuilder();
            using (var client = new MailBoServiceRef.SignOnServiceClient())
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
                return sb.ToString();
            }
           
        }
    }
}
