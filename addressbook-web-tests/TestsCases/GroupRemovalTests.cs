using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}
