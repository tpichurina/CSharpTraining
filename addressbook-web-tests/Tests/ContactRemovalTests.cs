using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : ContactTestbase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                var newData = new ContactData("ww", "tt");
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.RemoveContact(toBeRemoved, true);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
