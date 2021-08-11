using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("test", "test");
            contact.Title = "test";
            contact.Company = "test";
            contact.Nickname = "test";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitAccountCreation();
            app.Navigator.ReturnToHomePage();
        }
    }
}
