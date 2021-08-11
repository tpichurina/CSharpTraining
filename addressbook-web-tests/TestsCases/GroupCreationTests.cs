using NUnit.Framework;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.GoToGroupPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("test");
            group.Header = "test1";
            group.Footer = "test2";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupsCreation();
            app.Groups.ReturnToGroups();
        }
    }
}
