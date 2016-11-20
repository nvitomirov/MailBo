using MailBoService.DataContracts;
using MailBoService.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Message = MailBoService.DataContracts.Message;

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

        public string Login(Credentials credentials)
        {
            if (ValidateUser(credentials))
            {
                SetSession(credentials.Username);
                return GetSession(credentials.Username);
            }
            return null;
        }

        public void LogOut(string sessionId)
        {
            RemoveSession(sessionId);
        }


        public ICollection<Message> GetNewMessages(string sessionID)
        {
            var username = GetUsername(sessionID);
            return Messages.Where(x => x.Reciever == username && !x.Status).ToList();
        }

        public ICollection<Message> GetAllMessages(string sessionID)
        {
            var username = GetUsername(sessionID);
            return Messages.Where(x => x.Reciever == username).ToList();
        }

        public bool AddNews(string session, Message newMessage)
        {

            Messages.Add(newMessage);
            return true;
        }

        private void SetSession(string username)
        {
            var currentSessionId = Guid.NewGuid();
            if (!IsUserLoggedIn(username))
                authenticated.TryAdd(username, currentSessionId.ToString());
        }

        private bool IsUserLoggedIn(string username)
        {
            return !string.IsNullOrEmpty(GetSession(username));
        }

        private string GetSession(string username)
        {
            string session;
            authenticated.TryGetValue(username, out session);
            return session;
        }

        private void RemoveSession(string sessionID)
        {
            var username = GetUsername(sessionID);
            string value = string.Empty;
            var removed = authenticated.TryRemove(username, out value);
        }

        private string GetUsername(string session)
        {
            return authenticated.ToArray().FirstOrDefault(x => x.Value == session).Key;
        }

        private bool ValidateUser(Credentials credentials)
        {
            return Users.Any(x => x.Username == credentials.Username && x.Password == credentials.Password);
        }


        private List<Message> GetMessages()
        {
            return new List<Message>
            {
                new Message { Sender ="Lucas", Reciever="Max", Subject ="Test", MessageBody ="Test 1", Status = false },
                new Message { Sender ="Lucas", Reciever="Max",Subject ="Test", MessageBody ="Test 2",Status=false },
                new Message { Sender ="Max", Reciever="Lucas",Subject ="Test", MessageBody ="Test sds1", Status = false },
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

   
}
