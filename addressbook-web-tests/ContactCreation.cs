using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("test", "test");
            contact.Title = "test";
            contact.Company = "test";
            contact.Nickname = "test";
            FillContactForm(contact);
            SubmitAccountCreation();
            ReturnToHomePage();
        }
    }
}
