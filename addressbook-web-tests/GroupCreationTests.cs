using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("test");
            group.Header = "test1";
            group.Footer = "test2";
            FillGroupForm(group);
            SubmitGroupsCreation();
            ReturnToGroups();
        }
    }
}
