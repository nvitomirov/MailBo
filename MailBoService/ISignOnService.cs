using MailBoService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace MailBoService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISignOnService
    {

        [OperationContract(IsInitiating = true)]
        string Login(string username, string password);

        [OperationContract(IsInitiating = false)]
        List<Message> GetNews(string username);


    }
}
