using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace MailBoService.Tests
{
    [TestFixture]
    public class SignOnServiceTest
    {

        [Test]
        public void UserLogin_Successfull()
        {

            //arrange
            var service = new SignOnService();
            var username = "Max";
            var password = "Max123";

            //act
            var logged = service.Login(username, password);

           //assert 
           logged.Equals(true);
        }

        [Test]
        public void UserLogin_NotSuccessfull()
        {
            //arrange
            var service = new SignOnService();
            var username = "Max";
            var password = "Max12";

            //act
            var logged = service.Login(username, password);

           //assert 
           logged.Equals(false);
        }


        [Test]
        public void GetNews_NotLoggedIn()
        {
            var service = new SignOnService();

            //act
            var messages = service.GetNews();

            //assert 
            messages.Equals(null);
        }
    }
}
