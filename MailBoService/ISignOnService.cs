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
        ICollection<Message> GetNews(string sessionID);

        [OperationContract]
        bool AddNews(string sessionId, Message newMessage);
    }
}
