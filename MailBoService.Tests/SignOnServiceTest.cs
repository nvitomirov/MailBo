using NUnit.Framework;

namespace MailBoService.Tests
{
    [TestFixture]
    public class SignOnServiceTest : SignOnService
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
            Assert.IsNotNull(logged);
            Assert.IsNotEmpty(logged);
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
            var logged = service.Login("Max", "Max123");

            //act
            var messages = service.GetNews(logged);
            //assert 
            messages.Equals(null);
        }


    }
}
