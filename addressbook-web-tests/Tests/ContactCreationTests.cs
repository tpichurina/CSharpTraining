﻿using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("test", "test");
            contact.Title = "test";
            contact.Company = "test";
            contact.Nickname = "test";

            app.Contacts.Create(contact);
            app.Navigator.ReturnToHomePage();
        }
    }
}