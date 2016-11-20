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
        public void UserLogOut_RemovesUserSessionID_CreatesNewOnLogin()
        {
            //arrange
            var sessionId = service.Login(credentials);
            //act
            service.LogOut(sessionId);

            //assert 
            Assert.IsNotNull(sessionId);
        }

        [Test]
        public void GetNewMessages_NotLoggedIn_ReturnsNull()
        {
            //arrange
            var logged = service.Login(credentials);

            //act
            var messages = service.GetNewMessages(logged);
            //assert 
            messages.Equals(null);
        }

        [Test]
        public void GetAllMessages_ReturnsList()
        {
            //arrange
            var logged = service.Login(credentials);

            //act
            var messages = service.GetAllMessages(logged);
            //assert 
            Assert.IsNotNull(messages);
        }

        [Test]
        public void AddNews_Success()
        {
            var news = new Message() {
                MessageBody="",
                Reciever = "Max1",
            };
            var session = service.Login(credentials);
            var sut = service.AddNews(session, news);

            //assert
            Assert.IsTrue(sut);
        }


    }
}
