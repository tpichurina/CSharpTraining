using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("testnewgroup");
            group.Header = "test1";
            group.Footer = "test2";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        ////[Test]
        ////public void BadNemeGroupCreationTest()
        ////{
        ////    GroupData group = new GroupData("a'a");
        ////    group.Header = "";
        ////    group.Footer = "";

        ////    List<GroupData> oldGroups = app.Groups.GetGroupList();

        ////    app.Groups.Create(group);

        //List<GroupData> newGroups = app.Groups.GetGroupList();
        //oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        ////}

    }
}
