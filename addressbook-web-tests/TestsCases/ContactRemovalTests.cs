using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.RemoveContact(1, true);
            app.Navigator.ReturnToHomePage();
        }
    }
}
