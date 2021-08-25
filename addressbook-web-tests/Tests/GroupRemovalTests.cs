using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                var newData = new GroupData("ww");
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
