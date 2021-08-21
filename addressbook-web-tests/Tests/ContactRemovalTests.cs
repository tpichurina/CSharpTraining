using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.RemoveContact(1, true);
            app.Navigator.ReturnToHomePage();
        }
    }
}
