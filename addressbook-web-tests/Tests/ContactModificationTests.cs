using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestbase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("changed", "contact")
            {
                Title = null,
                Company = null,
                Nickname = null
            };

            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toModifi = oldContacts[0];

            toModifi.FirstName = newData.FirstName;
            toModifi.LastName = newData.LastName;

            app.Contacts.Modify(toModifi);

            List<ContactData> newContacts = ContactData.GetAll();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
