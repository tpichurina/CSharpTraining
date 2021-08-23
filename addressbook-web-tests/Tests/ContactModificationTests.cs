using NUnit.Framework;
using System.Collections.Generic;


namespace webAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("changed", "contact");
            newData.Title = null;
            newData.Company = null;
            newData.Nickname = null;

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
