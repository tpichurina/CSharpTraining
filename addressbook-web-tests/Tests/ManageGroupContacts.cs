using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace webAddressbookTests
{
    public class ManageGroupContacts : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {

            GroupData newData = new GroupData("testname")
            {
                Header = null,
                Footer = null
            };

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestDeletingContactFromGroup()
        {
            GroupData newData = new GroupData("testname");
            newData.Header = null;
            newData.Footer = null;

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);

        }
    }
}
