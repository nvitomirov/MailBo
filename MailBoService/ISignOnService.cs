using MailBoService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace MailBoService
{
    [ServiceContract]
    public interface ISignOnService
    {
        [OperationContract]
        string Login(Credentials credentials);

        [OperationContract]
        void LogOut(string sessionID);

        [OperationContract]
        ICollection<Message> GetNewMessages(string sessionID);

        [OperationContract]
        ICollection<Message> GetAllMessages(string sessionID);

        [OperationContract]
        bool AddNews(string sessionId, Message newMessage);
    }
}
