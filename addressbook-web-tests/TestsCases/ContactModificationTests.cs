using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("w", "q");
            newData.Title = "1";
            newData.Company = "2";
            newData.Nickname = "3";

            app.Contacts.Modify(newData);
            app.Navigator.ReturnToHomePage();
        }
    }
}
