using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MailBoService
{
    public class SignOnService : ISignOnService
    {
        private static ConcurrentDictionary<string, string> authenticated = new ConcurrentDictionary<string, string>();

        public bool Login(string username, string password)
        {
            var users = GetUsers();
            if (users.Any(x => x.Username == username && x.Password == password))
            {
                var currentSessionId = OperationContext.Current.SessionId;
                authenticated.TryAdd(currentSessionId, username);

                return true;
            }

            return false;
        }

        public List<Message> GetNews()
        {
            string name;

            if (authenticated.TryGetValue(OperationContext.Current.SessionId, out name))
            {
                return SavedNews().Where(x => x.Reciever == name && !x.Status).ToList();
            }
            else
            {
                return null;
            }
        }

        private List<Message> SavedNews()
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
