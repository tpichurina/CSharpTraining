using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("qq", "q");
            newData.Title = null;
            newData.Company = null;
            newData.Nickname = null;

            app.Contacts.Modify(newData);
            app.Navigator.ReturnToHomePage();
        }
    }
}
