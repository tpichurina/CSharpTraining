using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("changedgroup");
            newData.Header = null;
            newData.Footer = null;

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }
            app.Groups.Modify(0, newData);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
