using MailBo.Contracts;
using System;
using System.Text;

namespace MailBo
{
    public class UserRepositoryImpl : UserRepository
    {

        public string Login(string username, string password)
        {
            using (var client = new MailBoServiceRef.SignOnServiceClient())
            {
                return client.Login(new MailBoServiceRef.Credentials() { Username=username, Password = password});
            }
        }
        
        public  string GetMessages(string sessionID)
        {
            var sb = new StringBuilder();
            using (var client = new MailBoServiceRef.SignOnServiceClient())
            {
                var messages = client.GetNews( sessionID);
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
