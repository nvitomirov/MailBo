using System.Runtime.Serialization;

namespace MailBoService.DataContracts
{
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