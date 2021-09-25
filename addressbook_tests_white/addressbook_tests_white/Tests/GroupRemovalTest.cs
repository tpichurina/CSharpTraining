using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]

    public class GroupRemovalTests : TestBase

    {
        [Test]
        public void TestGroupRemoval()
        {
            if (!app.Groups.IsMoreThenOne())
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "a"
                };
                app.Groups.Add(newGroup);
            }

            List<GroupData> oldGrops = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGrops[0];

            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGrops = app.Groups.GetGroupList();
            oldGrops.RemoveAt(0);

            Assert.AreEqual(oldGrops, newGrops);
        }
    }
}
