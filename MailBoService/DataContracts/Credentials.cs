using System.Runtime.Serialization;

namespace MailBoService.DataContracts
{
    [DataContract]
    public class Credentials
    {
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}