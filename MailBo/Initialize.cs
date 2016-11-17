using MailBo.Contracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailBo
{
    public class Initialize
    {
        public void Register()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<UserRepository, UserRepositoryImpl>();
        }
    }
}
