using MailBoService.DataContracts;
using NUnit.Framework;

namespace MailBoService.Tests
{
    [TestFixture]
    public class SignOnServiceTest : SignOnService
    {
        private SignOnService service;
        private static Credentials credentials = new Credentials("Max", "Max123");

        [SetUp]
        public void InitializeSignOnService()
        {
            service = new SignOnService();
        }


        [Test]
        public void UserLogin_Successfull_ReturnsSessionID()
        {
            //arrange
          
            //act
            var logged = service.Login(credentials);

            //assert 
            Assert.IsNotNull(logged);
            Assert.IsNotEmpty(logged);
        }

        [Test]
        public void UserLogin_AllreadyLoggedIn_ReturnsUsedSessionID()
        {
            //arrange
            var sessionID = service.Login(credentials);
            //act

            var newSessionId =service.Login(credentials);

            //assert 
            Assert.IsNotNull(newSessionId);
            Assert.IsNotEmpty(newSessionId);
            Assert.AreEqual(newSessionId, sessionID);
        }

        [Test]
        public void UserLogin_NotSuccessfull_ReturnsNull()
        {
            //arrange
            var falseCredentials = new Credentials("Max2112", "");
            //act
            var logged = service.Login(falseCredentials);

            //assert 
            Assert.IsNull(logged);
        }


        [Test]
        public void GetNews_NotLoggedIn_ReturnsNull()
        {
            //arrange
            var logged = service.Login(credentials);

            //act
            var messages = service.GetNews(logged);
            //assert 
            messages.Equals(null);
        }

        [Test]
        public void AddNews_Success()
        {
            var news = new Message();
            var session = service.Login(credentials);
            service.AddNews(session, news);
        }


    }
}
