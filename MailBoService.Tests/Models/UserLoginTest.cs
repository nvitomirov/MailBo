using MailBoService.Models;
using NUnit.Framework;
using System;

namespace MailBoService.Tests.Models
{
    [TestFixture]
    public class UserLoginTest
    {

        [Test]
        public void UserLogin_Creational_SetsCreatedDateAndLastActivityDate()
        {
            //arrange
            var userLogin = new UserLogIn();

            //assert
            Assert.AreEqual(userLogin.CreatedDate.ToString("dd.MM.yyyy hh:mm"), DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
            Assert.AreEqual(userLogin.LastActivityDate.ToString("dd.MM.yyyy hh:mm"), DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
        }


        [Test]
        public void UserLogin_IsUserLoggedIn()
        {
            //arrange
            var userLogin = new UserLogIn();

            //act
            var loggedIn = userLogin.IsUserLoggedIn();

            //assert
            Assert.IsTrue(loggedIn);
        }
    }
}
