using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredantials()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            // verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }


        [Test]
        public void LoginWithInvalidCredantials()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "111111");
            app.Auth.Login(account);

            // verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
