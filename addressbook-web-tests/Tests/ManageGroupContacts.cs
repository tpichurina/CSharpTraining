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
            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData("qq");
                app.Groups.Create(newGroup);
            }

            GroupData group = GroupData.GetAll()[0];

            if (GroupData.GetAll().Count == 0)
            {
                ContactData newContact = new ContactData("qq", "ll");
                app.Contacts.Create(newContact);
            }


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
            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData("qq");
                app.Groups.Create(newGroup);
            }

            GroupData group = GroupData.GetAll()[0];

            List<ContactData> contactInGroup = group.GetContacts();
            if (contactInGroup.Count == 0)
            {
                ContactData contactWithoutGroup = ContactData.GetContactWithoutGroup();

                if (contactWithoutGroup == null)
                {
                    ContactData newContact = new ContactData("qq", "ll");
                    app.Contacts.Create(newContact);
                    contactWithoutGroup = ContactData.GetAll().Except(group.GetContacts()).First();
                }

                app.Contacts.AddContactToGroup(contactWithoutGroup, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);

            Assert.AreEqual(oldList, newList);
        }
    }
}
