using MailBoService.DataContracts;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MailBoService
{
    public class SignOnService : ISignOnService
    {
        private static ConcurrentDictionary<string, string> authenticated = new ConcurrentDictionary<string, string>();
        private List<User> Users;
        private List<Message> Messages;

        public SignOnService()
        {
            Users = GetUsers();
            Messages = GetMessages();
        }

        public string Login(string username, string password)
        {
            if (ValidateUserCredentials(username, password))
            {
                SetSession(username);
                return GetSession(username);
            }
            return null;
        }

        public List<Message> GetNews(string session)
        {
            var username = GetUsername(session);
            return Messages.Where(x => x.Reciever == username && !x.Status).ToList();
        }

        private void SetSession(string username)
        {
            var currentSessionId = OperationContext.Current.SessionId;
            authenticated.TryAdd(currentSessionId, username);
        }

        private string GetSession(string username)
        {
            string session;
            authenticated.TryGetValue(username, out session);
            return session;
        }

        private string GetUsername(string session)
        {
            return authenticated.ToArray().FirstOrDefault(x => x.Value == session).Key;
        }

        private bool ValidateUserCredentials(string username, string password)
        {
            return Users.Any(x => x.Username == username && x.Password == password);
        }

        private string TryGetAuthenticatedUsername()
        {
            string name = null;
            authenticated.TryGetValue(OperationContext.Current.SessionId, out name);
            return name;
        }

        private List<Message> GetMessages()
        {
            return new List<Message>
            {
                new Message { Sender ="Lucas", Reciever="Max", Subject ="Test", MessageBody ="Test 1", Status = false },
                new Message { Sender ="Lucas", Reciever="Max",Subject ="Test", MessageBody ="Test 2",Status=false },
                new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test sds1", Status = false },
                new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 14324" , Status=true},
                new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 143242" , Status=false },
                new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 432421", Status=true },
                 new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 432421", Status=false },
                  new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 432421", Status=true },
                   new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 432421", Status=false },
                    new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test 432421" , Status=true},
            };
        }

        private List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Username="Max", Password="Max123"},
                 new User { Username="Lucas", Password="Lucas123"},
            };
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
