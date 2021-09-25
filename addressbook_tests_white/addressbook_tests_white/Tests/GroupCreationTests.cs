using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGrops = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "w"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGrops = app.Groups.GetGroupList();
            oldGrops.Add(newGroup);
            oldGrops.Sort();
            newGrops.Sort();

            Assert.AreEqual(oldGrops, newGrops);
        }
    }
}
