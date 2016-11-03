using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MailBoService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISignOnService
    {

        [OperationContract(IsInitiating = true)]
        bool Login(string username, string password);

        [OperationContract(IsInitiating = false)]
        List<Message> GetNews();


    }

    [DataContract]
    public class Message
    {


        [DataMember]
        public bool Status
        {
            get; set;
        }

        [DataMember]
        public string Sender
        {
            get; set;
        }

        [DataMember]
        public string Reciever
        {
            get; set;
        }

        [DataMember]
        public string Subject
        {
            get; set;
        }

        [DataMember]
        public string MessageBody
        {
            get; set;
        }
    }
}
