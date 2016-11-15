using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailBo.Contracts
{
    public interface UserRepository
    {
        bool Login(string username, string password);
        string GetMessages(string username);
    }
}
