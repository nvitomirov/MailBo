using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailBoService.Models
{
    public class UserLogIn
    {
        public UserLogIn()
        {
            CreatedDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
        }

        public Guid UserId { get; set; }
        public string SessionID { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastActivityDate { get; private set; }

        public bool IsUserLoggedIn()
        {
            return DateTime.Now < LastActivityDate.AddHours(3);
        }

        public void SetLastActivity()
        {
            LastActivityDate = DateTime.Now;
        }
    }
}