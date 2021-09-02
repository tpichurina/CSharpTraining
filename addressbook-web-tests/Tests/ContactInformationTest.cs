using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            string fromDetails = app.Contacts.CleanUpAllContactData(app.Contacts.GetContactInformationFromDetails(0));
            string fromForm = app.Contacts.CleanUpAllContactData(app.Contacts.GetContactInformationFromEditForm(0).AllContactData);

            Assert.AreEqual(fromForm, fromDetails);
        }
    }
}
