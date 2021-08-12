using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("qq");
            newData.Header = "q";
            newData.Footer = "q";

            app.Groups.Modify(1, newData);
        }
    }
}
