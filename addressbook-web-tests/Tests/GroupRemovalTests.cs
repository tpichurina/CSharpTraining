using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestbase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                var newData = new GroupData("ww");
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
